using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class LongestPalindromicSubstringTests
{
    private readonly LongestPalindromicSubstring _solver = new();

    [Fact]
    public void Solve_Example1_Babad_ReturnsBabOrAba()
    {
        var result = _solver.Solve("babad");
        Assert.True(result == "bab" || result == "aba");
    }

    [Fact]
    public void Solve_Example2_Cbbd_ReturnsBb()
    {
        Assert.Equal("bb", _solver.Solve("cbbd"));
    }

    [Fact]
    public void Solve_SingleChar_ReturnsIt()
    {
        Assert.Equal("a", _solver.Solve("a"));
    }

    [Fact]
    public void Solve_TwoSame_ReturnsBoth()
    {
        Assert.Equal("aa", _solver.Solve("aa"));
    }

    [Fact]
    public void Solve_AllPalindrome_ReturnsFull()
    {
        Assert.Equal("abcba", _solver.Solve("abcba"));
    }

    [Fact]
    public void Solve_EmptyString_ReturnsEmpty()
    {
        Assert.Equal("", _solver.Solve(""));
    }
}
