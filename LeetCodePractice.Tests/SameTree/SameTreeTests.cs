using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class SameTreeTests
{
    private readonly SameTree _solver = new();

    [Fact]
    public void Solve_Example1_1_2_3_And_1_2_3_ReturnsTrue()
    {
        var p = new TreeNode(1) { left = new TreeNode(2), right = new TreeNode(3) };
        var q = new TreeNode(1) { left = new TreeNode(2), right = new TreeNode(3) };
        Assert.True(_solver.Solve(p, q));
    }

    [Fact]
    public void Solve_Example2_1_2_And_1_Null_2_ReturnsFalse()
    {
        var p = new TreeNode(1) { left = new TreeNode(2) };
        var q = new TreeNode(1) { right = new TreeNode(2) };
        Assert.False(_solver.Solve(p, q));
    }

    [Fact]
    public void Solve_Example3_1_2_1_And_1_1_2_ReturnsFalse()
    {
        var p = new TreeNode(1) { left = new TreeNode(2), right = new TreeNode(1) };
        var q = new TreeNode(1) { left = new TreeNode(1), right = new TreeNode(2) };
        Assert.False(_solver.Solve(p, q));
    }

    [Fact]
    public void Solve_BothNull_ReturnsTrue()
    {
        Assert.True(_solver.Solve(null!, null!));
    }

    [Fact]
    public void Solve_OneNull_ReturnsFalse()
    {
        Assert.False(_solver.Solve(new TreeNode(1), null!));
    }
}
