using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class ReconstructItineraryTests
{
    private readonly ReconstructItinerary _solver = new();

    [Fact]
    public void Solve_Example1_ReturnsCorrect()
    {
        var tickets = new List<IList<string>> { new List<string> { "MUC", "LHR" }, new List<string> { "JFK", "MUC" }, new List<string> { "SFO", "SJC" }, new List<string> { "LHR", "SFO" } };
        var result = _solver.Solve(tickets);
        Assert.Equal(new List<string> { "JFK", "MUC", "LHR", "SFO", "SJC" }, result);
    }

    [Fact]
    public void Solve_Example2_ReturnsCorrect()
    {
        var tickets = new List<IList<string>> { new List<string> { "JFK", "SFO" }, new List<string> { "JFK", "ATL" }, new List<string> { "SFO", "ATL" }, new List<string> { "ATL", "JFK" }, new List<string> { "ATL", "SFO" } };
        var result = _solver.Solve(tickets);
        Assert.Equal(new List<string> { "JFK", "ATL", "JFK", "SFO", "ATL", "SFO" }, result);
    }

    [Fact]
    public void Solve_SingleTicket_ReturnsIt()
    {
        var tickets = new List<IList<string>> { new List<string> { "JFK", "NRT" } };
        var result = _solver.Solve(tickets);
        Assert.Equal(new List<string> { "JFK", "NRT" }, result);
    }
}
