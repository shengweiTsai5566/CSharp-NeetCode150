using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class SurroundedRegionsTests
{
    private readonly SurroundedRegions _solver = new();

    [Fact]
    public void Solve_Example1_ReturnsCorrect()
    {
        char[][] board = [['X','X','X','X'],['X','O','O','X'],['X','X','O','X'],['X','O','X','X']];
        _solver.Solve(board);
        char[][] expected = [['X','X','X','X'],['X','X','X','X'],['X','X','X','X'],['X','O','X','X']];
        Assert.Equal(expected, board);
    }

    [Fact]
    public void Solve_Example2_AllX_NoChange()
    {
        char[][] board = [['X']];
        _solver.Solve(board);
        Assert.Equal(new char[][] { ['X'] }, board);
    }

    [Fact]
    public void Solve_BorderO_StaysO()
    {
        char[][] board = [['O','O'],['O','O']];
        _solver.Solve(board);
        Assert.Equal(new char[][] { ['O','O'],['O','O'] }, board);
    }

    [Fact]
    public void Solve_AllSurrounded_Converted()
    {
        char[][] board = [['X','X','X'],['X','O','X'],['X','X','X']];
        _solver.Solve(board);
        Assert.Equal(new char[][] { ['X','X','X'],['X','X','X'],['X','X','X'] }, board);
    }
}
