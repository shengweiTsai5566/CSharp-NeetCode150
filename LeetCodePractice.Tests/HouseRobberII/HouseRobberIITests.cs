using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class HouseRobberIITests
{
    private readonly HouseRobberII _solver = new();

    [Fact]
    public void Solve_Example1_2_3_2_Returns3()
    {
        int[] nums = [2, 3, 2];
        Assert.Equal(3, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_Example2_1_2_3_1_Returns4()
    {
        int[] nums = [1, 2, 3, 1];
        Assert.Equal(4, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_Example3_1_2_3_Returns3()
    {
        int[] nums = [1, 2, 3];
        Assert.Equal(3, _solver.Solve(nums));
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
}
