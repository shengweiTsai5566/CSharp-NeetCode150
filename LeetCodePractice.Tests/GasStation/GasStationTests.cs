using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class GasStationTests
{
    private readonly GasStation _solver = new();

    [Fact]
    public void Solve_Example1_Returns3()
    {
        int[] gas = [1, 2, 3, 4, 5];
        int[] cost = [3, 4, 5, 1, 2];
        Assert.Equal(3, _solver.Solve(gas, cost));
    }

    [Fact]
    public void Solve_Example2_ReturnsMinus1()
    {
        int[] gas = [2, 3, 4];
        int[] cost = [3, 4, 3];
        Assert.Equal(-1, _solver.Solve(gas, cost));
    }

    [Fact]
    public void Solve_SingleStationPossible_Returns0()
    {
        Assert.Equal(0, _solver.Solve([5], [3]));
    }

    [Fact]
    public void Solve_SingleStationImpossible_ReturnsMinus1()
    {
        Assert.Equal(-1, _solver.Solve([2], [5]));
    }

    [Fact]
    public void Solve_AllStationsWork_Returns0()
    {
        int[] gas = [2, 2, 2];
        int[] cost = [1, 1, 1];
        Assert.Equal(0, _solver.Solve(gas, cost));
    }
}
