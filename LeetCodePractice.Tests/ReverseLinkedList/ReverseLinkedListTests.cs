using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class ReverseLinkedListTests
{
    private readonly ReverseLinkedList _solver = new();

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
    public void Solve_Example1_1_2_3_4_5_Returns5_4_3_2_1()
    {
        var head = MakeList(1, 2, 3, 4, 5);
        var result = _solver.Solve(head);
        Assert.Equal(new List<int> { 5, 4, 3, 2, 1 }, ToList(result));
    }

    [Fact]
    public void Solve_Example2_1_2_Returns2_1()
    {
        var head = MakeList(1, 2);
        var result = _solver.Solve(head);
        Assert.Equal(new List<int> { 2, 1 }, ToList(result));
    }

    [Fact]
    public void Solve_Empty_ReturnsNull()
    {
        Assert.Null(_solver.Solve(null!));
    }

    [Fact]
    public void Solve_SingleNode_ReturnsSame()
    {
        var head = MakeList(42);
        var result = _solver.Solve(head);
        Assert.Equal(new List<int> { 42 }, ToList(result));
    }
}
