using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class LcTaskSchedulerTests
{
    private readonly LcTaskScheduler _solver = new();

    [Fact]
    public void Solve_Example1_A_A_A_B_B_B_N2_Returns8()
    {
        char[] tasks = ['A', 'A', 'A', 'B', 'B', 'B'];
        Assert.Equal(8, _solver.Solve(tasks, 2));
    }

    [Fact]
    public void Solve_Example2_A_A_A_B_B_B_N0_Returns6()
    {
        char[] tasks = ['A', 'A', 'A', 'B', 'B', 'B'];
        Assert.Equal(6, _solver.Solve(tasks, 0));
    }

    [Fact]
    public void Solve_Example3_A_A_A_A_A_A_B_C_D_E_F_G_N2_Returns16()
    {
        char[] tasks = ['A', 'A', 'A', 'A', 'A', 'A', 'B', 'C', 'D', 'E', 'F', 'G'];
        Assert.Equal(16, _solver.Solve(tasks, 2));
    }

    [Fact]
    public void Solve_SingleTask_Returns1()
    {
        Assert.Equal(1, _solver.Solve(['A'], 1));
    }

    [Fact]
    public void Solve_AllDifferent_ReturnsLength()
    {
        char[] tasks = ['A', 'B', 'C', 'D'];
        Assert.Equal(4, _solver.Solve(tasks, 2));
    }
}
