using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class EvaluateReversePolishNotationTests
{
    private readonly EvaluateReversePolishNotation _solver = new();

    [Fact]
    public void Solve_Example1_2_1_Plus_3_Mult_Returns9()
    {
        string[] tokens = ["2", "1", "+", "3", "*"];
        Assert.Equal(9, _solver.Solve(tokens));
    }

    [Fact]
    public void Solve_Example2_4_13_5_Div_Plus_Returns6()
    {
        string[] tokens = ["4", "13", "5", "/", "+"];
        Assert.Equal(6, _solver.Solve(tokens));
    }

    [Fact]
    public void Solve_Example3_Returns22()
    {
        string[] tokens = ["10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+"];
        Assert.Equal(22, _solver.Solve(tokens));
    }

    [Fact]
    public void Solve_SingleNumber_ReturnsIt()
    {
        Assert.Equal(42, _solver.Solve(["42"]));
    }

    [Fact]
    public void Solve_Subtraction_ReturnsCorrect()
    {
        string[] tokens = ["5", "3", "-"];
        Assert.Equal(2, _solver.Solve(tokens));
    }

    [Fact]
    public void Solve_DivisionTruncatesTowardZero()
    {
        string[] tokens = ["10", "3", "/"];
        Assert.Equal(3, _solver.Solve(tokens)); // integer division truncates toward zero
    }
}
