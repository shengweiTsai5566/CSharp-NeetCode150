using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class GroupAnagramsTests
{
    private readonly GroupAnagrams _solver = new();

    [Fact]
    public void Solve_Example1_Returns3Groups()
    {
        string[] strs = ["eat", "tea", "tan", "ate", "nat", "bat"];
        var result = _solver.Solve(strs);
        Assert.Equal(3, result.Count);
        Assert.Contains(result, g => g.OrderBy(x => x).SequenceEqual(new[] { "ate", "eat", "tea" }));
        Assert.Contains(result, g => g.OrderBy(x => x).SequenceEqual(new[] { "nat", "tan" }));
        Assert.Contains(result, g => g.OrderBy(x => x).SequenceEqual(new[] { "bat" }));
    }

    [Fact]
    public void Solve_Example2_EmptyString_Returns1Group()
    {
        var result = _solver.Solve([""]);
        Assert.Single(result);
        Assert.Equal("", result[0][0]);
    }

    [Fact]
    public void Solve_Example3_SingleString_Returns1Group()
    {
        var result = _solver.Solve(["a"]);
        Assert.Single(result);
        Assert.Equal("a", result[0][0]);
    }

    [Fact]
    public void Solve_NoAnagrams_ReturnsGroups()
    {
        var result = _solver.Solve(["abc", "def"]);
        Assert.Equal(2, result.Count);
    }
}
