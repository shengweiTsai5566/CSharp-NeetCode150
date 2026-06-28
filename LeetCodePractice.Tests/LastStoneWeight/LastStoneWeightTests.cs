using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class LastStoneWeightTests
{
    private readonly LastStoneWeight _solver = new();

    [Fact]
    public void Solve_Example1_2_7_4_1_8_1_Returns1()
    {
        int[] stones = [2, 7, 4, 1, 8, 1];
        Assert.Equal(1, _solver.Solve(stones));
    }

    [Fact]
    public void Solve_Example2_1_Returns1()
    {
        Assert.Equal(1, _solver.Solve([1]));
    }

    [Fact]
    public void Solve_TwoEqual_Returns0()
    {
        Assert.Equal(0, _solver.Solve([5, 5]));
    }

    [Fact]
    public void Solve_TwoDifferent_ReturnsDiff()
    {
        Assert.Equal(3, _solver.Solve([5, 2]));
    }

    [Fact]
    public void Solve_AllDestroyed_Returns0()
    {
        Assert.Equal(0, _solver.Solve([2, 2, 2, 2]));
    }
}
