using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class SwimInRisingWaterTests
{
    private readonly SwimInRisingWater _solver = new();

    [Fact]
    public void Solve_Example1_Returns16()
    {
        int[][] grid = [[0, 2], [1, 3]];
        Assert.Equal(3, _solver.Solve(grid));
    }

    [Fact]
    public void Solve_Example2_Returns16()
    {
        int[][] grid = [
            [0, 1, 2, 3, 4],
            [24, 23, 22, 21, 5],
            [12, 13, 14, 15, 16],
            [11, 17, 18, 19, 20],
            [10, 9, 8, 7, 6]
        ];
        Assert.Equal(16, _solver.Solve(grid));
    }

    [Fact]
    public void Solve_2x2_ReturnsCorrect()
    {
        int[][] grid = [[0, 1], [2, 3]];
        Assert.Equal(3, _solver.Solve(grid));
    }

    [Fact]
    public void Solve_SingleCell_Returns0()
    {
        int[][] grid = [[0]];
        Assert.Equal(0, _solver.Solve(grid));
    }
}
