using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class MeetingRoomsIITests
{
    private readonly MeetingRoomsII _solver = new();

    [Fact]
    public void Solve_Example1_Returns2()
    {
        int[][] intervals = [[0, 30], [5, 10], [15, 20]];
        Assert.Equal(2, _solver.Solve(intervals));
    }

    [Fact]
    public void Solve_Example2_Returns1()
    {
        int[][] intervals = [[7, 10], [2, 4]];
        Assert.Equal(1, _solver.Solve(intervals));
    }

    [Fact]
    public void Solve_Empty_Returns0()
    {
        Assert.Equal(0, _solver.Solve([]));
    }

    [Fact]
    public void Solve_AllOverlap_ReturnsCount()
    {
        int[][] intervals = [[1, 5], [2, 6], [3, 7]];
        Assert.Equal(3, _solver.Solve(intervals));
    }
}
