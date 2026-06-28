using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class CheapestFlightsWithinKStopsTests
{
    private readonly CheapestFlightsWithinKStops _solver = new();

    [Fact]
    public void Solve_Example1_K1_Returns700()
    {
        // Arrange
        int n = 4;
        int[][] flights = [[0, 1, 100], [1, 2, 100], [2, 0, 100], [1, 3, 600], [2, 3, 200]];
        int src = 0, dst = 3, k = 1;

        // Act
        int result = _solver.Solve(n, flights, src, dst, k);

        // Assert
        Assert.Equal(700, result);
    }

    [Fact]
    public void Solve_Example2_K1_Returns200()
    {
        // Arrange
        int n = 3;
        int[][] flights = [[0, 1, 100], [1, 2, 100], [0, 2, 500]];
        int src = 0, dst = 2, k = 1;

        // Act
        int result = _solver.Solve(n, flights, src, dst, k);

        // Assert
        Assert.Equal(200, result);
    }

    [Fact]
    public void Solve_Example3_K0_Returns500()
    {
        // Arrange
        int n = 3;
        int[][] flights = [[0, 1, 100], [1, 2, 100], [0, 2, 500]];
        int src = 0, dst = 2, k = 0;

        // Act
        int result = _solver.Solve(n, flights, src, dst, k);

        // Assert
        Assert.Equal(500, result);
    }

    [Fact]
    public void Solve_NoPossibleRoute_ReturnsMinus1()
    {
        // Arrange
        int n = 3;
        int[][] flights = [[0, 1, 100], [1, 2, 100]];
        int src = 0, dst = 2, k = 0; // k=0, 不能中轉，但沒有 0→2 直飛

        // Act
        int result = _solver.Solve(n, flights, src, dst, k);

        // Assert
        Assert.Equal(-1, result);
    }

    [Fact]
    public void Solve_DirectFlightOnly_K0_ReturnsPrice()
    {
        // Arrange
        int n = 2;
        int[][] flights = [[0, 1, 300]];
        int src = 0, dst = 1, k = 0;

        // Act
        int result = _solver.Solve(n, flights, src, dst, k);

        // Assert
        Assert.Equal(300, result);
    }

    [Fact]
    public void Solve_MultipleStopsAllowed_CheaperRouteWins()
    {
        // Arrange
        int n = 4;
        int[][] flights = [[0, 1, 50], [1, 2, 50], [2, 3, 50], [0, 3, 500]];
        int src = 0, dst = 3, k = 2; // 可以中轉 2 次，0→1→2→3 花 150

        // Act
        int result = _solver.Solve(n, flights, src, dst, k);

        // Assert
        Assert.Equal(150, result);
    }

    [Fact]
    public void Solve_EmptyFlights_ReturnsMinus1()
    {
        // Arrange
        int n = 3;
        int[][] flights = [];
        int src = 0, dst = 2, k = 2;

        // Act
        int result = _solver.Solve(n, flights, src, dst, k);

        // Assert
        Assert.Equal(-1, result);
    }
}
