using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class DiameterOfBinaryTreeTests
{
    private readonly DiameterOfBinaryTree _solver = new();

    [Fact]
    public void Solve_Example1_Returns3()
    {
        var root = new TreeNode(1)
        {
            left = new TreeNode(2)
            {
                left = new TreeNode(4),
                right = new TreeNode(5)
            },
            right = new TreeNode(3)
        };
        Assert.Equal(3, _solver.Solve(root));
    }

    [Fact]
    public void Solve_Example2_SingleNode_Returns0()
    {
        Assert.Equal(0, _solver.Solve(new TreeNode(1)));
    }

    [Fact]
    public void Solve_LinearTree_ReturnsHeight()
    {
        var root = new TreeNode(1)
        {
            right = new TreeNode(2)
            {
                right = new TreeNode(3)
                {
                    right = new TreeNode(4)
                }
            }
        };
        Assert.Equal(3, _solver.Solve(root));
    }

    [Fact]
    public void Solve_Null_Returns0()
    {
        Assert.Equal(0, _solver.Solve(null!));
    }

    [Fact]
    public void Solve_TwoNodes_Returns1()
    {
        var root = new TreeNode(1)
        {
            left = new TreeNode(2)
        };
        Assert.Equal(1, _solver.Solve(root));
    }
}
