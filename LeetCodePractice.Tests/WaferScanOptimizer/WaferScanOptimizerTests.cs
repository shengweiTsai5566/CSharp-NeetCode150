using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class WaferScanOptimizerTests
{
    private readonly WaferScanOptimizer _solver = new();

    // ===== 正常情況 (Happy Path) =====

    [Fact]
    public void MergeScanZones_MergeOverlappingIntervals_ReturnsMergedResult()
    {
        // TODO: 補上正確的預期值
        var intervals = new List<ScanInterval>
        {
            new(1, 3),
            new(2, 6),
            new(8, 10),
            new(15, 18)
        };

        var result = _solver.MergeScanZones(intervals);

        // Assert.Equal(3, result.Count);
        // Assert.Equal(1, result[0].StartX);
        // Assert.Equal(6, result[0].EndX);
    }

    [Fact]
    public void MergeScanZones_NoOverlap_ReturnsSameIntervals()
    {
        var intervals = new List<ScanInterval>
        {
            new(1, 2),
            new(3, 4),
            new(5, 6)
        };

        var result = _solver.MergeScanZones(intervals);

        // TODO: 補上預期值 — 應回傳相同數量的區間
    }

    [Fact]
    public void MergeScanZones_AllOverlap_ReturnsSingleInterval()
    {
        var intervals = new List<ScanInterval>
        {
            new(1, 10),
            new(2, 5),
            new(3, 8),
            new(4, 6)
        };

        var result = _solver.MergeScanZones(intervals);

        // TODO: 回傳應只有一個區間 [1, 10]
    }

    // ===== 邊界情況 (Edge Cases) =====

    [Fact]
    public void MergeScanZones_SingleInterval_ReturnsSameInterval()
    {
        var intervals = new List<ScanInterval> { new(5, 10) };

        var result = _solver.MergeScanZones(intervals);

        // TODO: 應回傳相同單一區間
        Assert.Single(result);
        Assert.Equal(5, result[0].StartX);
        Assert.Equal(10, result[0].EndX);
    }

    [Fact]
    public void MergeScanZones_NullInput_ReturnsEmptyList()
    {
        var result = _solver.MergeScanZones(null!);

        // TODO: 根據實作確認回傳值
        Assert.NotNull(result);
        // Assert.Empty(result);
    }

    [Fact]
    public void MergeScanZones_EmptyList_ReturnsEmptyList()
    {
        var intervals = new List<ScanInterval>();

        var result = _solver.MergeScanZones(intervals);

        Assert.NotNull(result);
        Assert.Empty(result);
    }

    // ===== 邊界條件 (Boundary Conditions) =====

    [Fact]
    public void MergeScanZones_TouchingIntervals_ShouldMerge()
    {
        // 相鄰區間 [1, 2] 和 [2, 3] 應合併為 [1, 3]
        var intervals = new List<ScanInterval>
        {
            new(1, 2),
            new(2, 3),
            new(4, 5)
        };

        var result = _solver.MergeScanZones(intervals);

        // TODO: 補上預期值
    }

    [Fact]
    public void MergeScanZones_NegativeValues_HandlesCorrectly()
    {
        var intervals = new List<ScanInterval>
        {
            new(-10, -5),
            new(-8, -3),
            new(0, 5)
        };

        var result = _solver.MergeScanZones(intervals);

        // TODO: 補上預期值
    }

    // ===== 無效與特殊輸入 (Invalid / Special Inputs) =====

    [Fact]
    public void MergeScanZones_UnorderedInput_StillMergesCorrectly()
    {
        var intervals = new List<ScanInterval>
        {
            new(8, 10),
            new(1, 3),
            new(15, 18),
            new(2, 6)
        };

        var result = _solver.MergeScanZones(intervals);

        // TODO: 補上預期值
    }

    [Fact]
    public void MergeScanZones_IdenticalIntervals_ReturnsSingle()
    {
        var intervals = new List<ScanInterval>
        {
            new(5, 10),
            new(5, 10),
            new(5, 10)
        };

        var result = _solver.MergeScanZones(intervals);

        // TODO: 應回傳一個區間 [5, 10]
    }

    // ===== 壓力測試 (Stress / Large Data) =====

    [Fact]
    public void MergeScanZones_LargeInput_DoesNotThrow()
    {
        var intervals = new List<ScanInterval>(10000);
        for (int i = 0; i < 10000; i++)
        {
            intervals.Add(new ScanInterval(i * 2, i * 2 + 1));
        }

        var result = _solver.MergeScanZones(intervals);

        // TODO: 補上驗證邏輯
        Assert.NotNull(result);
    }
}
