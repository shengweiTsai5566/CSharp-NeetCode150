using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class InvertBinaryTreeTests
{
    private readonly InvertBinaryTree _solver = new();

    private bool IsMirror(TreeNode? a, TreeNode? b)
    {
        if (a == null && b == null) return true;
        if (a == null || b == null) return false;
        return a.val == b.val && IsMirror(a.left, b.right) && IsMirror(a.right, b.left);
    }

    [Fact]
    public void Solve_Example1_InvertsCorrectly()
    {
        var root = new TreeNode(4)
        {
            left = new TreeNode(2) { left = new TreeNode(1), right = new TreeNode(3) },
            right = new TreeNode(7) { left = new TreeNode(6), right = new TreeNode(9) }
        };
        var inverted = _solver.Solve(root);
        Assert.True(IsMirror(root, inverted));
        Assert.Equal(4, inverted.val);
        Assert.Equal(7, inverted.left.val);
        Assert.Equal(2, inverted.right.val);
    }

    [Fact]
    public void Solve_EmptyTree_ReturnsNull()
    {
        Assert.Null(_solver.Solve(null!));
    }

    [Fact]
    public void Solve_SingleNode_ReturnsSameNode()
    {
        var root = new TreeNode(1);
        var result = _solver.Solve(root);
        Assert.Equal(1, result.val);
    }

    [Fact]
    public void Solve_LeftSkewed_BecomesRightSkewed()
    {
        var root = new TreeNode(1) { left = new TreeNode(2) { left = new TreeNode(3) } };
        var result = _solver.Solve(root);
        Assert.Null(result.left);
        Assert.NotNull(result.right);
        Assert.NotNull(result.right.right);
    }
}
