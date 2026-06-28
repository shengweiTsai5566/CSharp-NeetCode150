using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class HandOfStraightsTests
{
    private readonly HandOfStraights _solver = new();

    [Fact]
    public void Solve_Example1_1_2_3_6_2_3_4_7_8_Group3_ReturnsTrue()
    {
        int[] hand = [1, 2, 3, 6, 2, 3, 4, 7, 8];
        Assert.True(_solver.Solve(hand, 3));
    }

    [Fact]
    public void Solve_Example2_1_2_3_4_5_Group4_ReturnsFalse()
    {
        int[] hand = [1, 2, 3, 4, 5];
        Assert.False(_solver.Solve(hand, 4));
    }

    [Fact]
    public void Solve_SingleGroup_ReturnsTrue()
    {
        Assert.True(_solver.Solve([1, 2, 3], 3));
    }

    [Fact]
    public void Solve_NotConsecutive_ReturnsFalse()
    {
        Assert.False(_solver.Solve([1, 2, 4], 3));
    }

    [Fact]
    public void Solve_EmptyHand_ReturnsTrue()
    {
        Assert.True(_solver.Solve([], 3));
    }
}
