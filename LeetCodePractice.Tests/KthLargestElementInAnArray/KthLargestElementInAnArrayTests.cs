using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class KthLargestElementInAnArrayTests
{
    private readonly KthLargestElementInAnArray _solver = new();

    [Fact]
    public void Solve_Example1_3_2_1_5_6_4_K2_Returns5()
    {
        int[] nums = [3, 2, 1, 5, 6, 4];
        Assert.Equal(5, _solver.Solve(nums, 2));
    }

    [Fact]
    public void Solve_Example2_3_2_3_1_2_4_5_5_6_K4_Returns4()
    {
        int[] nums = [3, 2, 3, 1, 2, 4, 5, 5, 6];
        Assert.Equal(4, _solver.Solve(nums, 4));
    }

    [Fact]
    public void Solve_SingleElement_K1_ReturnsIt()
    {
        Assert.Equal(5, _solver.Solve([5], 1));
    }

    [Fact]
    public void Solve_Duplicates_ReturnsCorrect()
    {
        int[] nums = [2, 2, 2, 2];
        Assert.Equal(2, _solver.Solve(nums, 2));
    }
}
