using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class ReverseNodesInKGroupTests
{
    private readonly ReverseNodesInKGroup _solver = new();

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
    public void Solve_Example1_1_2_3_4_5_K2_Returns2_1_4_3_5()
    {
        var head = MakeList(1, 2, 3, 4, 5);
        var result = _solver.Solve(head, 2);
        Assert.Equal(new List<int> { 2, 1, 4, 3, 5 }, ToList(result));
    }

    [Fact]
    public void Solve_Example2_1_2_3_4_5_K3_Returns3_2_1_4_5()
    {
        var head = MakeList(1, 2, 3, 4, 5);
        var result = _solver.Solve(head, 3);
        Assert.Equal(new List<int> { 3, 2, 1, 4, 5 }, ToList(result));
    }

    [Fact]
    public void Solve_K1_ReturnsSame()
    {
        var head = MakeList(1, 2, 3);
        var result = _solver.Solve(head, 1);
        Assert.Equal(new List<int> { 1, 2, 3 }, ToList(result));
    }

    [Fact]
    public void Solve_ExactMultiple_ReversesAll()
    {
        var head = MakeList(1, 2, 3, 4);
        var result = _solver.Solve(head, 2);
        Assert.Equal(new List<int> { 2, 1, 4, 3 }, ToList(result));
    }
}
