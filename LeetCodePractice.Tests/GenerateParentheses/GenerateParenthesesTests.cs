using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class GenerateParenthesesTests
{
    private readonly GenerateParentheses _solver = new();

    [Fact]
    public void Solve_Example1_n3_Returns5Combinations()
    {
        var result = _solver.Solve(3);
        Assert.Equal(5, result.Count);
        Assert.Contains("((()))", result);
        Assert.Contains("(()())", result);
        Assert.Contains("(())()", result);
        Assert.Contains("()(())", result);
        Assert.Contains("()()()", result);
    }

    [Fact]
    public void Solve_n1_Returns1()
    {
        var result = _solver.Solve(1);
        Assert.Single(result);
        Assert.Equal("()", result[0]);
    }

    [Fact]
    public void Solve_n2_Returns2()
    {
        var result = _solver.Solve(2);
        Assert.Equal(2, result.Count);
        Assert.Contains("(())", result);
        Assert.Contains("()()", result);
    }

    [Fact]
    public void Solve_n0_ReturnsEmpty()
    {
        var result = _solver.Solve(0);
        Assert.Single(result);
        Assert.Equal("", result[0]);
    }
}
