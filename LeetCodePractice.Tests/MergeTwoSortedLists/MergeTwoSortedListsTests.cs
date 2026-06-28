using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class MergeTwoSortedListsTests
{
    private readonly MergeTwoSortedLists _solver = new();

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
    public void Solve_Example1_1_2_4_And_1_3_4_Returns_1_1_2_3_4_4()
    {
        var l1 = MakeList(1, 2, 4);
        var l2 = MakeList(1, 3, 4);
        var result = _solver.Solve(l1, l2);
        Assert.Equal(new List<int> { 1, 1, 2, 3, 4, 4 }, ToList(result));
    }

    [Fact]
    public void Solve_BothEmpty_ReturnsNull()
    {
        Assert.Null(_solver.Solve(null!, null!));
    }

    [Fact]
    public void Solve_OneEmpty_ReturnsTheOther()
    {
        var l1 = MakeList(1, 2, 3);
        var result = _solver.Solve(l1, null!);
        Assert.Equal(new List<int> { 1, 2, 3 }, ToList(result));
    }

    [Fact]
    public void Solve_Interleaved_ReturnsSorted()
    {
        var l1 = MakeList(1, 3, 5);
        var l2 = MakeList(2, 4, 6);
        var result = _solver.Solve(l1, l2);
        Assert.Equal(new List<int> { 1, 2, 3, 4, 5, 6 }, ToList(result));
    }
}
