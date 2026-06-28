using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class RedundantConnectionTests
{
    private readonly RedundantConnection _solver = new();

    [Fact]
    public void Solve_Example1_Returns2_3()
    {
        int[][] edges = [[1, 2], [1, 3], [2, 3]];
        Assert.Equal(new int[] { 2, 3 }, _solver.Solve(edges));
    }

    [Fact]
    public void Solve_Example2_Returns1_4()
    {
        int[][] edges = [[1, 2], [2, 3], [3, 4], [1, 4], [1, 5]];
        Assert.Equal(new int[] { 1, 4 }, _solver.Solve(edges));
    }

    [Fact]
    public void Solve_ThreeNodes_ReturnsRedundant()
    {
        int[][] edges = [[1, 2], [2, 3], [1, 3]];
        Assert.Equal(new int[] { 1, 3 }, _solver.Solve(edges));
    }

    [Fact]
    public void Solve_LinearChain_NoRedundant_ReturnsLast()
    {
        int[][] edges = [[1, 2], [2, 3], [3, 4]];
        Assert.Equal(new int[] { 3, 4 }, _solver.Solve(edges));
    }
}
