using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class SubsetsIITests
{
    private readonly SubsetsII _solver = new();

    [Fact]
    public void Solve_Example1_1_2_2_Returns4Subsets()
    {
        int[] nums = [1, 2, 2];
        var result = _solver.Solve(nums);
        Assert.Equal(6, result.Count);
    }

    [Fact]
    public void Solve_Example2_0_Returns2Subsets()
    {
        var result = _solver.Solve([0]);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void Solve_AllUnique_Returns8Subsets()
    {
        var result = _solver.Solve([1, 2, 3]);
        Assert.Equal(8, result.Count);
    }

    [Fact]
    public void Solve_Empty_ReturnsEmpty()
    {
        var result = _solver.Solve([]);
        Assert.Single(result);
    }
}
