using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class BinaryTreeMaximumPathSumTests
{
    private readonly BinaryTreeMaximumPathSum _solver = new();

    [Fact]
    public void Solve_Example1_1_2_3_Returns6()
    {
        var root = new TreeNode(1)
        {
            left = new TreeNode(2),
            right = new TreeNode(3)
        };
        Assert.Equal(6, _solver.Solve(root));
    }

    [Fact]
    public void Solve_Example2_Negative_10_9_20_15_7_Returns42()
    {
        var root = new TreeNode(-10)
        {
            left = new TreeNode(9),
            right = new TreeNode(20)
            {
                left = new TreeNode(15),
                right = new TreeNode(7)
            }
        };
        Assert.Equal(42, _solver.Solve(root));
    }

    [Fact]
    public void Solve_SingleNode_ReturnsNodeValue()
    {
        Assert.Equal(-3, _solver.Solve(new TreeNode(-3)));
    }

    [Fact]
    public void Solve_AllNegative_ReturnsMaxSingle()
    {
        var root = new TreeNode(-5)
        {
            left = new TreeNode(-2),
            right = new TreeNode(-3)
        };
        Assert.Equal(-2, _solver.Solve(root));
    }

    [Fact]
    public void Solve_Null_Returns0()
    {
        Assert.Equal(0, _solver.Solve(null!));
    }
}
