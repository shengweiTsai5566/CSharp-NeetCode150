using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class CountingBitsTests
{
    private readonly CountingBits _solver = new();

    [Fact]
    public void Solve_Example1_n2_Returns0_1_1()
    {
        Assert.Equal(new int[] { 0, 1, 1 }, _solver.Solve(2));
    }

    [Fact]
    public void Solve_Example2_n5_Returns0_1_1_2_1_2()
    {
        Assert.Equal(new int[] { 0, 1, 1, 2, 1, 2 }, _solver.Solve(5));
    }

    [Fact]
    public void Solve_n0_Returns0()
    {
        Assert.Equal(new int[] { 0 }, _solver.Solve(0));
    }

    [Fact]
    public void Solve_n1_Returns0_1()
    {
        Assert.Equal(new int[] { 0, 1 }, _solver.Solve(1));
    }

    [Fact]
    public void Solve_n10_FirstFewMatch()
    {
        var result = _solver.Solve(10);
        Assert.Equal(11, result.Length);
        Assert.Equal(0, result[0]);
        Assert.Equal(1, result[1]);
        Assert.Equal(1, result[2]);
        Assert.Equal(2, result[3]);
    }
}
