using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class WordSearchTests
{
    private readonly WordSearch _solver = new();

    [Fact]
    public void Solve_Example1_ReturnsTrue()
    {
        char[][] board = [['A','B','C','E'],['S','F','C','S'],['A','D','E','E']];
        Assert.True(_solver.Solve(board, "ABCCED"));
    }

    [Fact]
    public void Solve_Example2_ReturnsTrue()
    {
        char[][] board = [['A','B','C','E'],['S','F','C','S'],['A','D','E','E']];
        Assert.True(_solver.Solve(board, "SEE"));
    }

    [Fact]
    public void Solve_Example3_ReturnsFalse()
    {
        char[][] board = [['A','B','C','E'],['S','F','C','S'],['A','D','E','E']];
        Assert.False(_solver.Solve(board, "ABCB"));
    }

    [Fact]
    public void Solve_SingleCharFound_ReturnsTrue()
    {
        char[][] board = [['X']];
        Assert.True(_solver.Solve(board, "X"));
    }

    [Fact]
    public void Solve_EmptyBoard_ReturnsFalse()
    {
        Assert.False(_solver.Solve([[]], "A"));
    }
}
