using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class PermutationInStringTests
{
    private readonly PermutationInString _solver = new();

    [Fact]
    public void Solve_Example1_ab_ReturnsTrue()
    {
        Assert.True(_solver.Solve("ab", "eidbaooo"));
    }

    [Fact]
    public void Solve_Example2_ab_ReturnsFalse()
    {
        Assert.False(_solver.Solve("ab", "eidboaoo"));
    }

    [Fact]
    public void Solve_ShortS2_ReturnsFalse()
    {
        Assert.False(_solver.Solve("abc", "ab"));
    }

    [Fact]
    public void Solve_ExactMatch_ReturnsTrue()
    {
        Assert.True(_solver.Solve("abc", "cba"));
    }

    [Fact]
    public void Solve_EmptyS1_ReturnsTrue()
    {
        Assert.True(_solver.Solve("", "abc"));
    }
}
