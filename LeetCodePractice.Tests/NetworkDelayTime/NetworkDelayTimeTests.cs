using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class NetworkDelayTimeTests
{
    private readonly NetworkDelayTime _solver = new();

    [Fact]
    public void Solve_Example1_Returns2()
    {
        int[][] times = [[2, 1, 1], [2, 3, 1], [3, 4, 1]];
        Assert.Equal(2, _solver.Solve(times, 4, 2));
    }

    [Fact]
    public void Solve_Example2_Returns1()
    {
        int[][] times = [[1, 2, 1]];
        Assert.Equal(1, _solver.Solve(times, 2, 1));
    }

    [Fact]
    public void Solve_Example3_ReturnsMinus1()
    {
        int[][] times = [[1, 2, 1]];
        Assert.Equal(-1, _solver.Solve(times, 2, 2));
    }

    [Fact]
    public void Solve_Disconnected_ReturnsMinus1()
    {
        int[][] times = [[1, 2, 1], [3, 4, 2]];
        Assert.Equal(-1, _solver.Solve(times, 4, 1));
    }
}
