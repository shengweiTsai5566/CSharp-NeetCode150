using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class MergeTripletsToFormTargetTripletTests
{
    private readonly MergeTripletsToFormTargetTriplet _solver = new();

    [Fact]
    public void Solve_Example1_ReturnsTrue()
    {
        int[][] triplets = [[2, 5, 3], [1, 8, 4], [1, 7, 5]];
        int[] target = [2, 7, 5];
        Assert.True(_solver.Solve(triplets, target));
    }

    [Fact]
    public void Solve_Example2_ReturnsFalse()
    {
        int[][] triplets = [[3, 4, 5], [4, 5, 6]];
        int[] target = [3, 2, 5];
        Assert.False(_solver.Solve(triplets, target));
    }

    [Fact]
    public void Solve_Example3_ReturnsTrue()
    {
        int[][] triplets = [[2, 5, 3], [2, 3, 4], [1, 2, 5], [5, 2, 3]];
        int[] target = [5, 5, 5];
        Assert.True(_solver.Solve(triplets, target));
    }

    [Fact]
    public void Solve_SingleTripletMatch_ReturnsTrue()
    {
        int[][] triplets = [[1, 2, 3]];
        Assert.True(_solver.Solve(triplets, [1, 2, 3]));
    }
}
