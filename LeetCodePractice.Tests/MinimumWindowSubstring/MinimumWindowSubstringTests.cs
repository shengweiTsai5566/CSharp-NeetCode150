using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class MinimumWindowSubstringTests
{
    private readonly MinimumWindowSubstring _solver = new();

    [Fact]
    public void Solve_Example1_ADOBECODEBANC_ABC_ReturnsBANC()
    {
        Assert.Equal("BANC", _solver.Solve("ADOBECODEBANC", "ABC"));
    }

    [Fact]
    public void Solve_Example2_a_a_Returnsa()
    {
        Assert.Equal("a", _solver.Solve("a", "a"));
    }

    [Fact]
    public void Solve_Example3_a_aa_ReturnsEmpty()
    {
        Assert.Equal("", _solver.Solve("a", "aa"));
    }

    [Fact]
    public void Solve_NoMatch_ReturnsEmpty()
    {
        Assert.Equal("", _solver.Solve("abc", "def"));
    }

    [Fact]
    public void Solve_FullString_ReturnsFull()
    {
        Assert.Equal("abc", _solver.Solve("abc", "abc"));
    }
}
