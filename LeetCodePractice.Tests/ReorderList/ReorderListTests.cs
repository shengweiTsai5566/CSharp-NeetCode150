using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class ReorderListTests
{
    private readonly ReorderList _solver = new();

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
    public void Solve_Example1_1_2_3_4_Returns1_4_2_3()
    {
        var head = MakeList(1, 2, 3, 4);
        _solver.Solve(head);
        Assert.Equal(new List<int> { 1, 4, 2, 3 }, ToList(head));
    }

    [Fact]
    public void Solve_Example2_1_2_3_4_5_Returns1_5_2_4_3()
    {
        var head = MakeList(1, 2, 3, 4, 5);
        _solver.Solve(head);
        Assert.Equal(new List<int> { 1, 5, 2, 4, 3 }, ToList(head));
    }

    [Fact]
    public void Solve_SingleNode_NoChange()
    {
        var head = MakeList(1);
        _solver.Solve(head);
        Assert.Equal(new List<int> { 1 }, ToList(head));
    }

    [Fact]
    public void Solve_TwoNodes_NoChange()
    {
        var head = MakeList(1, 2);
        _solver.Solve(head);
        Assert.Equal(new List<int> { 1, 2 }, ToList(head));
    }
}
