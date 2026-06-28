using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class LowestCommonAncestorOfBSTTests
{
    private readonly LowestCommonAncestorOfBST _solver = new();

    [Fact]
    public void Solve_Example1_ReturnsNode2()
    {
        var root = new TreeNode(6)
        {
            left = new TreeNode(2)
            {
                left = new TreeNode(0),
                right = new TreeNode(4) { left = new TreeNode(3), right = new TreeNode(5) }
            },
            right = new TreeNode(8) { left = new TreeNode(7), right = new TreeNode(9) }
        };
        var result = _solver.Solve(root, new TreeNode(2), new TreeNode(8));
        Assert.Equal(6, result.val);
    }

    [Fact]
    public void Solve_Example2_ReturnsNode2()
    {
        var root = new TreeNode(6)
        {
            left = new TreeNode(2)
            {
                left = new TreeNode(0),
                right = new TreeNode(4) { left = new TreeNode(3), right = new TreeNode(5) }
            },
            right = new TreeNode(8) { left = new TreeNode(7), right = new TreeNode(9) }
        };
        var result = _solver.Solve(root, new TreeNode(2), new TreeNode(4));
        Assert.Equal(2, result.val);
    }

    [Fact]
    public void Solve_RootIsLCA_ReturnsRoot()
    {
        var root = new TreeNode(5)
        {
            left = new TreeNode(3),
            right = new TreeNode(7)
        };
        var result = _solver.Solve(root, new TreeNode(3), new TreeNode(7));
        Assert.Equal(5, result.val);
    }

    [Fact]
    public void Solve_SingleNode_ReturnsNode()
    {
        var root = new TreeNode(1);
        var result = _solver.Solve(root, new TreeNode(1), new TreeNode(1));
        Assert.Equal(1, result.val);
    }
}
