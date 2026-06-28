using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class InterleavingStringTests
{
    private readonly InterleavingString _solver = new();

    [Fact]
    public void Solve_Example1_ReturnsTrue()
    {
        Assert.True(_solver.Solve("aabcc", "dbbca", "aadbbcbcac"));
    }

    [Fact]
    public void Solve_Example2_ReturnsFalse()
    {
        Assert.False(_solver.Solve("aabcc", "dbbca", "aadbbbaccc"));
    }

    [Fact]
    public void Solve_Example3_Empty_ReturnsTrue()
    {
        Assert.True(_solver.Solve("", "", ""));
    }

    [Fact]
    public void Solve_OneEmptyString_ReturnsTrue()
    {
        Assert.True(_solver.Solve("abc", "", "abc"));
    }

    [Fact]
    public void Solve_WrongOrder_ReturnsFalse()
    {
        Assert.False(_solver.Solve("a", "b", "ba"));
    }
}
