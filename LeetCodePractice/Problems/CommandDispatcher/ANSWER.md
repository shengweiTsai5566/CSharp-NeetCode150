# Command Dispatcher（執行緒安全命令發送佇列）

**對應 LeetCode：** Concurrency 實作題（Producer-Consumer Pattern）

**面試難度：** Medium-Hard（並發實作 + 系統設計）

---

## 解題思路

### 問題理解
多個執行緒（安全監控、路徑規劃、UI）同時想對同一個 TCP/IP Socket 發送控制命令。
若無同步機制 → 資料錯亂（Race Condition）或 Deadlock。

### 三種實作方案

面試時建議依序提出這三種方案，展現你的深度：

---

## 方案 A：Monitor (lock) + Queue + Wait/Pulse

最基礎的方案，展示你對底層同步機制的理解。

```csharp
public class CommandDispatcher : IDisposable
{
    private readonly Queue<string> _queue = new();
    private readonly object _lock = new();
    private volatile bool _running = true;
    private readonly Thread _consumer;

    public CommandDispatcher()
    {
        _consumer = new Thread(StartConsumerLoop)
        {
            IsBackground = true,
            Name = "CommandConsumer"
        };
        _consumer.Start();
    }

    public void EnqueueCommand(string cmd)
    {
        lock (_lock)
        {
            _queue.Enqueue(cmd);
            Monitor.Pulse(_lock); // 通知消費者
        }
    }

    private void StartConsumerLoop()
    {
        while (_running)
        {
            string? cmd = null;
            lock (_lock)
            {
                while (_queue.Count == 0 && _running)
                    Monitor.Wait(_lock); // 高效等待，不耗 CPU

                if (!_running) break;
                cmd = _queue.Dequeue();
            }

            if (cmd != null)
                SendCommand(cmd);
        }
    }

    private void SendCommand(string cmd)
    {
        // 模擬透過 TCP/IP 發送
        Console.WriteLine($"[Send] {cmd}");
    }

    public void Dispose()
    {
        _running = false;
        lock (_lock) Monitor.Pulse(_lock);
        _consumer.Join(TimeSpan.FromSeconds(5));
    }
}
```

**優缺點：**
- ✅ 完全控制同步行為
- ✅ 無額外套件依賴
- ❌ 程式碼較多，容易出錯

---

## 方案 B：BlockingCollection\<T\>（.NET 內建）

更簡潔的方案，適合生產環境。

```csharp
public class CommandDispatcher : IDisposable
{
    private readonly BlockingCollection<string> _queue = new(
        new ConcurrentQueue<string>());

    private readonly CancellationTokenSource _cts = new();
    private readonly Task _consumer;

    public CommandDispatcher()
    {
        _consumer = Task.Run(StartConsumerLoop);
    }

    public void EnqueueCommand(string cmd)
    {
        _queue.Add(cmd);
    }

    private void StartConsumerLoop()
    {
        foreach (var cmd in _queue.GetConsumingEnumerable(_cts.Token))
        {
            SendCommand(cmd);
        }
    }

    private void SendCommand(string cmd)
    {
        Console.WriteLine($"[Send] {cmd}");
    }

    public void Dispose()
    {
        _queue.CompleteAdding();
        _cts.Cancel();
        _consumer.Wait(TimeSpan.FromSeconds(5));
    }
}
```

**優缺點：**
- ✅ 內建於 .NET，穩定可靠
- ✅ 程式碼簡潔
- ✅ 支援 CancellationToken
- ❌ 仍有 Heap 配置（ConcurrentQueue 內部節點）

---

## 方案 C：Channel\<T\>（Zero-allocation 首選 ✅）

最新、最高效的方案，面試官最想聽到的答案。

```csharp
public class CommandDispatcher : IDisposable
{
    private readonly Channel<string> _channel;
    private readonly CancellationTokenSource _cts = new();
    private readonly Task _consumer;

    public CommandDispatcher(int capacity = 256)
    {
        // 使用有界 Channel，避免無限制成長
        var options = new BoundedChannelOptions(capacity)
        {
            FullMode = BoundedChannelFullMode.Wait,
            SingleReader = true,  // 只有一個消費者
            SingleWriter = false  // 多個生產者
        };

        _channel = Channel.CreateBounded<string>(options);
        _consumer = Task.Run(() => StartConsumerLoopAsync(_cts.Token));
    }

    public void EnqueueCommand(string cmd)
    {
        // 同步寫入（但 Channel 底層使用高效 Signal）
        while (!_channel.Writer.TryWrite(cmd))
        {
            // 佇列已滿，等待
            Thread.SpinWait(1);
        }
    }

    private async Task StartConsumerLoopAsync(CancellationToken token)
    {
        var reader = _channel.Reader;

        await foreach (var cmd in reader.ReadAllAsync(token))
        {
            SendCommand(cmd);
        }
    }

    private void SendCommand(string cmd)
    {
        // 模擬透過 TCP/IP 發送
        Console.WriteLine($"[Send] {cmd}");
    }

    public void Dispose()
    {
        _channel.Writer.TryComplete();
        _cts.Cancel();
        _consumer.Wait(TimeSpan.FromSeconds(5));
    }
}
```

**優缺點：**
- ✅ **Zero-allocation** — 底層使用 Ring Buffer，無 GC 壓力 ✅
- ✅ 支援 Async/Await 完美整合
- ✅ 有界（Bounded）模式避免無限成長
- ✅ .NET Core / .NET 5+ 標準內建
- ❌ 需要熟悉 Channel API

---

## 時間/空間複雜度

| 操作 | 複雜度 |
|------|--------|
| Enqueue | **O(1)** — 攤銷 |
| Dequeue | **O(1)** |
| 空間 | **O(capacity)** — 有界佇列 |

## 面試重點提示

| 問題 | 回答方向 |
|------|---------|
| 為什麼不用 Busy-waiting？ | 浪費 CPU、增加功耗、影響其他執行緒 |
| Wait/Pulse 如何避免 Lost-wakeup？ | 在 lock 內呼叫 Wait，確保 Pulse 不會遺失 |
| `volatile` 關鍵字的作用？ | 確保 `_running` 的寫入對其他執行緒可見 |
| Channel vs BlockingCollection？ | Channel 支援 async、Zero-allocation、Ring Buffer |
| 如何避免記憶體無限制成長？ | 使用 **有界（Bounded）Channel**，滿時生產者等待 |
| 生產環境中如何監控？ | 加入 `Count` 屬性監控佇列深度、警報 |

> 💡 **面試小提示**：這題的重點不在於是否能寫出完美程式碼，而在於你能否：
> 1. 識別出 Race Condition 與 Deadlock 的風險
> 2. 提出多種方案並比較取捨（Trade-off）
> 3. 展現對現代 C# 並發 API（Channel）的掌握度
> 
> 口頭回答時，先從最簡單的 `lock + Monitor` 開始，再提到 `BlockingCollection`，最後說出最佳實踐 `Channel<T>` — 這會讓面試官印象深刻。
