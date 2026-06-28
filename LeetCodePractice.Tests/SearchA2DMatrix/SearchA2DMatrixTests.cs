using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class SearchA2DMatrixTests
{
    private readonly SearchA2DMatrix _solver = new();

    [Fact]
    public void Solve_Example1_Found_ReturnsTrue()
    {
        int[][] matrix = [[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60]];
        Assert.True(_solver.Solve(matrix, 3));
    }

    [Fact]
    public void Solve_Example2_NotFound_ReturnsFalse()
    {
        int[][] matrix = [[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60]];
        Assert.False(_solver.Solve(matrix, 13));
    }

    [Fact]
    public void Solve_SingleElementFound_ReturnsTrue()
    {
        Assert.True(_solver.Solve([[5]], 5));
    }

    [Fact]
    public void Solve_EmptyMatrix_ReturnsFalse()
    {
        Assert.False(_solver.Solve([[]], 1));
    }

    [Fact]
    public void Solve_TargetSmallerThanAll_ReturnsFalse()
    {
        int[][] matrix = [[10, 20], [30, 40]];
        Assert.False(_solver.Solve(matrix, 5));
    }
}
