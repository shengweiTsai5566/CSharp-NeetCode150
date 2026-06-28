using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class RotateImageTests
{
    private readonly RotateImage _solver = new();

    [Fact]
    public void Solve_Example1_3x3_RotatesCorrectly()
    {
        int[][] matrix = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
        _solver.Solve(matrix);
        Assert.Equal(new int[][] { [7, 4, 1], [8, 5, 2], [9, 6, 3] }, matrix);
    }

    [Fact]
    public void Solve_Example2_4x4_RotatesCorrectly()
    {
        int[][] matrix = [[5, 1, 9, 11], [2, 4, 8, 10], [13, 3, 6, 7], [15, 14, 12, 16]];
        _solver.Solve(matrix);
        int[][] expected = [[15, 13, 2, 5], [14, 3, 4, 1], [12, 6, 8, 9], [16, 7, 10, 11]];
        Assert.Equal(expected, matrix);
    }

    [Fact]
    public void Solve_SingleElement_NoChange()
    {
        int[][] matrix = [[1]];
        _solver.Solve(matrix);
        Assert.Equal(new int[][] { [1] }, matrix);
    }

    [Fact]
    public void Solve_2x2_RotatesCorrectly()
    {
        int[][] matrix = [[1, 2], [3, 4]];
        _solver.Solve(matrix);
        Assert.Equal(new int[][] { [3, 1], [4, 2] }, matrix);
    }
}
