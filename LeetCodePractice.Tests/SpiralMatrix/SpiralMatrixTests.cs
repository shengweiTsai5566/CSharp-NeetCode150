using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class SpiralMatrixTests
{
    private readonly SpiralMatrix _solver = new();

    [Fact]
    public void Solve_Example1_3x3_ReturnsSpiral()
    {
        int[][] matrix = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
        Assert.Equal(new List<int> { 1, 2, 3, 6, 9, 8, 7, 4, 5 }, _solver.Solve(matrix));
    }

    [Fact]
    public void Solve_Example2_3x4_ReturnsSpiral()
    {
        int[][] matrix = [[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12]];
        Assert.Equal(new List<int> { 1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7 }, _solver.Solve(matrix));
    }

    [Fact]
    public void Solve_SingleRow_ReturnsRow()
    {
        int[][] matrix = [[1, 2, 3]];
        Assert.Equal(new List<int> { 1, 2, 3 }, _solver.Solve(matrix));
    }

    [Fact]
    public void Solve_SingleColumn_ReturnsColumn()
    {
        int[][] matrix = [[1], [2], [3]];
        Assert.Equal(new List<int> { 1, 2, 3 }, _solver.Solve(matrix));
    }

    [Fact]
    public void Solve_SingleElement_ReturnsIt()
    {
        int[][] matrix = [[5]];
        Assert.Equal(new List<int> { 5 }, _solver.Solve(matrix));
    }
}
