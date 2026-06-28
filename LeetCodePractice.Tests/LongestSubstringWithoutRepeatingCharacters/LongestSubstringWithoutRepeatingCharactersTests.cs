using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class LongestSubstringWithoutRepeatingCharactersTests
{
    private readonly LongestSubstringWithoutRepeatingCharacters _solver = new();

    [Fact]
    public void Solve_Example1_abcabcbb_Returns3()
    {
        Assert.Equal(3, _solver.Solve("abcabcbb"));
    }

    [Fact]
    public void Solve_Example2_bbbbb_Returns1()
    {
        Assert.Equal(1, _solver.Solve("bbbbb"));
    }

    [Fact]
    public void Solve_Example3_pwwkew_Returns3()
    {
        Assert.Equal(3, _solver.Solve("pwwkew"));
    }

    [Fact]
    public void Solve_EmptyString_Returns0()
    {
        Assert.Equal(0, _solver.Solve(""));
    }

    [Fact]
    public void Solve_SingleChar_Returns1()
    {
        Assert.Equal(1, _solver.Solve("a"));
    }

    [Fact]
    public void Solve_AllUnique_ReturnsLength()
    {
        Assert.Equal(5, _solver.Solve("abcde"));
    }

    [Fact]
    public void Solve_Space_Returns1()
    {
        Assert.Equal(1, _solver.Solve(" "));
    }
}
