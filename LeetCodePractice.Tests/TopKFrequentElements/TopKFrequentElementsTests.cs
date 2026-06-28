using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class TopKFrequentElementsTests
{
    private readonly TopKFrequentElements _solver = new();

    [Fact]
    public void Solve_Example1_1_1_1_2_2_3_K2_Returns1_2()
    {
        int[] nums = [1, 1, 1, 2, 2, 3];
        var result = _solver.Solve(nums, 2);
        Assert.Equal(2, result.Length);
        Assert.Contains(1, result);
        Assert.Contains(2, result);
    }

    [Fact]
    public void Solve_Example2_1_K1_Returns1()
    {
        Assert.Equal(new int[] { 1 }, _solver.Solve([1], 1));
    }

    [Fact]
    public void Solve_AllSame_ReturnsThatElement()
    {
        int[] nums = [2, 2, 2, 2];
        var result = _solver.Solve(nums, 1);
        Assert.Equal(new int[] { 2 }, result);
    }

    [Fact]
    public void Solve_AllUnique_ReturnsFirstK()
    {
        int[] nums = [1, 2, 3, 4];
        var result = _solver.Solve(nums, 2);
        Assert.Equal(2, result.Length);
    }
}
