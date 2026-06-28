using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class MeetingRoomsTests
{
    private readonly MeetingRooms _solver = new();

    [Fact]
    public void Solve_Example1_ReturnsFalse()
    {
        int[][] intervals = [[0, 30], [5, 10], [15, 20]];
        Assert.False(_solver.Solve(intervals));
    }

    [Fact]
    public void Solve_Example2_ReturnsTrue()
    {
        int[][] intervals = [[7, 10], [2, 4]];
        Assert.True(_solver.Solve(intervals));
    }

    [Fact]
    public void Solve_Empty_ReturnsTrue()
    {
        Assert.True(_solver.Solve([]));
    }

    [Fact]
    public void Solve_TouchingIntervals_ReturnsTrue()
    {
        int[][] intervals = [[1, 5], [5, 10]];
        Assert.True(_solver.Solve(intervals));
    }
}
