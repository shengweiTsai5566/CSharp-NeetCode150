using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace LeetCodePractice.Problems;

/// <summary>
/// 使用 BlockingCollection&lt;string&gt; 實作的執行緒安全命令調度器
/// 
/// BlockingCollection&lt;T&gt; 內部包裝 ConcurrentQueue&lt;T&gt;，
/// 自帶執行緒安全 + 阻塞等待功能，不需要手寫 lock / Monitor.Wait / Monitor.Pulse。
/// 
/// 面試重點：
/// - Add() = 執行緒安全入隊
/// - GetConsumingEnumerable() = 阻塞式消費，沒資料時自動等待
/// - CompleteAdding() = 通知消費者不再有新資料，foreach 自然結束
/// </summary>
public class CommandDispatcher_BlockingCollection : IDisposable
{
    private readonly BlockingCollection<string> _commandQueue = new();
    private readonly Task _consumerTask;

    public CommandDispatcher_BlockingCollection()
    {
        _consumerTask = Task.Run(StartConsumerLoop);
    }

    /// <summary>
    /// 生產者呼叫：將命令放入佇列（執行緒安全，不需 lock）
    /// </summary>
    public void EnqueueCommand(string cmd)
    {
        _commandQueue.Add(cmd);
    }

    /// <summary>
    /// 底層背景執行緒執行的工作（Consumer Loop）
    /// GetConsumingEnumerable 會阻塞等待，直到 CompleteAdding 被呼叫
    /// </summary>
    private void StartConsumerLoop()
    {
        foreach (var cmd in _commandQueue.GetConsumingEnumerable())
        {
            Console.WriteLine($"Sending command: {cmd}");
        }
    }

    public void Dispose()
    {
        _commandQueue.CompleteAdding();  // 通知消費者不再加資料
        _consumerTask.Wait();            // 等待 foreach 跑完
    }
}
