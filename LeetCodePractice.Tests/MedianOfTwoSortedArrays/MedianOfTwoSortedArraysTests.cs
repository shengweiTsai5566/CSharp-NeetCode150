using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class MedianOfTwoSortedArraysTests
{
    private readonly MedianOfTwoSortedArrays _solver = new();

    [Fact]
    public void Solve_Example1_1_3_And_2_Returns2()
    {
        int[] nums1 = [1, 3];
        int[] nums2 = [2];
        Assert.Equal(2.0, _solver.Solve(nums1, nums2));
    }

    [Fact]
    public void Solve_Example2_1_2_And_3_4_Returns2_5()
    {
        int[] nums1 = [1, 2];
        int[] nums2 = [3, 4];
        Assert.Equal(2.5, _solver.Solve(nums1, nums2));
    }

    [Fact]
    public void Solve_OneEmpty_ReturnsMedianOfOther()
    {
        Assert.Equal(2.0, _solver.Solve([], [1, 2, 3]));
    }

    [Fact]
    public void Solve_BothSingle_ReturnsAverage()
    {
        Assert.Equal(2.0, _solver.Solve([1], [3]));
    }

    [Fact]
    public void Solve_Duplicates_ReturnsCorrect()
    {
        int[] nums1 = [1, 1];
        int[] nums2 = [1, 2];
        Assert.Equal(1.0, _solver.Solve(nums1, nums2));
    }
}
