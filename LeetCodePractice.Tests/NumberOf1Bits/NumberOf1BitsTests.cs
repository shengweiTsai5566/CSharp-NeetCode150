using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class NumberOf1BitsTests
{
    private readonly NumberOf1Bits _solver = new();

    [Fact]
    public void Solve_Example1_11_Returns3()
    {
        Assert.Equal(3, _solver.Solve(11));
    }

    [Fact]
    public void Solve_Example2_128_Returns1()
    {
        Assert.Equal(1, _solver.Solve(128));
    }

    [Fact]
    public void Solve_Negative_Minus3_Returns31()
    {
        Assert.Equal(31, _solver.Solve(-3));
    }

    [Fact]
    public void Solve_Zero_Returns0()
    {
        Assert.Equal(0, _solver.Solve(0));
    }

    [Fact]
    public void Solve_Minus1_Returns32()
    {
        Assert.Equal(32, _solver.Solve(-1));
    }
}
