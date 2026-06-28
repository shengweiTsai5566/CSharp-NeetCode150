using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class TrappingRainWaterTests
{
    private readonly TrappingRainWater _solver = new();

    [Fact]
    public void Solve_Example1_0_1_0_2_1_0_1_3_2_1_2_1_Returns6()
    {
        int[] height = [0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1];
        Assert.Equal(6, _solver.Solve(height));
    }

    [Fact]
    public void Solve_Example2_4_2_0_3_2_5_Returns9()
    {
        int[] height = [4, 2, 0, 3, 2, 5];
        Assert.Equal(9, _solver.Solve(height));
    }

    [Fact]
    public void Solve_NoTrapping_Returns0()
    {
        Assert.Equal(0, _solver.Solve([1, 2, 3, 4]));
    }

    [Fact]
    public void Solve_TwoElements_Returns0()
    {
        Assert.Equal(0, _solver.Solve([1, 2]));
    }

    [Fact]
    public void Solve_Empty_Returns0()
    {
        Assert.Equal(0, _solver.Solve([]));
    }
}
