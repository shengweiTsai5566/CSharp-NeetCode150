using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class NonOverlappingIntervalsTests
{
    private readonly NonOverlappingIntervals _solver = new();

    [Fact]
    public void Solve_Example1_Returns1()
    {
        int[][] intervals = [[1, 2], [2, 3], [3, 4], [1, 3]];
        Assert.Equal(1, _solver.Solve(intervals));
    }

    [Fact]
    public void Solve_Example2_Returns2()
    {
        int[][] intervals = [[1, 2], [1, 2], [1, 2]];
        Assert.Equal(2, _solver.Solve(intervals));
    }

    [Fact]
    public void Solve_Example3_Returns0()
    {
        int[][] intervals = [[1, 2], [2, 3]];
        Assert.Equal(0, _solver.Solve(intervals));
    }

    [Fact]
    public void Solve_Empty_Returns0()
    {
        Assert.Equal(0, _solver.Solve([]));
    }
}
