using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class KthSmallestElementInBSTTests
{
    private readonly KthSmallestElementInBST _solver = new();

    [Fact]
    public void Solve_Example1_3_1_4_Null_2_K1_Returns1()
    {
        var root = new TreeNode(3)
        {
            left = new TreeNode(1) { right = new TreeNode(2) },
            right = new TreeNode(4)
        };
        Assert.Equal(1, _solver.Solve(root, 1));
    }

    [Fact]
    public void Solve_Example2_5_3_6_2_4_N_N_1_K3_Returns3()
    {
        var root = new TreeNode(5)
        {
            left = new TreeNode(3)
            {
                left = new TreeNode(2) { left = new TreeNode(1) },
                right = new TreeNode(4)
            },
            right = new TreeNode(6)
        };
        Assert.Equal(3, _solver.Solve(root, 3));
    }

    [Fact]
    public void Solve_SingleNode_ReturnsItsValue()
    {
        Assert.Equal(1, _solver.Solve(new TreeNode(1), 1));
    }

    [Fact]
    public void Solve_LeftSkewed_Kth_ReturnsCorrect()
    {
        var root = new TreeNode(3)
        {
            left = new TreeNode(2)
            {
                left = new TreeNode(1)
            }
        };
        Assert.Equal(2, _solver.Solve(root, 2));
    }
}
