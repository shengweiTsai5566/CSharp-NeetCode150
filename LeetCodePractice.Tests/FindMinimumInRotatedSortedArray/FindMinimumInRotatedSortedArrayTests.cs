using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class FindMinimumInRotatedSortedArrayTests
{
    private readonly FindMinimumInRotatedSortedArray _solver = new();

    [Fact]
    public void Solve_Example1_3_4_5_1_2_Returns1()
    {
        int[] nums = [3, 4, 5, 1, 2];
        Assert.Equal(1, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_Example2_4_5_6_7_0_1_2_Returns0()
    {
        int[] nums = [4, 5, 6, 7, 0, 1, 2];
        Assert.Equal(0, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_Example3_11_13_15_17_Returns11()
    {
        int[] nums = [11, 13, 15, 17];
        Assert.Equal(11, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_SingleElement_ReturnsIt()
    {
        Assert.Equal(5, _solver.Solve([5]));
    }

    [Fact]
    public void Solve_TwoElementsRotated_ReturnsMin()
    {
        Assert.Equal(1, _solver.Solve([2, 1]));
    }
}
