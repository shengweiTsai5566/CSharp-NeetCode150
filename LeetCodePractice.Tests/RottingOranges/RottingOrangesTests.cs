using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class RottingOrangesTests
{
    private readonly RottingOranges _solver = new();

    [Fact]
    public void Solve_Example1_Returns4()
    {
        int[][] grid = [[2, 1, 1], [1, 1, 0], [0, 1, 1]];
        Assert.Equal(4, _solver.Solve(grid));
    }

    [Fact]
    public void Solve_Example2_Impossible_ReturnsMinus1()
    {
        int[][] grid = [[2, 1, 1], [0, 1, 1], [1, 0, 1]];
        Assert.Equal(-1, _solver.Solve(grid));
    }

    [Fact]
    public void Solve_Example3_OnlyRotten_Returns0()
    {
        int[][] grid = [[0, 2]];
        Assert.Equal(0, _solver.Solve(grid));
    }

    [Fact]
    public void Solve_NoOranges_Returns0()
    {
        int[][] grid = [[0, 0], [0, 0]];
        Assert.Equal(0, _solver.Solve(grid));
    }
}
