using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class HappyNumberTests
{
    private readonly HappyNumber _solver = new();

    [Fact]
    public void Solve_Example1_19_ReturnsTrue()
    {
        Assert.True(_solver.Solve(19));
    }

    [Fact]
    public void Solve_Example2_2_ReturnsFalse()
    {
        Assert.False(_solver.Solve(2));
    }

    [Fact]
    public void Solve_1_ReturnsTrue()
    {
        Assert.True(_solver.Solve(1));
    }

    [Fact]
    public void Solve_7_ReturnsTrue()
    {
        Assert.True(_solver.Solve(7));
    }

    [Fact]
    public void Solve_4_ReturnsFalse()
    {
        Assert.False(_solver.Solve(4)); // 4 leads to cycle
    }
}
