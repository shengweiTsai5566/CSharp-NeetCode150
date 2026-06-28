using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class ThreeSumTests
{
    private readonly ThreeSum _solver = new();

    [Fact]
    public void Solve_Example1_Minus1_0_1_2_Minus1_Minus4_Returns2Triplets()
    {
        int[] nums = [-1, 0, 1, 2, -1, -4];
        var result = _solver.Solve(nums);
        Assert.Equal(2, result.Count);
        Assert.Contains(result, t => t.SequenceEqual(new List<int> { -1, -1, 2 }));
        Assert.Contains(result, t => t.SequenceEqual(new List<int> { -1, 0, 1 }));
    }

    [Fact]
    public void Solve_Example2_0_1_1_ReturnsEmpty()
    {
        Assert.Empty(_solver.Solve([0, 1, 1]));
    }

    [Fact]
    public void Solve_Example3_0_0_0_Returns0_0_0()
    {
        var result = _solver.Solve([0, 0, 0]);
        Assert.Single(result);
        Assert.Equal(new List<int> { 0, 0, 0 }, result[0]);
    }

    [Fact]
    public void Solve_Empty_ReturnsEmpty()
    {
        Assert.Empty(_solver.Solve([]));
    }

    [Fact]
    public void Solve_NoTriplet_ReturnsEmpty()
    {
        Assert.Empty(_solver.Solve([1, 2, 3, 4]));
    }
}
