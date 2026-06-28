using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class PartitionLabelsTests
{
    private readonly PartitionLabels _solver = new();

    [Fact]
    public void Solve_Example1_ababcbacadefegdehijhklij_Returns9_7_8()
    {
        var result = _solver.Solve("ababcbacadefegdehijhklij");
        Assert.Equal(new List<int> { 9, 7, 8 }, result);
    }

    [Fact]
    public void Solve_Example2_eccbbbbdec_Returns10()
    {
        var result = _solver.Solve("eccbbbbdec");
        Assert.Equal(new List<int> { 10 }, result);
    }

    [Fact]
    public void Solve_AllUnique_ReturnsAll_1()
    {
        var result = _solver.Solve("abcdef");
        Assert.Equal(new List<int> { 1, 1, 1, 1, 1, 1 }, result);
    }

    [Fact]
    public void Solve_Empty_ReturnsEmpty()
    {
        Assert.Empty(_solver.Solve(""));
    }
}
