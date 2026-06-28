using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class ConstructBinaryTreeFromPreorderAndInorderTests
{
    private readonly ConstructBinaryTreeFromPreorderAndInorder _solver = new();

    private List<int> Inorder(TreeNode? node)
    {
        if (node == null) return new List<int>();
        var result = new List<int>();
        result.AddRange(Inorder(node.left));
        result.Add(node.val);
        result.AddRange(Inorder(node.right));
        return result;
    }

    private List<int> Preorder(TreeNode? node)
    {
        if (node == null) return new List<int>();
        var result = new List<int>();
        result.Add(node.val);
        result.AddRange(Preorder(node.left));
        result.AddRange(Preorder(node.right));
        return result;
    }

    [Fact]
    public void Solve_Example1_ReturnsTree()
    {
        int[] preorder = [3, 9, 20, 15, 7];
        int[] inorder = [9, 3, 15, 20, 7];
        var root = _solver.Solve(preorder, inorder);
        Assert.NotNull(root);
        Assert.Equal(new List<int> { 3, 9, 20, 15, 7 }, Preorder(root));
        Assert.Equal(new List<int> { 9, 3, 15, 20, 7 }, Inorder(root));
    }

    [Fact]
    public void Solve_SingleNode_ReturnsNode()
    {
        var root = _solver.Solve([1], [1]);
        Assert.NotNull(root);
        Assert.Equal(1, root.val);
    }

    [Fact]
    public void Solve_Empty_ReturnsNull()
    {
        Assert.Null(_solver.Solve([], []));
    }

    [Fact]
    public void Solve_LeftSkewed_ReturnsTree()
    {
        int[] preorder = [3, 2, 1];
        int[] inorder = [1, 2, 3];
        var root = _solver.Solve(preorder, inorder);
        Assert.NotNull(root);
        Assert.Equal(3, root.val);
        Assert.Equal(2, root.left!.val);
        Assert.Equal(1, root.left!.left!.val);
    }
}
