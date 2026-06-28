using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class PowXNTests
{
    private readonly PowXN _solver = new();

    [Fact]
    public void Solve_Example1_2_10_Returns1024()
    {
        Assert.Equal(1024.0, _solver.Solve(2.0, 10));
    }

    [Fact]
    public void Solve_Example2_2_1_Minus2_Returns0_25()
    {
        Assert.Equal(0.25, _solver.Solve(2.0, -2));
    }

    [Fact]
    public void Solve_Example3_2_1_Returns2()
    {
        Assert.Equal(2.0, _solver.Solve(2.0, 1));
    }

    [Fact]
    public void Solve_ZeroPower_Returns1()
    {
        Assert.Equal(1.0, _solver.Solve(5.0, 0));
    }

    [Fact]
    public void Solve_NegativeBase_ReturnsCorrect()
    {
        Assert.Equal(-8.0, _solver.Solve(-2.0, 3));
    }
}
