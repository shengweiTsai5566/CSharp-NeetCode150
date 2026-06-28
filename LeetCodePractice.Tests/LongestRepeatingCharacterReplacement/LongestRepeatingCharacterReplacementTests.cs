using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class LongestRepeatingCharacterReplacementTests
{
    private readonly LongestRepeatingCharacterReplacement _solver = new();

    [Fact]
    public void Solve_Example1_ABAB_K2_Returns4()
    {
        Assert.Equal(4, _solver.Solve("ABAB", 2));
    }

    [Fact]
    public void Solve_Example2_AABABBA_K1_Returns4()
    {
        Assert.Equal(4, _solver.Solve("AABABBA", 1));
    }

    [Fact]
    public void Solve_SingleChar_Returns1()
    {
        Assert.Equal(1, _solver.Solve("A", 0));
    }

    [Fact]
    public void Solve_AllSame_ReturnsLength()
    {
        Assert.Equal(5, _solver.Solve("AAAAA", 2));
    }

    [Fact]
    public void Solve_EmptyString_Returns0()
    {
        Assert.Equal(0, _solver.Solve("", 1));
    }
}
