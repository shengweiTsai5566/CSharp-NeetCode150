using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class TwoSumTests
{
    private readonly TwoSum _solver = new();

    // ===== 正常情況 (Happy Path) =====

    [Fact]
    public void Solve_Example1_ReturnsCorrectIndices()
    {
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;

        int[] result = _solver.Solve(nums, target);

        Assert.Equal(2, result.Length);
        Assert.Contains(0, result);
        Assert.Contains(1, result);
    }

    [Fact]
    public void Solve_Example2_NumbersNotAtStart_ReturnsCorrectIndices()
    {
        int[] nums = { 3, 2, 4 };
        int target = 6;

        int[] result = _solver.Solve(nums, target);

        Assert.Equal(2, result.Length);
        Assert.Contains(1, result);
        Assert.Contains(2, result);
    }

    [Fact]
    public void Solve_Example3_DuplicateValues_ReturnsCorrectIndices()
    {
        int[] nums = { 3, 3 };
        int target = 6;

        int[] result = _solver.Solve(nums, target);

        Assert.Equal(2, result.Length);
        Assert.Contains(0, result);
        Assert.Contains(1, result);
    }

    // ===== 邊界情況 (Edge Cases) =====

    [Fact]
    public void Solve_NegativeNumbers_WorksCorrectly()
    {
        int[] nums = { -1, -2, -3, -4, -5 };
        int target = -8;

        int[] result = _solver.Solve(nums, target);

        // TODO: 補上預期值
        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
        // Assert.Equal(2, result[0]);
        // Assert.Equal(4, result[1]);
    }

    [Fact]
    public void Solve_TargetIsZero_WorksCorrectly()
    {
        int[] nums = { 0, 4, 3, 0 };
        int target = 0;

        int[] result = _solver.Solve(nums, target);

        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
        // TODO: 應回傳包含 0 的索引
    }

    [Fact]
    public void Solve_MinimumLengthInput_WorksCorrectly()
    {
        int[] nums = { 5, 5 };
        int target = 10;

        int[] result = _solver.Solve(nums, target);

        Assert.Equal(2, result.Length);
        Assert.Contains(0, result);
        Assert.Contains(1, result);
    }

    // ===== 邊界值 (Boundary Conditions) =====

    [Fact]
    public void Solve_LargeValues_DoesNotOverflow()
    {
        int[] nums = { 1_000_000_000, 999_999_999 };
        int target = 1_999_999_999;

        int[] result = _solver.Solve(nums, target);

        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
    }

    [Fact]
    public void Solve_TargetAtExtremeRange_WorksCorrectly()
    {
        int[] nums = { -1_000_000_000, 1_000_000_000 };
        int target = 0;

        int[] result = _solver.Solve(nums, target);

        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
    }

    // ===== 壓力測試 (Stress) =====

    [Fact]
    public void Solve_LargeInput_CompletesQuickly()
    {
        var nums = new int[10_000];
        for (int i = 0; i < 10_000; i++)
        {
            nums[i] = i;
        }
        int target = 19_997; // nums[9998] + nums[9999] = 19997

        int[] result = _solver.Solve(nums, target);

        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
    }

    [Fact]
    public void Solve_FirstAndLastElement_ReturnsCorrectIndices()
    {
        int[] nums = { 10, 20, 30, 40, 50, 5 };
        int target = 15;

        int[] result = _solver.Solve(nums, target);

        // TODO: 補上預期值 — 10 + 5 = 15 → [0, 5]
        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
    }
}
