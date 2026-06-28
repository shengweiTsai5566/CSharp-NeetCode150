using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class WordSearchIITests
{
    private readonly WordSearchII _solver = new();

    [Fact]
    public void Solve_Example1_ReturnsEat_Oath()
    {
        char[][] board = [['o','a','a','n'],['e','t','a','e'],['i','h','k','r'],['i','f','l','v']];
        var words = new string[] {"oath","pea","eat","rain"};
        var result = _solver.Solve(board, words);
        Assert.Contains("eat", result);
        Assert.Contains("oath", result);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void Solve_Example2_ReturnsEmpty()
    {
        char[][] board = [['a','b'],['c','d']];
        var result = _solver.Solve(board, new string[] {"abcb"});
        Assert.Empty(result);
    }

    [Fact]
    public void Solve_FindMultiple_ReturnsAll()
    {
        char[][] board = [['a','b'],['c','d']];
        var words = new string[] {"ab","ac","bd","cd"};
        var result = _solver.Solve(board, words);
        Assert.Equal(4, result.Count);
    }

    [Fact]
    public void Solve_EmptyBoard_ReturnsEmpty()
    {
        Assert.Empty(_solver.Solve([[]], new string[] {"a"}));
    }
}

