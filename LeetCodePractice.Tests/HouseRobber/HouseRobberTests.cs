using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class HouseRobberTests
{
    private readonly HouseRobber _solver = new();

    [Fact]
    public void Solve_Example1_1_2_3_1_Returns4()
    {
        int[] nums = [1, 2, 3, 1];
        Assert.Equal(4, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_Example2_2_7_9_3_1_Returns12()
    {
        int[] nums = [2, 7, 9, 3, 1];
        Assert.Equal(12, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_SingleHouse_ReturnsItsValue()
    {
        Assert.Equal(5, _solver.Solve([5]));
    }

    [Fact]
    public void Solve_TwoHouses_ReturnsMax()
    {
        Assert.Equal(4, _solver.Solve([2, 4]));
    }

    [Fact]
    public void Solve_EmptyArray_Returns0()
    {
        Assert.Equal(0, _solver.Solve([]));
    }
}
