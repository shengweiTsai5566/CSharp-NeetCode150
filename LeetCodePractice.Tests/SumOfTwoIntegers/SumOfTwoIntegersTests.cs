using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class SumOfTwoIntegersTests
{
    private readonly SumOfTwoIntegers _solver = new();

    [Fact]
    public void Solve_Example1_1_2_Returns3()
    {
        Assert.Equal(3, _solver.Solve(1, 2));
    }

    [Fact]
    public void Solve_Example2_2_3_Returns5()
    {
        Assert.Equal(5, _solver.Solve(2, 3));
    }

    [Fact]
    public void Solve_Negative_ReturnsCorrect()
    {
        Assert.Equal(-1, _solver.Solve(-2, 1));
    }

    [Fact]
    public void Solve_Zero_ReturnsOther()
    {
        Assert.Equal(7, _solver.Solve(0, 7));
    }

    [Fact]
    public void Solve_LargeNumbers_ReturnsSum()
    {
        Assert.Equal(1000, _solver.Solve(500, 500));
    }
}
