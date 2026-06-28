using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class MaximumDepthOfBinaryTreeTests
{
    private readonly MaximumDepthOfBinaryTree _solver = new();

    [Fact]
    public void Solve_Example1_Returns3()
    {
        var root = new TreeNode(3)
        {
            left = new TreeNode(9),
            right = new TreeNode(20) { left = new TreeNode(15), right = new TreeNode(7) }
        };
        Assert.Equal(3, _solver.Solve(root));
    }

    [Fact]
    public void Solve_Example2_SingleNode_Returns1()
    {
        Assert.Equal(1, _solver.Solve(new TreeNode(1)));
    }

    [Fact]
    public void Solve_Null_Returns0()
    {
        Assert.Equal(0, _solver.Solve(null!));
    }

    [Fact]
    public void Solve_LeftSkewed_ReturnsDepth()
    {
        var root = new TreeNode(1) { left = new TreeNode(2) { left = new TreeNode(3) } };
        Assert.Equal(3, _solver.Solve(root));
    }
}
