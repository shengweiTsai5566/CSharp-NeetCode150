using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class SubsetsTests
{
    private readonly Subsets _solver = new();

    [Fact]
    public void Solve_Example1_1_2_3_Returns8Subsets()
    {
        int[] nums = [1, 2, 3];
        var result = _solver.Solve(nums);
        Assert.Equal(8, result.Count);
        Assert.Contains(result, s => s.SequenceEqual(new List<int>()));
        Assert.Contains(result, s => s.SequenceEqual(new List<int> { 1 }));
        Assert.Contains(result, s => s.SequenceEqual(new List<int> { 2 }));
        Assert.Contains(result, s => s.SequenceEqual(new List<int> { 3 }));
        Assert.Contains(result, s => s.SequenceEqual(new List<int> { 1, 2 }));
        Assert.Contains(result, s => s.SequenceEqual(new List<int> { 1, 3 }));
        Assert.Contains(result, s => s.SequenceEqual(new List<int> { 2, 3 }));
        Assert.Contains(result, s => s.SequenceEqual(new List<int> { 1, 2, 3 }));
    }

    [Fact]
    public void Solve_Example2_0_Returns2Subsets()
    {
        var result = _solver.Solve([0]);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void Solve_Empty_ReturnsEmptySubset()
    {
        var result = _solver.Solve([]);
        Assert.Single(result);
        Assert.Empty(result[0]);
    }
}
