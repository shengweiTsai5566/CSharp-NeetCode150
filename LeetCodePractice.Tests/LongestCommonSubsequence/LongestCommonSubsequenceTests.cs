using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class LongestCommonSubsequenceTests
{
    private readonly LongestCommonSubsequence _solver = new();

    [Fact]
    public void Solve_Example1_abcde_ace_Returns3()
    {
        Assert.Equal(3, _solver.Solve("abcde", "ace"));
    }

    [Fact]
    public void Solve_Example2_abc_abc_Returns3()
    {
        Assert.Equal(3, _solver.Solve("abc", "abc"));
    }

    [Fact]
    public void Solve_Example3_abc_def_Returns0()
    {
        Assert.Equal(0, _solver.Solve("abc", "def"));
    }

    [Fact]
    public void Solve_OneEmpty_Returns0()
    {
        Assert.Equal(0, _solver.Solve("abc", ""));
    }

    [Fact]
    public void Solve_Reversed_Returns1()
    {
        Assert.Equal(1, _solver.Solve("abc", "cba"));
    }
}
