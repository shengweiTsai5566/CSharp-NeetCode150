using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class MinimumIntervalToIncludeEachQueryTests
{
    private readonly MinimumIntervalToIncludeEachQuery _solver = new();

    [Fact]
    public void Solve_Example1_ReturnsCorrect()
    {
        int[][] intervals = [[1, 4], [2, 4], [3, 6], [4, 4]];
        int[] queries = [2, 3, 4, 5];
        Assert.Equal(new int[] { 3, 3, 1, 4 }, _solver.Solve(intervals, queries));
    }

    [Fact]
    public void Solve_Example2_ReturnsCorrect()
    {
        int[][] intervals = [[2, 3], [2, 5], [1, 8], [20, 25]];
        int[] queries = [2, 19, 5, 22];
        Assert.Equal(new int[] { 2, -1, 4, 6 }, _solver.Solve(intervals, queries));
    }

    [Fact]
    public void Solve_NoInterval_ReturnsMinus1()
    {
        int[][] intervals = [[1, 2]];
        Assert.Equal(new int[] { -1 }, _solver.Solve(intervals, [5]));
    }

    [Fact]
    public void Solve_EmptyIntervals_ReturnsMinus1()
    {
        Assert.Equal(new int[] { -1 }, _solver.Solve([], [1]));
    }
}
