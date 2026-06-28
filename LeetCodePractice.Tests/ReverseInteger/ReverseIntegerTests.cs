using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class ReverseIntegerTests
{
    private readonly ReverseInteger _solver = new();

    [Fact]
    public void Solve_Example1_123_Returns321()
    {
        Assert.Equal(321, _solver.Solve(123));
    }

    [Fact]
    public void Solve_Example2_Minus123_ReturnsMinus321()
    {
        Assert.Equal(-321, _solver.Solve(-123));
    }

    [Fact]
    public void Solve_Example3_120_Returns21()
    {
        Assert.Equal(21, _solver.Solve(120));
    }

    [Fact]
    public void Solve_Overflow_Returns0()
    {
        Assert.Equal(0, _solver.Solve(1534236469));
    }

    [Fact]
    public void Solve_Zero_Returns0()
    {
        Assert.Equal(0, _solver.Solve(0));
    }

    [Fact]
    public void Solve_NegativeOverflow_Returns0()
    {
        Assert.Equal(0, _solver.Solve(-2147483648));
    }
}
