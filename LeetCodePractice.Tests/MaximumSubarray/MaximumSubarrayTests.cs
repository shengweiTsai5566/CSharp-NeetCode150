using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class MaximumSubarrayTests
{
    private readonly MaximumSubarray _solver = new();

    [Fact]
    public void Solve_Example1_Minus2_1_Minus3_4_Minus1_2_1_Minus5_4_Returns6()
    {
        int[] nums = [-2, 1, -3, 4, -1, 2, 1, -5, 4];
        Assert.Equal(6, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_Example2_1_Returns1()
    {
        Assert.Equal(1, _solver.Solve([1]));
    }

    [Fact]
    public void Solve_Example3_5_4_Minus1_7_8_Returns23()
    {
        int[] nums = [5, 4, -1, 7, 8];
        Assert.Equal(23, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_AllNegative_ReturnsMax()
    {
        int[] nums = [-5, -2, -8, -1];
        Assert.Equal(-1, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_AllPositive_ReturnsSum()
    {
        int[] nums = [1, 2, 3, 4];
        Assert.Equal(10, _solver.Solve(nums));
    }
}
