using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class MaximumProductSubarrayTests
{
    private readonly MaximumProductSubarray _solver = new();

    [Fact]
    public void Solve_Example1_2_3_Minus2_4_Returns6()
    {
        int[] nums = [2, 3, -2, 4];
        Assert.Equal(6, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_Example2_Minus2_0_Minus1_Returns0()
    {
        int[] nums = [-2, 0, -1];
        Assert.Equal(0, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_SingleNegative_ReturnsIt()
    {
        Assert.Equal(-2, _solver.Solve([-2]));
    }

    [Fact]
    public void Solve_TwoNegatives_ReturnsProduct()
    {
        Assert.Equal(6, _solver.Solve([-2, -3]));
    }

    [Fact]
    public void Solve_AllPositive_ReturnsTotal()
    {
        int[] nums = [1, 2, 3, 4];
        Assert.Equal(24, _solver.Solve(nums));
    }
}
