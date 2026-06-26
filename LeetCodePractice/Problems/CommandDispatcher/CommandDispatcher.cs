using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCodePractice.Problems;

/// <summary>
/// 執行緒安全命令發送佇列（Thread-Safe Command Queue）
/// 對應 LeetCode：Concurrency 實作題（Producer-Consumer Pattern）
/// 
/// 面試情境：
/// 當多個控制邏輯執行緒（安全監控、路徑規劃、UI）同時想對同一個
/// TCP/IP Socket 發送控制命令時，若無適當同步機制，會導致資料錯亂或 Deadlock。
/// 
/// 題目描述：
/// 實作一個執行緒安全的命令調度器 CommandDispatcher。
/// 多個生產者可以同時呼叫 EnqueueCommand 投放指令，
/// 底層只有一個專屬的通訊執行緒（Consumer）負責取出並發送。
/// 當佇列沒資料時，消費執行緒必須高效掛起（Wait），不能 Busy-waiting。
/// 
/// 面試要求：
/// 1. 口頭說明如何使用 Monitor (lock) + Wait / Pulse 實作
/// 2. 進階使用 .NET 內建 BlockingCollection&lt;T&gt; 或 Channel&lt;T&gt;（Zero-allocation 首選）
/// </summary>
public class CommandDispatcher : IDisposable
{
    // TODO: 請實作一個執行緒安全的生產者消費者模式
    //
    // 選項 A：使用 Monitor (lock) + Queue<string> + Wait/Pulse
    // 選項 B：使用 BlockingCollection<string> (包裝 ConcurrentQueue)
    // 選項 C（進階）：使用 System.Threading.Channels.Channel<string>（Zero-allocation 首選）

    public CommandDispatcher()
    {
        // TODO: 啟動背景消費執行緒
        throw new NotImplementedException();
    }

    /// <summary>
    /// 生產者呼叫：將命令放入佇列
    /// </summary>
    public void EnqueueCommand(string cmd)
    {
        // TODO: 執行緒安全地加入佇列，並通知消費執行緒
        throw new NotImplementedException();
    }

    /// <summary>
    /// 底層背景執行緒執行的工作（Consumer Loop）
    /// </summary>
    private void StartConsumerLoop()
    {
        // TODO: 從佇列取出命令並「發送」（此處用 Console.WriteLine 模擬）
        // 當佇列為空時，應高效等待（Wait / BlockingCollection.Take / Channel.Reader.WaitToReadAsync）
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        // TODO: 通知消費執行緒結束，等待完成
        throw new NotImplementedException();
    }
}
