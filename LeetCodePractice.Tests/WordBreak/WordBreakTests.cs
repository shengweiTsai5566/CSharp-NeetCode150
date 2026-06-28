using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class WordBreakTests
{
    private readonly WordBreak _solver = new();

    [Fact]
    public void Solve_Example1_ReturnsTrue()
    {
        Assert.True(_solver.Solve("leetcode", new List<string> { "leet", "code" }));
    }

    [Fact]
    public void Solve_Example2_ReturnsTrue()
    {
        Assert.True(_solver.Solve("applepenapple", new List<string> { "apple", "pen" }));
    }

    [Fact]
    public void Solve_Example3_ReturnsFalse()
    {
        Assert.False(_solver.Solve("catsandog", new List<string> { "cats", "dog", "sand", "and", "cat" }));
    }

    [Fact]
    public void Solve_EmptyString_ReturnsTrue()
    {
        Assert.True(_solver.Solve("", new List<string> { "a", "b" }));
    }

    [Fact]
    public void Solve_EmptyDict_ReturnsFalse()
    {
        Assert.False(_solver.Solve("abc", new List<string>()));
    }
}
