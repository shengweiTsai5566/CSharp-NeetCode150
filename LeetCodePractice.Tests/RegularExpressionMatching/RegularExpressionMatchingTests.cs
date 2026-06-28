using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class RegularExpressionMatchingTests
{
    private readonly RegularExpressionMatching _solver = new();

    [Fact]
    public void Solve_Example1_AA_A_ReturnsFalse()
    {
        Assert.False(_solver.Solve("aa", "a"));
    }

    [Fact]
    public void Solve_Example2_AA_Star_ReturnsTrue()
    {
        Assert.True(_solver.Solve("aa", "a*"));
    }

    [Fact]
    public void Solve_Example3_Dot_ReturnsTrue()
    {
        Assert.True(_solver.Solve("ab", ".*"));
    }

    [Fact]
    public void Solve_ExactMatch_ReturnsTrue()
    {
        Assert.True(_solver.Solve("abc", "abc"));
    }

    [Fact]
    public void Solve_EmptyPattern_ReturnsFalse()
    {
        Assert.False(_solver.Solve("a", ""));
    }

    [Fact]
    public void Solve_BothEmpty_ReturnsTrue()
    {
        Assert.True(_solver.Solve("", ""));
    }

    [Fact]
    public void Solve_StarZeroMatch_ReturnsTrue()
    {
        Assert.True(_solver.Solve("", ".*"));
    }
}
