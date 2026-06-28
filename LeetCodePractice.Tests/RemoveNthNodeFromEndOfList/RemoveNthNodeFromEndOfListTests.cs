using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class RemoveNthNodeFromEndOfListTests
{
    private readonly RemoveNthNodeFromEndOfList _solver = new();

    private ListNode MakeList(params int[] vals)
    {
        if (vals.Length == 0) return null!;
        var head = new ListNode(vals[0]);
        var cur = head;
        for (int i = 1; i < vals.Length; i++)
        {
            cur.next = new ListNode(vals[i]);
            cur = cur.next;
        }
        return head;
    }

    private List<int> ToList(ListNode? node)
    {
        var result = new List<int>();
        while (node != null)
        {
            result.Add(node.val);
            node = node.next;
        }
        return result;
    }

    [Fact]
    public void Solve_Example1_1_2_3_4_5_N2_Returns1_2_3_5()
    {
        var head = MakeList(1, 2, 3, 4, 5);
        var result = _solver.Solve(head, 2);
        Assert.Equal(new List<int> { 1, 2, 3, 5 }, ToList(result));
    }

    [Fact]
    public void Solve_Example2_1_N1_ReturnsEmpty()
    {
        var head = MakeList(1);
        Assert.Null(_solver.Solve(head, 1));
    }

    [Fact]
    public void Solve_Example3_1_2_N1_Returns1()
    {
        var head = MakeList(1, 2);
        var result = _solver.Solve(head, 1);
        Assert.Equal(new List<int> { 1 }, ToList(result));
    }

    [Fact]
    public void Solve_RemoveHead_ReturnsRest()
    {
        var head = MakeList(1, 2, 3);
        var result = _solver.Solve(head, 3);
        Assert.Equal(new List<int> { 2, 3 }, ToList(result));
    }
}
