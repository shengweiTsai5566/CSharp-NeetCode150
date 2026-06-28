using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class LongestIncreasingPathInAMatrixTests
{
    private readonly LongestIncreasingPathInAMatrix _solver = new();

    [Fact]
    public void Solve_Example1_Returns4()
    {
        int[][] matrix = [[9, 9, 4], [6, 6, 8], [2, 1, 1]];
        Assert.Equal(4, _solver.Solve(matrix));
    }

    [Fact]
    public void Solve_Example2_Returns4()
    {
        int[][] matrix = [[3, 4, 5], [3, 2, 6], [2, 2, 1]];
        Assert.Equal(4, _solver.Solve(matrix));
    }

    [Fact]
    public void Solve_Example3_SingleCell_Returns1()
    {
        int[][] matrix = [[1]];
        Assert.Equal(1, _solver.Solve(matrix));
    }

    [Fact]
    public void Solve_AllDecreasing_Returns1()
    {
        int[][] matrix = [[5, 4], [3, 2]];
        Assert.Equal(2, _solver.Solve(matrix));
    }
}
