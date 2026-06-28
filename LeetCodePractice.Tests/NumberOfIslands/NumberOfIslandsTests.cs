using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class NumberOfIslandsTests
{
    private readonly NumberOfIslands _solver = new();

    [Fact]
    public void Solve_Example1_Returns1()
    {
        char[][] grid = [
            ['1','1','1','1','0'],
            ['1','1','0','1','0'],
            ['1','1','0','0','0'],
            ['0','0','0','0','0']
        ];
        Assert.Equal(1, _solver.Solve(grid));
    }

    [Fact]
    public void Solve_Example2_Returns3()
    {
        char[][] grid = [
            ['1','1','0','0','0'],
            ['1','1','0','0','0'],
            ['0','0','1','0','0'],
            ['0','0','0','1','1']
        ];
        Assert.Equal(3, _solver.Solve(grid));
    }

    [Fact]
    public void Solve_AllWater_Returns0()
    {
        char[][] grid = [['0', '0'], ['0', '0']];
        Assert.Equal(0, _solver.Solve(grid));
    }

    [Fact]
    public void Solve_SingleIsland_Returns1()
    {
        char[][] grid = [['1']];
        Assert.Equal(1, _solver.Solve(grid));
    }

    [Fact]
    public void Solve_Empty_Returns0()
    {
        Assert.Equal(0, _solver.Solve([[]]));
    }
}
