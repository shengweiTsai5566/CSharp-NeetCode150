using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class ReverseBitsTests
{
    private readonly ReverseBits _solver = new();

    [Fact]
    public void Solve_Example1_43261596_Returns964176192()
    {
        uint n = 43261596;
        uint expected = 964176192;
        Assert.Equal(expected, _solver.Solve(n));
    }

    [Fact]
    public void Solve_Example2_4294967293_Returns3221225471()
    {
        uint n = 4294967293;
        uint expected = 3221225471;
        Assert.Equal(expected, _solver.Solve(n));
    }

    [Fact]
    public void Solve_Zero_ReturnsZero()
    {
        Assert.Equal(0u, _solver.Solve(0));
    }

    [Fact]
    public void Solve_One_ReturnsBigNumber()
    {
        uint result = _solver.Solve(1);
        Assert.Equal(2147483648, result);
    }
}
