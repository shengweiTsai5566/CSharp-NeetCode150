using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class LinkedListCycleTests
{
    private readonly LinkedListCycle _solver = new();

    private ListNode MakeList(int[] vals, int pos)
    {
        if (vals.Length == 0) return null!;
        var nodes = new ListNode[vals.Length];
        for (int i = 0; i < vals.Length; i++)
            nodes[i] = new ListNode(vals[i]);
        for (int i = 0; i < vals.Length - 1; i++)
            nodes[i].next = nodes[i + 1];
        if (pos >= 0)
            nodes[vals.Length - 1].next = nodes[pos];
        return nodes[0];
    }

    [Fact]
    public void Solve_HasCycle_ReturnsTrue()
    {
        var head = MakeList([3, 2, 0, -4], 1);
        Assert.True(_solver.Solve(head));
    }

    [Fact]
    public void Solve_Example2_HasCycle_ReturnsTrue()
    {
        var head = MakeList([1, 2], 0);
        Assert.True(_solver.Solve(head));
    }

    [Fact]
    public void Solve_Example3_NoCycle_ReturnsFalse()
    {
        var head = MakeList([1], -1);
        Assert.False(_solver.Solve(head));
    }

    [Fact]
    public void Solve_EmptyList_ReturnsFalse()
    {
        Assert.False(_solver.Solve(null!));
    }

    [Fact]
    public void Solve_NoCycleLongList_ReturnsFalse()
    {
        var head = MakeList([1, 2, 3, 4, 5], -1);
        Assert.False(_solver.Solve(head));
    }
}
