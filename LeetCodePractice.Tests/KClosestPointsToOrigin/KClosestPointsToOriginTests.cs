using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class KClosestPointsToOriginTests
{
    private readonly KClosestPointsToOrigin _solver = new();

    [Fact]
    public void Solve_Example1_Returns2Closest()
    {
        int[][] points = [[1, 3], [-2, 2]];
        var result = _solver.Solve(points, 1);
        Assert.Single(result);
        Assert.Equal(new int[] { -2, 2 }, result[0]);
    }

    [Fact]
    public void Solve_Example2_Returns3Closest()
    {
        int[][] points = [[3, 3], [5, -1], [-2, 4]];
        var result = _solver.Solve(points, 2);
        Assert.Equal(2, result.Length);
    }

    [Fact]
    public void Solve_AllPoints_ReturnsAll()
    {
        int[][] points = [[0, 1], [1, 0]];
        var result = _solver.Solve(points, 2);
        Assert.Equal(2, result.Length);
    }

    [Fact]
    public void Solve_ZeroPoints_ReturnsEmpty()
    {
        var result = _solver.Solve([], 0);
        Assert.Empty(result);
    }
}
