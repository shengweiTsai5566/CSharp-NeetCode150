using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class BurstBalloonsTests
{
    private readonly BurstBalloons _solver = new();

    [Fact]
    public void Solve_Example1_3_1_5_8_Returns167()
    {
        int[] nums = [3, 1, 5, 8];
        Assert.Equal(167, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_Example2_1_5_Returns10()
    {
        int[] nums = [1, 5];
        Assert.Equal(10, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_SingleBalloon_ReturnsItsValue()
    {
        Assert.Equal(10, _solver.Solve([10]));
    }

    [Fact]
    public void Solve_EmptyArray_Returns0()
    {
        Assert.Equal(0, _solver.Solve([]));
    }

    [Fact]
    public void Solve_TwoSame_ReturnsCorrect()
    {
        Assert.Equal(4, _solver.Solve([2, 2]));
    }
}
