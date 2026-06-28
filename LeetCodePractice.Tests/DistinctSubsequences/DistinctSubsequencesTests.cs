using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class DistinctSubsequencesTests
{
    private readonly DistinctSubsequences _solver = new();

    [Fact]
    public void Solve_Example1_Rabbit_Rabbit_Returns1()
    {
        Assert.Equal(1, _solver.Solve("rabbbit", "rabbit"));
    }

    [Fact]
    public void Solve_Example2_Babgbag_Bag_Returns5()
    {
        Assert.Equal(5, _solver.Solve("babgbag", "bag"));
    }

    [Fact]
    public void Solve_EmptyT_Returns1()
    {
        Assert.Equal(1, _solver.Solve("abc", ""));
    }

    [Fact]
    public void Solve_EmptyS_Returns0()
    {
        Assert.Equal(0, _solver.Solve("", "a"));
    }

    [Fact]
    public void Solve_BothEmpty_Returns1()
    {
        Assert.Equal(1, _solver.Solve("", ""));
    }
}
