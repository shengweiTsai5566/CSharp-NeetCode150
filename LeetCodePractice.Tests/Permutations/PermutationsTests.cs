using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class PermutationsTests
{
    private readonly Permutations _solver = new();

    [Fact]
    public void Solve_Example1_1_2_3_Returns6Permutations()
    {
        int[] nums = [1, 2, 3];
        var result = _solver.Solve(nums);
        Assert.Equal(6, result.Count);
    }

    [Fact]
    public void Solve_Example2_0_1_Returns2Permutations()
    {
        var result = _solver.Solve([0, 1]);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void Solve_Example3_1_Returns1Permutation()
    {
        var result = _solver.Solve([1]);
        Assert.Single(result);
        Assert.Equal(new List<int> { 1 }, result[0]);
    }

    [Fact]
    public void Solve_Empty_ReturnsEmpty()
    {
        var result = _solver.Solve([]);
        Assert.Single(result);
        Assert.Empty(result[0]);
    }
}
