using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class ProductOfArrayExceptSelfTests
{
    private readonly ProductOfArrayExceptSelf _solver = new();

    [Fact]
    public void Solve_Example1_1_2_3_4_Returns24_12_8_6()
    {
        int[] nums = [1, 2, 3, 4];
        Assert.Equal(new int[] { 24, 12, 8, 6 }, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_Example2_Minus1_1_0_Minus3_3_Returns0_0_9_0_0()
    {
        int[] nums = [-1, 1, 0, -3, 3];
        Assert.Equal(new int[] { 0, 0, 9, 0, 0 }, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_TwoElements_ReturnsSwapped()
    {
        Assert.Equal(new int[] { 2, 1 }, _solver.Solve([1, 2]));
    }

    [Fact]
    public void Solve_AllOnes_ReturnsAllOnes()
    {
        Assert.Equal(new int[] { 1, 1, 1 }, _solver.Solve([1, 1, 1]));
    }
}
