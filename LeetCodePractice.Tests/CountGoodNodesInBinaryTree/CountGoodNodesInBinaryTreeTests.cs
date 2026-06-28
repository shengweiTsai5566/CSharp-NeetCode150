using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class CountGoodNodesInBinaryTreeTests
{
    private readonly CountGoodNodesInBinaryTree _solver = new();

    [Fact]
    public void Solve_Example1_Returns4()
    {
        var root = new TreeNode(3)
        {
            left = new TreeNode(1)
            {
                left = new TreeNode(3)
            },
            right = new TreeNode(4)
            {
                left = new TreeNode(1),
                right = new TreeNode(5)
            }
        };
        Assert.Equal(4, _solver.Solve(root));
    }

    [Fact]
    public void Solve_Example2_Returns3()
    {
        var root = new TreeNode(3)
        {
            left = new TreeNode(3)
            {
                left = new TreeNode(4),
                right = new TreeNode(2)
            }
        };
        Assert.Equal(3, _solver.Solve(root));
    }

    [Fact]
    public void Solve_Example3_Returns1()
    {
        Assert.Equal(1, _solver.Solve(new TreeNode(1)));
    }

    [Fact]
    public void Solve_Null_Returns0()
    {
        Assert.Equal(0, _solver.Solve(null!));
    }

    [Fact]
    public void Solve_Decreasing_OnlyRootIsGood()
    {
        var root = new TreeNode(5)
        {
            left = new TreeNode(4)
            {
                left = new TreeNode(3)
            }
        };
        Assert.Equal(1, _solver.Solve(root));
    }
}
