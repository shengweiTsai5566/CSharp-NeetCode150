using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class PalindromePartitioningTests
{
    private readonly PalindromePartitioning _solver = new();

    [Fact]
    public void Solve_Example1_AAB_Returns2Partitions()
    {
        var result = _solver.Solve("aab");
        Assert.Equal(2, result.Count);
        Assert.Contains(result, p => p.SequenceEqual(new List<string> { "a", "a", "b" }));
        Assert.Contains(result, p => p.SequenceEqual(new List<string> { "aa", "b" }));
    }

    [Fact]
    public void Solve_Example2_A_Returns1Partition()
    {
        var result = _solver.Solve("a");
        Assert.Single(result);
        Assert.Equal(new List<string> { "a" }, result[0]);
    }

    [Fact]
    public void Solve_Empty_ReturnsEmpty()
    {
        var result = _solver.Solve("");
        Assert.Single(result);
        Assert.Empty(result[0]);
    }

    [Fact]
    public void Solve_AllPalindrome_ReturnsAll()
    {
        var result = _solver.Solve("aaa");
        Assert.Equal(4, result.Count);
    }
}
