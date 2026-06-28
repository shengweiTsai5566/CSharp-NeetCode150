using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class BinaryTreeRightSideViewTests
{
    private readonly BinaryTreeRightSideView _solver = new();

    [Fact]
    public void Solve_Example1_Returns1_3_4()
    {
        var root = new TreeNode(1)
        {
            left = new TreeNode(2)
            {
                right = new TreeNode(5)
            },
            right = new TreeNode(3)
            {
                right = new TreeNode(4)
            }
        };
        var expected = new List<int> { 1, 3, 4 };
        Assert.Equal(expected, _solver.Solve(root));
    }

    [Fact]
    public void Solve_Example2_Returns1_3()
    {
        var root = new TreeNode(1)
        {
            right = new TreeNode(3)
        };
        var expected = new List<int> { 1, 3 };
        Assert.Equal(expected, _solver.Solve(root));
    }

    [Fact]
    public void Solve_EmptyTree_ReturnsEmpty()
    {
        Assert.Empty(_solver.Solve(null!));
    }

    [Fact]
    public void Solve_LeftSkewed_OnlyRootVisible()
    {
        var root = new TreeNode(1)
        {
            left = new TreeNode(2)
            {
                left = new TreeNode(3)
            }
        };
        var result = _solver.Solve(root);
        Assert.Equal(new List<int> { 1, 2, 3 }, result);
    }
}
