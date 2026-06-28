using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class ValidPalindromeTests
{
    private readonly ValidPalindrome _solver = new();

    [Fact]
    public void Solve_Example1_ReturnsTrue()
    {
        Assert.True(_solver.Solve("A man, a plan, a canal: Panama"));
    }

    [Fact]
    public void Solve_Example2_ReturnsFalse()
    {
        Assert.False(_solver.Solve("race a car"));
    }

    [Fact]
    public void Solve_Example3_Empty_ReturnsTrue()
    {
        Assert.True(_solver.Solve(" "));
    }

    [Fact]
    public void Solve_SingleChar_ReturnsTrue()
    {
        Assert.True(_solver.Solve("a"));
    }

    [Fact]
    public void Solve_AlphaNumeric_ReturnsTrue()
    {
        Assert.True(_solver.Solve("1b1"));
    }
}
