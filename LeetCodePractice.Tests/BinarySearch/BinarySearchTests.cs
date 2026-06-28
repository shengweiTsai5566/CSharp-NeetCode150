using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class BinarySearchTests
{
    private readonly BinarySearch _solver = new();

    [Fact]
    public void Solve_TargetFound_ReturnsIndex()
    {
        int[] nums = [-1, 0, 3, 5, 9, 12];
        Assert.Equal(4, _solver.Solve(nums, 9));
    }

    [Fact]
    public void Solve_TargetNotFound_ReturnsMinus1()
    {
        int[] nums = [-1, 0, 3, 5, 9, 12];
        Assert.Equal(-1, _solver.Solve(nums, 2));
    }

    [Fact]
    public void Solve_FirstElement_Returns0()
    {
        int[] nums = [1, 3, 5, 7];
        Assert.Equal(0, _solver.Solve(nums, 1));
    }

    [Fact]
    public void Solve_LastElement_ReturnsLastIndex()
    {
        int[] nums = [1, 3, 5, 7];
        Assert.Equal(3, _solver.Solve(nums, 7));
    }

    [Fact]
    public void Solve_EmptyArray_ReturnsMinus1()
    {
        Assert.Equal(-1, _solver.Solve([], 5));
    }

    [Fact]
    public void Solve_SingleElementFound_Returns0()
    {
        Assert.Equal(0, _solver.Solve([5], 5));
    }

    [Fact]
    public void Solve_SingleElementNotFound_ReturnsMinus1()
    {
        Assert.Equal(-1, _solver.Solve([5], 3));
    }
}
