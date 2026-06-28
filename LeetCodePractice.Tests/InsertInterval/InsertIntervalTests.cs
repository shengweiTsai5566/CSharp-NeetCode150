using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class InsertIntervalTests
{
    private readonly InsertInterval _solver = new();

    [Fact]
    public void Solve_Example1_ReturnsMerged()
    {
        int[][] intervals = [[1, 3], [6, 9]];
        int[] newInterval = [2, 5];
        var result = _solver.Solve(intervals, newInterval);
        Assert.Equal(new int[][] { [1, 5], [6, 9] }, result);
    }

    [Fact]
    public void Solve_Example2_ReturnsMerged()
    {
        int[][] intervals = [[1, 2], [3, 5], [6, 7], [8, 10], [12, 16]];
        int[] newInterval = [4, 8];
        var result = _solver.Solve(intervals, newInterval);
        Assert.Equal(new int[][] { [1, 2], [3, 10], [12, 16] }, result);
    }

    [Fact]
    public void Solve_InsertAtBeginning_ReturnsMerged()
    {
        int[][] intervals = [[3, 5], [6, 9]];
        int[] newInterval = [1, 2];
        var result = _solver.Solve(intervals, newInterval);
        Assert.Equal(new int[][] { [1, 2], [3, 5], [6, 9] }, result);
    }

    [Fact]
    public void Solve_InsertAtEnd_ReturnsMerged()
    {
        int[][] intervals = [[1, 2], [3, 5]];
        int[] newInterval = [6, 8];
        var result = _solver.Solve(intervals, newInterval);
        Assert.Equal(new int[][] { [1, 2], [3, 5], [6, 8] }, result);
    }

    [Fact]
    public void Solve_EmptyIntervals_ReturnsNewInterval()
    {
        var result = _solver.Solve([], [5, 7]);
        Assert.Equal(new int[][] { [5, 7] }, result);
    }
}
