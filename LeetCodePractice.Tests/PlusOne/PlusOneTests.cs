using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class PlusOneTests
{
    private readonly PlusOne _solver = new();

    [Fact]
    public void Solve_Example1_1_2_3_Returns1_2_4()
    {
        int[] digits = [1, 2, 3];
        Assert.Equal(new int[] { 1, 2, 4 }, _solver.Solve(digits));
    }

    [Fact]
    public void Solve_Example2_4_3_2_1_Returns4_3_2_2()
    {
        int[] digits = [4, 3, 2, 1];
        Assert.Equal(new int[] { 4, 3, 2, 2 }, _solver.Solve(digits));
    }

    [Fact]
    public void Solve_Example3_9_Returns1_0()
    {
        Assert.Equal(new int[] { 1, 0 }, _solver.Solve([9]));
    }

    [Fact]
    public void Solve_All9s_Returns1WithZeros()
    {
        Assert.Equal(new int[] { 1, 0, 0, 0 }, _solver.Solve([9, 9, 9]));
    }

    [Fact]
    public void Solve_SingleDigit_ReturnsIncremented()
    {
        Assert.Equal(new int[] { 6 }, _solver.Solve([5]));
    }
}
