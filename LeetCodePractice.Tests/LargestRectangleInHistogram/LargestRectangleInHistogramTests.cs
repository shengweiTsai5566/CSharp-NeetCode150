using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class LargestRectangleInHistogramTests
{
    private readonly LargestRectangleInHistogram _solver = new();

    [Fact]
    public void Solve_Example1_2_1_5_6_2_3_Returns10()
    {
        int[] heights = [2, 1, 5, 6, 2, 3];
        Assert.Equal(10, _solver.Solve(heights));
    }

    [Fact]
    public void Solve_Example2_2_4_Returns4()
    {
        int[] heights = [2, 4];
        Assert.Equal(4, _solver.Solve(heights));
    }

    [Fact]
    public void Solve_Increasing_ReturnsMax()
    {
        int[] heights = [1, 2, 3, 4, 5];
        Assert.Equal(9, _solver.Solve(heights));
    }

    [Fact]
    public void Solve_SingleBar_ReturnsItsHeight()
    {
        Assert.Equal(5, _solver.Solve([5]));
    }

    [Fact]
    public void Solve_AllSame_ReturnsArea()
    {
        int[] heights = [3, 3, 3, 3];
        Assert.Equal(12, _solver.Solve(heights));
    }
}
