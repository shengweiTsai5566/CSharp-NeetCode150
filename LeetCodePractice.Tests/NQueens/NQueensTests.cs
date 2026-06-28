using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class NQueensTests
{
    private readonly NQueens _solver = new();

    [Fact]
    public void Solve_Example1_n4_Returns2Solutions()
    {
        var result = _solver.Solve(4);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void Solve_Example2_n1_Returns1Solution()
    {
        var result = _solver.Solve(1);
        Assert.Single(result);
        Assert.Equal("Q", result[0][0]);
    }

    [Fact]
    public void Solve_Example3_n2_Returns0()
    {
        Assert.Empty(_solver.Solve(2));
    }

    [Fact]
    public void Solve_n3_Returns0()
    {
        Assert.Empty(_solver.Solve(3));
    }
}
