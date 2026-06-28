using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class LongestConsecutiveSequenceTests
{
    private readonly LongestConsecutiveSequence _solver = new();

    [Fact]
    public void Solve_Example1_100_4_200_1_3_2_Returns4()
    {
        int[] nums = [100, 4, 200, 1, 3, 2];
        Assert.Equal(4, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_Example2_0_3_7_2_5_8_4_6_0_1_Returns9()
    {
        int[] nums = [0, 3, 7, 2, 5, 8, 4, 6, 0, 1];
        Assert.Equal(9, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_EmptyArray_Returns0()
    {
        Assert.Equal(0, _solver.Solve([]));
    }

    [Fact]
    public void Solve_NoConsecutive_Returns1()
    {
        int[] nums = [1, 3, 5, 7];
        Assert.Equal(1, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_NegativeNumbers_ReturnsCorrect()
    {
        int[] nums = [-1, -2, -3, 0, 1];
        Assert.Equal(5, _solver.Solve(nums));
    }
}
