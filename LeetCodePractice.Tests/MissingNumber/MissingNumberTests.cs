using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class MissingNumberTests
{
    private readonly MissingNumber _solver = new();

    [Fact]
    public void Solve_Example1_3_0_1_Returns2()
    {
        int[] nums = [3, 0, 1];
        Assert.Equal(2, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_Example2_0_1_Returns2()
    {
        int[] nums = [0, 1];
        Assert.Equal(2, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_Example3_9_6_4_2_3_5_7_0_1_Returns8()
    {
        int[] nums = [9, 6, 4, 2, 3, 5, 7, 0, 1];
        Assert.Equal(8, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_SingleElement0_Returns1()
    {
        Assert.Equal(1, _solver.Solve([0]));
    }

    [Fact]
    public void Solve_NoMissing_ReturnsNext()
    {
        int[] nums = [0, 1, 2];
        Assert.Equal(3, _solver.Solve(nums));
    }
}
