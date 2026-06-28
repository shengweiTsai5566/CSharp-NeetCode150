using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class FindTheDuplicateNumberTests
{
    private readonly FindTheDuplicateNumber _solver = new();

    [Fact]
    public void Solve_Example1_1_3_4_2_2_Returns2()
    {
        int[] nums = [1, 3, 4, 2, 2];
        Assert.Equal(2, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_Example2_3_1_3_4_2_Returns3()
    {
        int[] nums = [3, 1, 3, 4, 2];
        Assert.Equal(3, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_Example3_3_3_3_3_3_Returns3()
    {
        int[] nums = [3, 3, 3, 3, 3];
        Assert.Equal(3, _solver.Solve(nums));
    }

    [Fact]
    public void Solve_TwoElements_ReturnsDuplicate()
    {
        Assert.Equal(1, _solver.Solve([1, 1]));
    }
}
