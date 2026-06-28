using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class ContainsDuplicateTests
{
    private readonly ContainsDuplicate _solver = new();

    [Fact]
    public void Solve_HasDuplicate_ReturnsTrue()
    {
        Assert.True(_solver.Solve([1, 2, 3, 1]));
    }

    [Fact]
    public void Solve_NoDuplicate_ReturnsFalse()
    {
        Assert.False(_solver.Solve([1, 2, 3, 4]));
    }

    [Fact]
    public void Solve_Example3_1_1_1_3_3_4_3_2_4_2_ReturnsTrue()
    {
        Assert.True(_solver.Solve([1, 1, 1, 3, 3, 4, 3, 2, 4, 2]));
    }

    [Fact]
    public void Solve_EmptyArray_ReturnsFalse()
    {
        Assert.False(_solver.Solve([]));
    }

    [Fact]
    public void Solve_SingleElement_ReturnsFalse()
    {
        Assert.False(_solver.Solve([1]));
    }
}
