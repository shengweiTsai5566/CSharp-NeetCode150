using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class LongestIncreasingSubsequenceTests
{
    private readonly LongestIncreasingSubsequence _solver = new();

    [Fact]
    public void Solve_Example1_10_9_2_5_3_7_101_18_Returns4()
    {
        int[] nums = [10, 9, 2, 5, 3, 7, 101, 18];
        Assert.Equal(4, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_Example2_0_1_0_3_2_3_Returns4()
    {
        int[] nums = [0, 1, 0, 3, 2, 3];
        Assert.Equal(4, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_Example3_7_7_7_7_Returns1()
    {
        int[] nums = [7, 7, 7, 7];
        Assert.Equal(1, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_SingleElement_Returns1()
    {
        Assert.Equal(1, _solver.Solve([5]));
    }

    [Fact]
    public void Solve_StrictlyDecreasing_Returns1()
    {
        int[] nums = [5, 4, 3, 2, 1];
        Assert.Equal(1, _solver.Solve(nums));
    }
}
