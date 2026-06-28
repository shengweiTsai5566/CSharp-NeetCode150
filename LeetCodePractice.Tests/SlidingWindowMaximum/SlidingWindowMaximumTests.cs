using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class SlidingWindowMaximumTests
{
    private readonly SlidingWindowMaximum _solver = new();

    [Fact]
    public void Solve_Example1_Returns3_3_5_5_6_7()
    {
        int[] nums = [1, 3, -1, -3, 5, 3, 6, 7];
        Assert.Equal(new int[] { 3, 3, 5, 5, 6, 7 }, _solver.Solve(nums, 3));
    }

    [Fact]
    public void Solve_Example2_1_Returns1()
    {
        Assert.Equal(new int[] { 1 }, _solver.Solve([1], 1));
    }

    [Fact]
    public void Solve_KEqualsLength_ReturnsMax()
    {
        Assert.Equal(new int[] { 5 }, _solver.Solve([1, 3, 5], 3));
    }

    [Fact]
    public void Solve_AllSame_ReturnsSame()
    {
        Assert.Equal(new int[] { 2, 2, 2 }, _solver.Solve([2, 2, 2, 2, 2], 3));
    }
}
