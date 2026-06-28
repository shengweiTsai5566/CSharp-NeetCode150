using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class MultiplyStringsTests
{
    private readonly MultiplyStrings _solver = new();

    [Fact]
    public void Solve_Example1_2_3_Returns6()
    {
        Assert.Equal("6", _solver.Solve("2", "3"));
    }

    [Fact]
    public void Solve_Example2_123_456_Returns56088()
    {
        Assert.Equal("56088", _solver.Solve("123", "456"));
    }

    [Fact]
    public void Solve_Zero_ReturnsZero()
    {
        Assert.Equal("0", _solver.Solve("0", "12345"));
    }

    [Fact]
    public void Solve_LargeNumbers_ReturnsCorrect()
    {
        Assert.Equal("121932631112635269", _solver.Solve("123456789", "987654321"));
    }

    [Fact]
    public void Solve_SingleDigit_ReturnsProduct()
    {
        Assert.Equal("81", _solver.Solve("9", "9"));
    }
}
