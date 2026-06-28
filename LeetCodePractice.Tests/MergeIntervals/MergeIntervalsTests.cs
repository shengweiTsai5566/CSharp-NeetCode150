using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class MergeIntervalsTests
{
    private readonly MergeIntervals _solver = new();

    [Fact]
    public void Solve_Example1_ReturnsMerged()
    {
        int[][] intervals = [[1, 3], [2, 6], [8, 10], [15, 18]];
        var result = _solver.Solve(intervals);
        Assert.Equal(new int[][] { [1, 6], [8, 10], [15, 18] }, result);
    }

    [Fact]
    public void Solve_Example2_ReturnsMerged()
    {
        int[][] intervals = [[1, 4], [4, 5]];
        var result = _solver.Solve(intervals);
        Assert.Equal(new int[][] { [1, 5] }, result);
    }

    [Fact]
    public void Solve_AllOverlapping_ReturnsOne()
    {
        int[][] intervals = [[1, 4], [2, 5], [3, 6]];
        var result = _solver.Solve(intervals);
        Assert.Equal(new int[][] { [1, 6] }, result);
    }

    [Fact]
    public void Solve_NoOverlap_ReturnsSame()
    {
        int[][] intervals = [[1, 2], [3, 4], [5, 6]];
        var result = _solver.Solve(intervals);
        Assert.Equal(intervals, result);
    }

    [Fact]
    public void Solve_Empty_ReturnsEmpty()
    {
        Assert.Empty(_solver.Solve([]));
    }
}
