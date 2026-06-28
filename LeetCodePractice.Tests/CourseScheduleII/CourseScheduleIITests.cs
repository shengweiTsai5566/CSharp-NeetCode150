using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class CourseScheduleIITests
{
    private readonly CourseScheduleII _solver = new();

    [Fact]
    public void Solve_Example1_2Courses_Prereq1_0_Returns0_1()
    {
        int[][] prereqs = [[1, 0]];
        var result = _solver.Solve(2, prereqs);
        Assert.Equal(new int[] { 0, 1 }, result);
    }

    [Fact]
    public void Solve_Example2_4Courses_ReturnsValidOrder()
    {
        int[][] prereqs = [[1, 0], [2, 0], [3, 1], [3, 2]];
        var result = _solver.Solve(4, prereqs);
        Assert.Equal(4, result.Length);
        // 0 must be before 1 and 2; 1 and 2 must be before 3
        Assert.Contains(0, result.Take(2));
        Assert.Contains(3, result.Skip(2));
    }

    [Fact]
    public void Solve_NoPrereqs_ReturnsAllCourses()
    {
        var result = _solver.Solve(3, []);
        Assert.Equal(3, result.Length);
    }

    [Fact]
    public void Solve_Cycle_ReturnsEmpty()
    {
        int[][] prereqs = [[1, 0], [0, 1]];
        Assert.Empty(_solver.Solve(2, prereqs));
    }
}
