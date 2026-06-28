using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class CombinationSumIITests
{
    private readonly CombinationSumII _solver = new();

    [Fact]
    public void Solve_Example1_10_1_2_7_6_1_5_Target8_Returns4Combos()
    {
        int[] candidates = [10, 1, 2, 7, 6, 1, 5];
        var result = _solver.Solve(candidates, 8);
        Assert.Equal(4, result.Count);
        Assert.Contains(result, r => r.SequenceEqual(new List<int> { 1, 1, 6 }));
        Assert.Contains(result, r => r.SequenceEqual(new List<int> { 1, 2, 5 }));
        Assert.Contains(result, r => r.SequenceEqual(new List<int> { 1, 7 }));
        Assert.Contains(result, r => r.SequenceEqual(new List<int> { 2, 6 }));
    }

    [Fact]
    public void Solve_Example2_2_5_2_1_2_Target5_Returns2Combos()
    {
        int[] candidates = [2, 5, 2, 1, 2];
        var result = _solver.Solve(candidates, 5);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void Solve_EmptyCandidates_ReturnsEmpty()
    {
        Assert.Empty(_solver.Solve([], 5));
    }

    [Fact]
    public void Solve_NoCombination_ReturnsEmpty()
    {
        Assert.Empty(_solver.Solve([3, 5], 2));
    }
}
