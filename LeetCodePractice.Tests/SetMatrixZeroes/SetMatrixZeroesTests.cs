using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class SetMatrixZeroesTests
{
    private readonly SetMatrixZeroes _solver = new();

    [Fact]
    public void Solve_Example1_ReturnsCorrect()
    {
        int[][] matrix = [[1, 1, 1], [1, 0, 1], [1, 1, 1]];
        _solver.Solve(matrix);
        Assert.Equal(new int[][] { [1, 0, 1], [0, 0, 0], [1, 0, 1] }, matrix);
    }

    [Fact]
    public void Solve_Example2_ReturnsCorrect()
    {
        int[][] matrix = [[0, 1, 2, 0], [3, 4, 5, 2], [1, 3, 1, 5]];
        _solver.Solve(matrix);
        Assert.Equal(new int[][] { [0, 0, 0, 0], [0, 4, 5, 0], [0, 3, 1, 0] }, matrix);
    }

    [Fact]
    public void Solve_NoZero_NoChange()
    {
        int[][] matrix = [[1, 2], [3, 4]];
        _solver.Solve(matrix);
        Assert.Equal(new int[][] { [1, 2], [3, 4] }, matrix);
    }

    [Fact]
    public void Solve_SingleElementZero_StaysZero()
    {
        int[][] matrix = [[0]];
        _solver.Solve(matrix);
        Assert.Equal(new int[][] { [0] }, matrix);
    }
}
