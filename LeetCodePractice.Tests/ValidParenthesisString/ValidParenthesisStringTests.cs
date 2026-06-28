using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class ValidParenthesisStringTests
{
    private readonly ValidParenthesisString _solver = new();

    [Fact]
    public void Solve_Example1_ReturnsTrue()
    {
        Assert.True(_solver.Solve("()"));
    }

    [Fact]
    public void Solve_Example2_ReturnsTrue()
    {
        Assert.True(_solver.Solve("(*)"));
    }

    [Fact]
    public void Solve_Example3_ReturnsTrue()
    {
        Assert.True(_solver.Solve("(*))"));
    }

    [Fact]
    public void Solve_Empty_ReturnsTrue()
    {
        Assert.True(_solver.Solve(""));
    }

    [Fact]
    public void Solve_OnlyStar_ReturnsTrue()
    {
        Assert.True(_solver.Solve("***"));
    }

    [Fact]
    public void Solve_Unmatched_ReturnsFalse()
    {
        Assert.False(_solver.Solve(")("));
    }
}
