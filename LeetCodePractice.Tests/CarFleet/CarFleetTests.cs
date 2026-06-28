using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class CarFleetTests
{
    private readonly CarFleet _solver = new();

    [Fact]
    public void Solve_Example1_Returns3()
    {
        int target = 12;
        int[] position = [10, 8, 0, 5, 3];
        int[] speed = [2, 4, 1, 1, 3];
        Assert.Equal(3, _solver.Solve(target, position, speed));
    }

    [Fact]
    public void Solve_Example2_SingleCar_Returns1()
    {
        Assert.Equal(1, _solver.Solve(10, [3], [3]));
    }

    [Fact]
    public void Solve_AllCarsSameSpeed_ReturnsCount()
    {
        Assert.Equal(2, _solver.Solve(10, [0, 5], [1, 1]));
    }

    [Fact]
    public void Solve_AllCarsCatchUp_Returns1()
    {
        Assert.Equal(1, _solver.Solve(12, [0, 3, 6], [1, 1, 1]));
    }

    [Fact]
    public void Solve_EmptyArrays_Returns0()
    {
        Assert.Equal(0, _solver.Solve(10, [], []));
    }
}
