using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class DecodeWaysTests
{
    private readonly DecodeWays _solver = new();

    [Fact]
    public void Solve_Example1_12_Returns2()
    {
        Assert.Equal(2, _solver.Solve("12"));
    }

    [Fact]
    public void Solve_Example2_226_Returns3()
    {
        Assert.Equal(3, _solver.Solve("226"));
    }

    [Fact]
    public void Solve_Example3_06_Returns0()
    {
        Assert.Equal(0, _solver.Solve("06"));
    }

    [Fact]
    public void Solve_SingleDigit_Returns1()
    {
        Assert.Equal(1, _solver.Solve("5"));
    }

    [Fact]
    public void Solve_Zero_Returns0()
    {
        Assert.Equal(0, _solver.Solve("0"));
    }

    [Fact]
    public void Solve_10_Returns1()
    {
        Assert.Equal(1, _solver.Solve("10"));
    }

    [Fact]
    public void Solve_27_Returns1()
    {
        Assert.Equal(1, _solver.Solve("27"));
    }
}
