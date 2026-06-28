using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class JumpGameTests
{
    private readonly JumpGame _solver = new();

    [Fact]
    public void Solve_Example1_2_3_1_1_4_ReturnsTrue()
    {
        Assert.True(_solver.Solve([2, 3, 1, 1, 4]));
    }

    [Fact]
    public void Solve_Example2_3_2_1_0_4_ReturnsFalse()
    {
        Assert.False(_solver.Solve([3, 2, 1, 0, 4]));
    }

    [Fact]
    public void Solve_SingleElement_ReturnsTrue()
    {
        Assert.True(_solver.Solve([0]));
    }

    [Fact]
    public void Solve_ZeroInMiddle_ReturnsFalse()
    {
        Assert.False(_solver.Solve([2, 0, 0, 1]));
    }

    [Fact]
    public void Solve_LargeJumps_ReturnsTrue()
    {
        Assert.True(_solver.Solve([5, 0, 0, 0, 0, 0]));
    }
}
