using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class CombinationSumTests
{
    private readonly CombinationSum _solver = new();

    [Fact]
    public void Solve_Example1_2_3_6_7_Target7_Returns2_2_3_7()
    {
        int[] candidates = [2, 3, 6, 7];
        var result = _solver.Solve(candidates, 7);
        Assert.Equal(2, result.Count);
        Assert.Contains(result, r => r.SequenceEqual(new List<int> { 2, 2, 3 }));
        Assert.Contains(result, r => r.SequenceEqual(new List<int> { 7 }));
    }

    [Fact]
    public void Solve_Example2_2_3_5_Target8_Returns3Combos()
    {
        int[] candidates = [2, 3, 5];
        var result = _solver.Solve(candidates, 8);
        Assert.Equal(3, result.Count);
    }

    [Fact]
    public void Solve_Example3_NoCandidates_Target7_ReturnsEmpty()
    {
        Assert.Empty(_solver.Solve([], 7));
    }

    [Fact]
    public void Solve_Target0_ReturnsEmptyCombination()
    {
        var result = _solver.Solve([1], 0);
        Assert.Single(result);
        Assert.Empty(result[0]);
    }
}
