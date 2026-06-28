using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class MinCostClimbingStairsTests
{
    private readonly MinCostClimbingStairs _solver = new();

    [Fact]
    public void Solve_Example1_10_15_20_Returns15()
    {
        int[] cost = [10, 15, 20];
        Assert.Equal(15, _solver.Solve(cost));
    }

    [Fact]
    public void Solve_Example2_1_100_1_1_1_100_1_1_100_1_Returns6()
    {
        int[] cost = [1, 100, 1, 1, 1, 100, 1, 1, 100, 1];
        Assert.Equal(6, _solver.Solve(cost));
    }

    [Fact]
    public void Solve_TwoElements_ReturnsMin()
    {
        Assert.Equal(5, _solver.Solve([5, 10]));
    }

    [Fact]
    public void Solve_ThreeElements_ReturnsMin()
    {
        Assert.Equal(2, _solver.Solve([1, 2, 2]));
    }
}
