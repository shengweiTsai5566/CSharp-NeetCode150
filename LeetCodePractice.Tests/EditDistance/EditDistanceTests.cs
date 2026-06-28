using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class EditDistanceTests
{
    private readonly EditDistance _solver = new();

    [Fact]
    public void Solve_Example1_Horse_Ros_Returns3()
    {
        Assert.Equal(3, _solver.Solve("horse", "ros"));
    }

    [Fact]
    public void Solve_Example2_Intention_Execution_Returns5()
    {
        Assert.Equal(5, _solver.Solve("intention", "execution"));
    }

    [Fact]
    public void Solve_EmptyToEmpty_Returns0()
    {
        Assert.Equal(0, _solver.Solve("", ""));
    }

    [Fact]
    public void Solve_EmptyToNonEmpty_ReturnsLength()
    {
        Assert.Equal(3, _solver.Solve("", "abc"));
    }

    [Fact]
    public void Solve_SameString_Returns0()
    {
        Assert.Equal(0, _solver.Solve("abc", "abc"));
    }

    [Fact]
    public void Solve_OneCharDiff_Returns1()
    {
        Assert.Equal(1, _solver.Solve("a", "b"));
    }
}
