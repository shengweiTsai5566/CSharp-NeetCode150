using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class SearchInRotatedSortedArrayTests
{
    private readonly SearchInRotatedSortedArray _solver = new();

    [Fact]
    public void Solve_Example1_4_5_6_7_0_1_2_Target0_Returns4()
    {
        int[] nums = [4, 5, 6, 7, 0, 1, 2];
        Assert.Equal(4, _solver.Solve(nums, 0));
    }

    [Fact]
    public void Solve_Example2_4_5_6_7_0_1_2_Target3_ReturnsMinus1()
    {
        int[] nums = [4, 5, 6, 7, 0, 1, 2];
        Assert.Equal(-1, _solver.Solve(nums, 3));
    }

    [Fact]
    public void Solve_Example3_1_Target0_ReturnsMinus1()
    {
        Assert.Equal(-1, _solver.Solve([1], 0));
    }

    [Fact]
    public void Solve_NotRotated_Found_ReturnsIndex()
    {
        int[] nums = [1, 2, 3, 4, 5];
        Assert.Equal(2, _solver.Solve(nums, 3));
    }

    [Fact]
    public void Solve_RotatedAtEnd_Found()
    {
        int[] nums = [3, 1];
        Assert.Equal(1, _solver.Solve(nums, 1));
    }
}
