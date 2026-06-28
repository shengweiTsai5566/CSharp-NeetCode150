using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class JumpGameIITests
{
    private readonly JumpGameII _solver = new();

    [Fact]
    public void Solve_Example1_2_3_1_1_4_Returns2()
    {
        int[] nums = [2, 3, 1, 1, 4];
        Assert.Equal(2, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_Example2_2_3_0_1_4_Returns2()
    {
        int[] nums = [2, 3, 0, 1, 4];
        Assert.Equal(2, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_SingleElement_Returns0()
    {
        Assert.Equal(0, _solver.Solve([0]));
    }

    [Fact]
    public void Solve_TwoElements_Returns1()
    {
        Assert.Equal(1, _solver.Solve([1, 2]));
    }

    [Fact]
    public void Solve_LargeJumps_ReturnsMinimal()
    {
        Assert.Equal(2, _solver.Solve([2, 3, 1, 0, 4]));
    }
}
