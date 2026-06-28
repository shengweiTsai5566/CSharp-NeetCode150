using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class BinaryTreeLevelOrderTraversalTests
{
    private readonly BinaryTreeLevelOrderTraversal _solver = new();

    [Fact]
    public void Solve_Example1_ReturnsLevelOrder()
    {
        var root = new TreeNode(3)
        {
            left = new TreeNode(9),
            right = new TreeNode(20)
            {
                left = new TreeNode(15),
                right = new TreeNode(7)
            }
        };
        var expected = new List<IList<int>> { new List<int> { 3 }, new List<int> { 9, 20 }, new List<int> { 15, 7 } };
        var result = _solver.Solve(root);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Solve_EmptyTree_ReturnsEmpty()
    {
        var result = _solver.Solve(null!);
        Assert.Empty(result);
    }

    [Fact]
    public void Solve_SingleNode_ReturnsSingleList()
    {
        var root = new TreeNode(1);
        var result = _solver.Solve(root);
        Assert.Single(result);
        Assert.Equal(1, result[0][0]);
    }

    [Fact]
    public void Solve_LeftSkewed_ReturnsLevels()
    {
        var root = new TreeNode(1)
        {
            left = new TreeNode(2)
            {
                left = new TreeNode(3)
            }
        };
        var result = _solver.Solve(root);
        Assert.Equal(3, result.Count);
    }
}
