using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class SingleNumberTests
{
    private readonly SingleNumber _solver = new();

    [Fact]
    public void Solve_Example1_2_2_1_Returns1()
    {
        int[] nums = [2, 2, 1];
        Assert.Equal(1, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_Example2_4_1_2_1_2_Returns4()
    {
        int[] nums = [4, 1, 2, 1, 2];
        Assert.Equal(4, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_Example3_1_Returns1()
    {
        Assert.Equal(1, _solver.Solve([1]));
    }

    [Fact]
    public void Solve_TwoSame_Returns0()
    {
        Assert.Equal(0, _solver.Solve([5, 5]));
    }

    [Fact]
    public void Solve_ThreeWithSingle_ReturnsSingle()
    {
        Assert.Equal(3, _solver.Solve([1, 2, 1, 2, 3]));
    }
}
