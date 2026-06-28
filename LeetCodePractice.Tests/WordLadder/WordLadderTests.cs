using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class WordLadderTests
{
    private readonly WordLadder _solver = new();

    [Fact]
    public void Solve_Example1_Returns5()
    {
        var wordList = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };
        Assert.Equal(5, _solver.Solve("hit", "cog", wordList));
    }

    [Fact]
    public void Solve_Example2_Returns0()
    {
        var wordList = new List<string> { "hot", "dot", "dog", "lot", "log" };
        Assert.Equal(0, _solver.Solve("hit", "cog", wordList));
    }

    [Fact]
    public void Solve_SameWord_Returns1()
    {
        var wordList = new List<string> { "abc" };
        Assert.Equal(1, _solver.Solve("abc", "abc", wordList));
    }

    [Fact]
    public void Solve_EmptyWordList_Returns0()
    {
        Assert.Equal(0, _solver.Solve("hit", "cog", new List<string>()));
    }
}
