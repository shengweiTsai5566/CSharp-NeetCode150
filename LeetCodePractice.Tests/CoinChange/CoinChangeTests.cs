using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class CoinChangeTests
{
    private readonly CoinChange _solver = new();

    [Fact]
    public void Solve_Example1_Coins1_2_5_Amount11_Returns3()
    {
        int[] coins = [1, 2, 5];
        Assert.Equal(3, _solver.Solve(coins, 11));
    }

    [Fact]
    public void Solve_Example2_Coins2_Amount3_ReturnsMinus1()
    {
        int[] coins = [2];
        Assert.Equal(-1, _solver.Solve(coins, 3));
    }

    [Fact]
    public void Solve_Example3_Amount0_Returns0()
    {
        int[] coins = [1];
        Assert.Equal(0, _solver.Solve(coins, 0));
    }

    [Fact]
    public void Solve_Coins1_Amount10000_DoesNotThrow()
    {
        int[] coins = [1];
        Assert.Equal(10000, _solver.Solve(coins, 10000));
    }

    [Fact]
    public void Solve_Coins1_5_10_Amount27_Returns4()
    {
        int[] coins = [1, 5, 10];
        Assert.Equal(4, _solver.Solve(coins, 27)); // 10+10+5+1+1
    }
}
