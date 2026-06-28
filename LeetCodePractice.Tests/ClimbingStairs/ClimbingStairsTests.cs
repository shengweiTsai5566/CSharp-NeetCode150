using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class ClimbingStairsTests
{
    private readonly ClimbingStairs _solver = new();

    [Fact]
    public void Solve_Example1_n2_Returns2()
    {
        Assert.Equal(2, _solver.Solve(2));
    }

    [Fact]
    public void Solve_Example2_n3_Returns3()
    {
        Assert.Equal(3, _solver.Solve(3));
    }

    [Fact]
    public void Solve_n1_Returns1()
    {
        Assert.Equal(1, _solver.Solve(1));
    }

    [Fact]
    public void Solve_n5_Returns8()
    {
        Assert.Equal(8, _solver.Solve(5));
    }

    [Fact]
    public void Solve_n10_Returns89()
    {
        Assert.Equal(89, _solver.Solve(10));
    }
}
