using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class CourseScheduleTests
{
    private readonly CourseSchedule _solver = new();

    [Fact]
    public void Solve_Example1_2Courses_1Prereq_ReturnsTrue()
    {
        int[][] prereqs = [[1, 0]];
        Assert.True(_solver.Solve(2, prereqs));
    }

    [Fact]
    public void Solve_Example2_2Courses_Cycle_ReturnsFalse()
    {
        int[][] prereqs = [[1, 0], [0, 1]];
        Assert.False(_solver.Solve(2, prereqs));
    }

    [Fact]
    public void Solve_NoPrereqs_ReturnsTrue()
    {
        Assert.True(_solver.Solve(3, []));
    }

    [Fact]
    public void Solve_SingleCourse_ReturnsTrue()
    {
        Assert.True(_solver.Solve(1, []));
    }

    [Fact]
    public void Solve_LinearChain_ReturnsTrue()
    {
        int[][] prereqs = [[1, 0], [2, 1], [3, 2]];
        Assert.True(_solver.Solve(4, prereqs));
    }
}
