using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class ContainerWithMostWaterTests
{
    private readonly ContainerWithMostWater _solver = new();

    [Fact]
    public void Solve_Example1_1_8_6_2_5_4_8_3_7_Returns49()
    {
        int[] height = [1, 8, 6, 2, 5, 4, 8, 3, 7];
        Assert.Equal(49, _solver.Solve(height));
    }

    [Fact]
    public void Solve_Example2_1_1_Returns1()
    {
        Assert.Equal(1, _solver.Solve([1, 1]));
    }

    [Fact]
    public void Solve_TwoElements_ReturnsMin()
    {
        Assert.Equal(4, _solver.Solve([4, 5]));
    }

    [Fact]
    public void Solve_Increasing_ReturnsMaxArea()
    {
        Assert.Equal(6, _solver.Solve([1, 2, 3, 4]));
    }

    [Fact]
    public void Solve_Decreasing_ReturnsMaxArea()
    {
        Assert.Equal(6, _solver.Solve([4, 3, 2, 1]));
    }
}
