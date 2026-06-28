using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class ValidateBinarySearchTreeTests
{
    private readonly ValidateBinarySearchTree _solver = new();

    [Fact]
    public void Solve_Example1_Valid_ReturnsTrue()
    {
        var root = new TreeNode(2) { left = new TreeNode(1), right = new TreeNode(3) };
        Assert.True(_solver.Solve(root));
    }

    [Fact]
    public void Solve_Example2_Invalid_ReturnsFalse()
    {
        var root = new TreeNode(5) { left = new TreeNode(1), right = new TreeNode(4) { left = new TreeNode(3), right = new TreeNode(6) } };
        Assert.False(_solver.Solve(root));
    }

    [Fact]
    public void Solve_LeftSkewedValid_ReturnsTrue()
    {
        var root = new TreeNode(3) { left = new TreeNode(2) { left = new TreeNode(1) } };
        Assert.True(_solver.Solve(root));
    }

    [Fact]
    public void Solve_SingleNode_ReturnsTrue()
    {
        Assert.True(_solver.Solve(new TreeNode(1)));
    }

    [Fact]
    public void Solve_Null_ReturnsTrue()
    {
        Assert.True(_solver.Solve(null!));
    }

    [Fact]
    public void Solve_EqualValue_ReturnsFalse()
    {
        var root = new TreeNode(1) { left = new TreeNode(1) };
        Assert.False(_solver.Solve(root));
    }
}
