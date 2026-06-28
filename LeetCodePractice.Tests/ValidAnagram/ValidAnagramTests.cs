using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class ValidAnagramTests
{
    private readonly ValidAnagram _solver = new();

    [Fact]
    public void Solve_Example1_Anagram_ReturnsTrue()
    {
        Assert.True(_solver.Solve("anagram", "nagaram"));
    }

    [Fact]
    public void Solve_Example2_NotAnagram_ReturnsFalse()
    {
        Assert.False(_solver.Solve("rat", "car"));
    }

    [Fact]
    public void Solve_EmptyStrings_ReturnsTrue()
    {
        Assert.True(_solver.Solve("", ""));
    }

    [Fact]
    public void Solve_DifferentLengths_ReturnsFalse()
    {
        Assert.False(_solver.Solve("abc", "abcd"));
    }

    [Fact]
    public void Solve_SameString_ReturnsTrue()
    {
        Assert.True(_solver.Solve("abc", "abc"));
    }
}
