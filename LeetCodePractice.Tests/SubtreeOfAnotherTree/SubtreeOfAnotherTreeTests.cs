using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class SubtreeOfAnotherTreeTests
{
    private readonly SubtreeOfAnotherTree _solver = new();

    [Fact]
    public void Solve_Example1_ReturnsTrue()
    {
        var root = new TreeNode(3)
        {
            left = new TreeNode(4) { left = new TreeNode(1), right = new TreeNode(2) },
            right = new TreeNode(5)
        };
        var subRoot = new TreeNode(4) { left = new TreeNode(1), right = new TreeNode(2) };
        Assert.True(_solver.Solve(root, subRoot));
    }

    [Fact]
    public void Solve_Example2_ReturnsFalse()
    {
        var root = new TreeNode(3)
        {
            left = new TreeNode(4) { left = new TreeNode(1), right = new TreeNode(2) { left = new TreeNode(0) } },
            right = new TreeNode(5)
        };
        var subRoot = new TreeNode(4) { left = new TreeNode(1), right = new TreeNode(2) };
        Assert.False(_solver.Solve(root, subRoot));
    }

    [Fact]
    public void Solve_SameTree_ReturnsTrue()
    {
        var root = new TreeNode(1) { left = new TreeNode(2) };
        Assert.True(_solver.Solve(root, root));
    }

    [Fact]
    public void Solve_NullSubRoot_ReturnsTrue()
    {
        Assert.True(_solver.Solve(new TreeNode(1), null!));
    }

    [Fact]
    public void Solve_NullRoot_ReturnsFalse()
    {
        Assert.False(_solver.Solve(null!, new TreeNode(1)));
    }
}
