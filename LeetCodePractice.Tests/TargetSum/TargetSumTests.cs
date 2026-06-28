using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class TargetSumTests
{
    private readonly TargetSum _solver = new();

    [Fact]
    public void Solve_Example1_1_1_1_1_1_Target3_Returns5()
    {
        int[] nums = [1, 1, 1, 1, 1];
        Assert.Equal(5, _solver.Solve(nums, 3));
    }

    [Fact]
    public void Solve_Example2_1_Target1_Returns1()
    {
        Assert.Equal(1, _solver.Solve([1], 1));
    }

    [Fact]
    public void Solve_AllSameZeroTarget_Returns0()
    {
        int[] nums = [1, 1];
        Assert.Equal(0, _solver.Solve(nums, 0));
    }

    [Fact]
    public void Solve_Empty_Returns1()
    {
        Assert.Equal(1, _solver.Solve([], 0));
    }
}
