using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class PalindromicSubstringsTests
{
    private readonly PalindromicSubstrings _solver = new();

    [Fact]
    public void Solve_Example1_abc_Returns3()
    {
        Assert.Equal(3, _solver.Solve("abc"));
    }

    [Fact]
    public void Solve_Example2_aaa_Returns6()
    {
        Assert.Equal(6, _solver.Solve("aaa"));
    }

    [Fact]
    public void Solve_SingleChar_Returns1()
    {
        Assert.Equal(1, _solver.Solve("a"));
    }

    [Fact]
    public void Solve_Empty_Returns0()
    {
        Assert.Equal(0, _solver.Solve(""));
    }

    [Fact]
    public void Solve_TwoSame_Returns3()
    {
        Assert.Equal(3, _solver.Solve("aa"));
    }
}
