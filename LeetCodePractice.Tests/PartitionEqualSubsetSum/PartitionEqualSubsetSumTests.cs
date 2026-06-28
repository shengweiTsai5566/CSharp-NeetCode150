using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class PartitionEqualSubsetSumTests
{
    private readonly PartitionEqualSubsetSum _solver = new();

    [Fact]
    public void Solve_Example1_1_5_11_5_ReturnsTrue()
    {
        int[] nums = [1, 5, 11, 5];
        Assert.True(_solver.Solve(nums));
    }

    [Fact]
    public void Solve_Example2_1_2_3_5_ReturnsFalse()
    {
        int[] nums = [1, 2, 3, 5];
        Assert.False(_solver.Solve(nums));
    }

    [Fact]
    public void Solve_SingleElement_ReturnsFalse()
    {
        Assert.False(_solver.Solve([1]));
    }

    [Fact]
    public void Solve_TwoEqual_ReturnsTrue()
    {
        Assert.True(_solver.Solve([1, 1]));
    }

    [Fact]
    public void Solve_Empty_ReturnsTrue()
    {
        Assert.True(_solver.Solve([]));
    }
}
