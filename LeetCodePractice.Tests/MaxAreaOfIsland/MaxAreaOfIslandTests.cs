using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class MaxAreaOfIslandTests
{
    private readonly MaxAreaOfIsland _solver = new();

    [Fact]
    public void Solve_Example1_Returns6()
    {
        int[][] grid = [
            [0,0,1,0,0,0,0,1,0,0,0,0,0],
            [0,0,0,0,0,0,0,1,1,1,0,0,0],
            [0,1,1,0,1,0,0,0,0,0,0,0,0],
            [0,1,0,0,1,1,0,0,1,0,1,0,0],
            [0,1,0,0,1,1,0,0,1,1,1,0,0],
            [0,0,0,0,0,0,0,0,0,0,1,0,0],
            [0,0,0,0,0,0,0,1,1,1,0,0,0],
            [0,0,0,0,0,0,0,1,1,0,0,0,0]
        ];
        Assert.Equal(6, _solver.Solve(grid));
    }

    [Fact]
    public void Solve_Example2_AllZero_Returns0()
    {
        int[][] grid = [[0, 0, 0, 0, 0]];
        Assert.Equal(0, _solver.Solve(grid));
    }

    [Fact]
    public void Solve_SingleCellIsland_Returns1()
    {
        int[][] grid = [[1]];
        Assert.Equal(1, _solver.Solve(grid));
    }

    [Fact]
    public void Solve_MultipleIslands_ReturnsMax()
    {
        int[][] grid = [
            [1, 0, 2],
            [1, 0, 2],
            [0, 0, 2]
        ];
        Assert.Equal(3, _solver.Solve(grid));
    }

    [Fact]
    public void Solve_EmptyGrid_Returns0()
    {
        Assert.Equal(0, _solver.Solve([[]]));
    }
}
