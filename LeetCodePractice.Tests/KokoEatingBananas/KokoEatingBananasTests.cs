using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class KokoEatingBananasTests
{
    private readonly KokoEatingBananas _solver = new();

    [Fact]
    public void Solve_Example1_3_6_7_11_H8_Returns4()
    {
        int[] piles = [3, 6, 7, 11];
        Assert.Equal(4, _solver.Solve(piles, 8));
    }

    [Fact]
    public void Solve_Example2_30_11_23_4_20_H5_Returns30()
    {
        int[] piles = [30, 11, 23, 4, 20];
        Assert.Equal(30, _solver.Solve(piles, 5));
    }

    [Fact]
    public void Solve_Example3_30_11_23_4_20_H6_Returns23()
    {
        int[] piles = [30, 11, 23, 4, 20];
        Assert.Equal(23, _solver.Solve(piles, 6));
    }

    [Fact]
    public void Solve_SinglePile_ReturnsMinSpeed()
    {
        Assert.Equal(5, _solver.Solve([5], 1));
    }

    [Fact]
    public void Solve_LargeHours_Returns1()
    {
        int[] piles = [1, 1, 1];
        Assert.Equal(1, _solver.Solve(piles, 10));
    }
}
