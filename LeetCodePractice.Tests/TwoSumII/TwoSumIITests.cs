using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class TwoSumIITests
{
    private readonly TwoSumII _solver = new();

    [Fact]
    public void Solve_Example1_2_7_11_15_Target9_Returns1_2()
    {
        int[] numbers = [2, 7, 11, 15];
        Assert.Equal(new int[] { 1, 2 }, _solver.Solve(numbers, 9));
    }

    [Fact]
    public void Solve_Example2_2_3_4_Target6_Returns1_3()
    {
        int[] numbers = [2, 3, 4];
        Assert.Equal(new int[] { 1, 3 }, _solver.Solve(numbers, 6));
    }

    [Fact]
    public void Solve_Example3_Minus1_0_TargetMinus1_Returns1_2()
    {
        int[] numbers = [-1, 0];
        Assert.Equal(new int[] { 1, 2 }, _solver.Solve(numbers, -1));
    }

    [Fact]
    public void Solve_DuplicateValues_ReturnsIndices()
    {
        int[] numbers = [1, 2, 3, 3, 6];
        Assert.Equal(new int[] { 3, 4 }, _solver.Solve(numbers, 9));
    }
}
