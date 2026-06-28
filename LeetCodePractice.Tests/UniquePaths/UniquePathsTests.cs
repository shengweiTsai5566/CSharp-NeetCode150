using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class UniquePathsTests
{
    private readonly UniquePaths _solver = new();

    [Fact]
    public void Solve_Example1_3x7_Returns28()
    {
        Assert.Equal(28, _solver.Solve(3, 7));
    }

    [Fact]
    public void Solve_Example2_3x2_Returns3()
    {
        Assert.Equal(3, _solver.Solve(3, 2));
    }

    [Fact]
    public void Solve_1x1_Returns1()
    {
        Assert.Equal(1, _solver.Solve(1, 1));
    }

    [Fact]
    public void Solve_1xN_Returns1()
    {
        Assert.Equal(1, _solver.Solve(1, 10));
    }

    [Fact]
    public void Solve_Mx1_Returns1()
    {
        Assert.Equal(1, _solver.Solve(10, 1));
    }
}
