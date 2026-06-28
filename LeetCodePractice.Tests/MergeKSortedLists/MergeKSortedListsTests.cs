using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class MergeKSortedListsTests
{
    private readonly MergeKSortedLists _solver = new();

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
    public void Solve_Example1_ReturnsMerged()
    {
        var lists = new ListNode?[] { MakeList(1, 4, 5), MakeList(1, 3, 4), MakeList(2, 6) };
        var result = _solver.Solve(lists);
        Assert.Equal(new List<int> { 1, 1, 2, 3, 4, 4, 5, 6 }, ToList(result));
    }

    [Fact]
    public void Solve_EmptyArray_ReturnsNull()
    {
        Assert.Null(_solver.Solve([]));
    }

    [Fact]
    public void Solve_SingleList_ReturnsIt()
    {
        var lists = new ListNode?[] { MakeList(1, 2, 3) };
        var result = _solver.Solve(lists);
        Assert.Equal(new List<int> { 1, 2, 3 }, ToList(result));
    }

    [Fact]
    public void Solve_AllEmpty_ReturnsNull()
    {
        var lists = new ListNode?[] { null!, null! };
        Assert.Null(_solver.Solve(lists));
    }
}
