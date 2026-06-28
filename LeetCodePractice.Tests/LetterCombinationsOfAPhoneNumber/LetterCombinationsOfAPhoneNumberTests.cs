using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class LetterCombinationsOfAPhoneNumberTests
{
    private readonly LetterCombinationsOfAPhoneNumber _solver = new();

    [Fact]
    public void Solve_Example1_23_Returns9Combos()
    {
        var result = _solver.Solve("23");
        Assert.Equal(9, result.Count);
        Assert.Contains("ad", result);
        Assert.Contains("ae", result);
        Assert.Contains("af", result);
        Assert.Contains("bd", result);
        Assert.Contains("be", result);
        Assert.Contains("bf", result);
        Assert.Contains("cd", result);
        Assert.Contains("ce", result);
        Assert.Contains("cf", result);
    }

    [Fact]
    public void Solve_Example2_Empty_ReturnsEmpty()
    {
        Assert.Empty(_solver.Solve(""));
    }

    [Fact]
    public void Solve_Example3_2_ReturnsABC()
    {
        var result = _solver.Solve("2");
        Assert.Equal(3, result.Count);
        Assert.Contains("a", result);
        Assert.Contains("b", result);
        Assert.Contains("c", result);
    }

    [Fact]
    public void Solve_234_Returns27Combos()
    {
        var result = _solver.Solve("234");
        Assert.Equal(27, result.Count);
    }
}
