using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class ValidParenthesesTests
{
    private readonly ValidParentheses _solver = new();

    [Fact]
    public void Solve_Example1_ReturnsTrue()
    {
        Assert.True(_solver.Solve("()"));
    }

    [Fact]
    public void Solve_Example2_ReturnsTrue()
    {
        Assert.True(_solver.Solve("()[]{}"));
    }

    [Fact]
    public void Solve_Example3_ReturnsFalse()
    {
        Assert.False(_solver.Solve("(]"));
    }

    [Fact]
    public void Solve_Nested_ReturnsTrue()
    {
        Assert.True(_solver.Solve("{[]}"));
    }

    [Fact]
    public void Solve_SingleOpen_ReturnsFalse()
    {
        Assert.False(_solver.Solve("("));
    }

    [Fact]
    public void Solve_Empty_ReturnsTrue()
    {
        Assert.True(_solver.Solve(""));
    }

    [Fact]
    public void Solve_WrongOrder_ReturnsFalse()
    {
        Assert.False(_solver.Solve("([)]"));
    }
}
