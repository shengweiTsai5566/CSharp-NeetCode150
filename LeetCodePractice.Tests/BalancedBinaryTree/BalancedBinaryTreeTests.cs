using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class BalancedBinaryTreeTests
{
    private readonly BalancedBinaryTree _solver = new();

    [Fact]
    public void Solve_BalancedTree_ReturnsTrue()
    {
        // [3,9,20,null,null,15,7]
        var root = new TreeNode(3)
        {
            left = new TreeNode(9),
            right = new TreeNode(20)
            {
                left = new TreeNode(15),
                right = new TreeNode(7)
            }
        };
        Assert.True(_solver.Solve(root));
    }

    [Fact]
    public void Solve_UnbalancedTree_ReturnsFalse()
    {
        // [1,2,2,3,3,null,null,4,4]
        var root = new TreeNode(1)
        {
            left = new TreeNode(2)
            {
                left = new TreeNode(3)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(4)
                },
                right = new TreeNode(3)
            },
            right = new TreeNode(2)
        };
        Assert.False(_solver.Solve(root));
    }

    [Fact]
    public void Solve_EmptyTree_ReturnsTrue()
    {
        Assert.True(_solver.Solve(null!));
    }

    [Fact]
    public void Solve_SingleNode_ReturnsTrue()
    {
        Assert.True(_solver.Solve(new TreeNode(1)));
    }

    [Fact]
    public void Solve_LeftHeavy_ReturnsFalse()
    {
        var root = new TreeNode(1)
        {
            left = new TreeNode(2)
            {
                left = new TreeNode(3)
            }
        };
        Assert.False(_solver.Solve(root));
    }
}
