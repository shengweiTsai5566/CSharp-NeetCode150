using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class AddTwoNumbersTests
{
    private readonly AddTwoNumbers _solver = new();

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

    private List<int> ToList(ListNode node)
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
    public void Solve_Example1_342Plus465_Returns807()
    {
        var l1 = MakeList(2, 4, 3); // 342
        var l2 = MakeList(5, 6, 4); // 465
        var result = _solver.Solve(l1, l2);
        Assert.Equal(new List<int> { 7, 0, 8 }, ToList(result)); // 807
    }

    [Fact]
    public void Solve_ZeroPlusZero_ReturnsZero()
    {
        var l1 = MakeList(0);
        var l2 = MakeList(0);
        var result = _solver.Solve(l1, l2);
        Assert.Equal(new List<int> { 0 }, ToList(result));
    }

    [Fact]
    public void Solve_UnevenLengths_9999999Plus9999_Returns10009998()
    {
        var l1 = MakeList(9, 9, 9, 9, 9, 9, 9); // 9999999
        var l2 = MakeList(9, 9, 9, 9);             // 9999
        var result = _solver.Solve(l1, l2);
        Assert.Equal(new List<int> { 8, 9, 9, 9, 0, 0, 0, 1 }, ToList(result)); // 10009998
    }

    [Fact]
    public void Solve_SingleDigitWithCarry_5Plus5_Returns01()
    {
        var l1 = MakeList(5);
        var l2 = MakeList(5);
        var result = _solver.Solve(l1, l2);
        Assert.Equal(new List<int> { 0, 1 }, ToList(result)); // 10
    }

    [Fact]
    public void Solve_OneListEmpty_ReturnsOtherList()
    {
        var l1 = MakeList(1, 2, 3);
        var result = _solver.Solve(l1, null!);
        Assert.Equal(new List<int> { 1, 2, 3 }, ToList(result));
    }
}
