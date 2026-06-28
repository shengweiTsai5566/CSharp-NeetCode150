using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class CopyListWithRandomPointerTests
{
    private readonly CopyListWithRandomPointer _solver = new();

    private Node MakeList(int[][] data)
    {
        if (data.Length == 0) return null!;
        var nodes = new Node[data.Length];
        for (int i = 0; i < data.Length; i++)
            nodes[i] = new Node(data[i][0]);
        for (int i = 0; i < data.Length; i++)
        {
            if (i < data.Length - 1)
                nodes[i].next = nodes[i + 1];
            if (data[i][1] != -1)
                nodes[i].random = nodes[data[i][1]];
        }
        return nodes[0];
    }

    [Fact]
    public void Solve_Example1_7_0_4_Neg1_ReturnsDeepCopy()
    {
        var head = MakeList([[7, -1], [13, 0], [11, 4], [10, 2], [1, 0]]);
        var cloned = _solver.Solve(head);
        Assert.NotNull(cloned);
        Assert.NotSame(head, cloned);
        var cur = cloned;
        while (cur != null)
        {
            Assert.NotNull(cur.next);
            cur = cur.next;
        }
    }

    [Fact]
    public void Solve_SingleNode_ReturnsClone()
    {
        var head = new Node(1);
        var cloned = _solver.Solve(head);
        Assert.NotNull(cloned);
        Assert.NotSame(head, cloned);
        Assert.Equal(1, cloned.val);
        Assert.Null(cloned.random);
        Assert.Null(cloned.next);
    }

    [Fact]
    public void Solve_Null_ReturnsNull()
    {
        Assert.Null(_solver.Solve(null!));
    }

    [Fact]
    public void Solve_TwoNodesWithRandom_ReturnsClone()
    {
        var n1 = new Node(1);
        var n2 = new Node(2);
        n1.next = n2;
        n1.random = n2;
        n2.random = n2;
        var cloned = _solver.Solve(n1);
        Assert.NotSame(n1, cloned);
        Assert.NotSame(n2, cloned!.next);
        Assert.Same(cloned.next, cloned.random);
        Assert.Same(cloned.next, cloned.next!.random);
    }
}
