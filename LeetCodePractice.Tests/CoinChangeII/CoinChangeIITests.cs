using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class CoinChangeIITests
{
    private readonly CoinChangeII _solver = new();

    [Fact]
    public void Solve_Example1_Amount5_Coins1_2_5_Returns4()
    {
        int amount = 5;
        int[] coins = [1, 2, 5];
        Assert.Equal(4, _solver.Solve(amount, coins));
    }

    [Fact]
    public void Solve_Example2_Amount3_Coins2_Returns0()
    {
        Assert.Equal(0, _solver.Solve(3, [2]));
    }

    [Fact]
    public void Solve_Example3_Amount10_Coins10_Returns1()
    {
        Assert.Equal(1, _solver.Solve(10, [10]));
    }

    [Fact]
    public void Solve_Amount0_Returns1()
    {
        Assert.Equal(1, _solver.Solve(0, [1, 2, 3]));
    }

    [Fact]
    public void Solve_Amount7_Coins3_5_Returns0()
    {
        Assert.Equal(0, _solver.Solve(7, [3, 5]));
    }
}
