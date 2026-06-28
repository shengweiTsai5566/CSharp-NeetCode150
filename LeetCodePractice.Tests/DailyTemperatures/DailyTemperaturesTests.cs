using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class DailyTemperaturesTests
{
    private readonly DailyTemperatures _solver = new();

    [Fact]
    public void Solve_Example1_Returns1_1_4_2_1_1_0_0()
    {
        int[] temps = [73, 74, 75, 71, 69, 72, 76, 73];
        int[] expected = [1, 1, 4, 2, 1, 1, 0, 0];
        Assert.Equal(expected, _solver.Solve(temps));
    }

    [Fact]
    public void Solve_Example2_30_40_50_60_Returns1_1_1_0()
    {
        Assert.Equal(new int[] { 1, 1, 1, 0 }, _solver.Solve([30, 40, 50, 60]));
    }

    [Fact]
    public void Solve_Example3_Decreasing_ReturnsAllZeros()
    {
        Assert.Equal(new int[] { 0, 0, 0 }, _solver.Solve([30, 20, 10]));
    }

    [Fact]
    public void Solve_SingleDay_Returns0()
    {
        Assert.Equal(new int[] { 0 }, _solver.Solve([50]));
    }

    [Fact]
    public void Solve_Empty_ReturnsEmpty()
    {
        Assert.Empty(_solver.Solve([]));
    }
}
