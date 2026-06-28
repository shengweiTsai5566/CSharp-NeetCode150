using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class MinCostToConnectAllPointsTests
{
    private readonly MinCostToConnectAllPoints _solver = new();

    [Fact]
    public void Solve_Example1_Returns20()
    {
        int[][] points = [[0, 0], [2, 2], [3, 10], [5, 2], [7, 0]];
        Assert.Equal(20, _solver.Solve(points));
    }

    [Fact]
    public void Solve_Example2_Returns18()
    {
        int[][] points = [[3, 12], [-2, 5], [-4, 1]];
        Assert.Equal(18, _solver.Solve(points));
    }

    [Fact]
    public void Solve_TwoPoints_ReturnsManhattan()
    {
        int[][] points = [[0, 0], [1, 1]];
        Assert.Equal(2, _solver.Solve(points));
    }

    [Fact]
    public void Solve_SinglePoint_Returns0()
    {
        int[][] points = [[0, 0]];
        Assert.Equal(0, _solver.Solve(points));
    }
}
