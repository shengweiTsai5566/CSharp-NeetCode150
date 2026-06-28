using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class BestTimeToBuyAndSellStockWithCooldownTests
{
    private readonly BestTimeToBuyAndSellStockWithCooldown _solver = new();

    [Fact]
    public void Solve_Example1_1_2_3_0_2_Returns3()
    {
        int[] prices = [1, 2, 3, 0, 2];
        Assert.Equal(3, _solver.Solve(prices));
    }

    [Fact]
    public void Solve_Example2_1_Returns0()
    {
        Assert.Equal(0, _solver.Solve([1]));
    }

    [Fact]
    public void Solve_StrictlyIncreasing_ReturnsMaxProfit()
    {
        Assert.Equal(4, _solver.Solve([1, 2, 3, 5]));
    }

    [Fact]
    public void Solve_StrictlyDecreasing_Returns0()
    {
        Assert.Equal(0, _solver.Solve([5, 4, 3, 2, 1]));
    }

    [Fact]
    public void Solve_EmptyArray_Returns0()
    {
        Assert.Equal(0, _solver.Solve([]));
    }
}
