using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class BestTimeToBuyAndSellStockTests
{
    private readonly BestTimeToBuyAndSellStock _solver = new();

    [Fact]
    public void Solve_Example1_7_1_5_3_6_4_Returns5()
    {
        int[] prices = [7, 1, 5, 3, 6, 4];
        Assert.Equal(5, _solver.Solve(prices));
    }

    [Fact]
    public void Solve_Example2_7_6_4_3_1_Returns0()
    {
        int[] prices = [7, 6, 4, 3, 1];
        Assert.Equal(0, _solver.Solve(prices));
    }

    [Fact]
    public void Solve_SingleDay_Returns0()
    {
        Assert.Equal(0, _solver.Solve([5]));
    }

    [Fact]
    public void Solve_TwoDaysIncreasing_ReturnsProfit()
    {
        Assert.Equal(3, _solver.Solve([1, 4]));
    }

    [Fact]
    public void Solve_TwoDaysDecreasing_Returns0()
    {
        Assert.Equal(0, _solver.Solve([5, 2]));
    }

    [Fact]
    public void Solve_LargeArray_DoesNotThrow()
    {
        var prices = new int[100000];
        for (int i = 0; i < prices.Length; i++)
            prices[i] = i % 1000;
        var result = _solver.Solve(prices);
        Assert.True(result >= 0);
    }
}
