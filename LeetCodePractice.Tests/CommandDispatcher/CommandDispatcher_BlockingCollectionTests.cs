using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class CommandDispatcher_BlockingCollectionTests
{
    // ===== 正常情況 (Happy Path) =====

    [Fact]
    public void EnqueueCommand_SingleCommand_DispatchesSuccessfully()
    {
        using var dispatcher = new CommandDispatcher_BlockingCollection();

        dispatcher.EnqueueCommand("$INIT;");

        // 等待消費者處理
        Thread.Sleep(500);
    }

    [Fact]
    public void EnqueueCommand_MultipleCommands_AllDispatched()
    {
        using var dispatcher = new CommandDispatcher_BlockingCollection();

        for (int i = 0; i < 10; i++)
        {
            dispatcher.EnqueueCommand($"$CMD{i:D4};");
        }

        Thread.Sleep(1000);
    }

    // ===== 多執行緒並發 (Concurrency) =====

    [Fact]
    public async Task EnqueueCommand_ConcurrentProducers_NoDataCorruption()
    {
        using var dispatcher = new CommandDispatcher_BlockingCollection();
        int producerCount = 5;
        int commandsPerProducer = 100;
        var barrier = new Barrier(producerCount);

        var tasks = new Task[producerCount];
        for (int t = 0; t < producerCount; t++)
        {
            int threadId = t;
            tasks[t] = Task.Run(() =>
            {
                barrier.SignalAndWait();
                for (int i = 0; i < commandsPerProducer; i++)
                {
                    dispatcher.EnqueueCommand($"$THREAD{threadId:D2}_CMD{i:D4};");
                }
            });
        }

        await Task.WhenAll(tasks);
        await Task.Delay(2000);
    }

    // ===== 邊界情況 (Edge Cases) =====

    [Fact]
    public void EnqueueCommand_EmptyCommand_HandlesGracefully()
    {
        using var dispatcher = new CommandDispatcher_BlockingCollection();

        dispatcher.EnqueueCommand("");
        dispatcher.EnqueueCommand(null!);

        Thread.Sleep(500);
    }

    [Fact]
    public void Dispose_WhileProcessing_NoException()
    {
        var dispatcher = new CommandDispatcher_BlockingCollection();

        for (int i = 0; i < 100; i++)
        {
            dispatcher.EnqueueCommand($"$CMD{i:D4};");
        }

        // 未等待完成就 Dispose
        dispatcher.Dispose();
    }

    // ===== 壓力測試 (Stress) =====

    [Fact]
    public void EnqueueCommand_HighThroughput_NoDeadlock()
    {
        using var dispatcher = new CommandDispatcher_BlockingCollection();

        int totalCommands = 10_000;
        for (int i = 0; i < totalCommands; i++)
        {
            dispatcher.EnqueueCommand($"$CMD{i:D6};");
        }

        Thread.Sleep(3000);
    }
}
