using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class PacificAtlanticWaterFlowTests
{
    private readonly PacificAtlanticWaterFlow _solver = new();

    [Fact]
    public void Solve_Example1_Returns4Cells()
    {
        int[][] heights = [[1, 2, 2, 3, 5], [3, 2, 3, 4, 4], [2, 4, 5, 3, 1], [6, 7, 1, 4, 5], [5, 1, 1, 2, 4]];
        var result = _solver.Solve(heights);
        Assert.Equal(7, result.Count);
    }

    [Fact]
    public void Solve_Example2_SingleCell_ReturnsIt()
    {
        int[][] heights = [[1]];
        var result = _solver.Solve(heights);
        Assert.Single(result);
        Assert.Equal(new List<int> { 0, 0 }, result[0]);
    }

    [Fact]
    public void Solve_AllSame_ReturnsAll()
    {
        int[][] heights = [[1, 1], [1, 1]];
        var result = _solver.Solve(heights);
        Assert.Equal(4, result.Count);
    }
}
