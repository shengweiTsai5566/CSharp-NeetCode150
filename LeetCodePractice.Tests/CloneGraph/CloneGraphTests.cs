using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class CloneGraphTests
{
    private readonly CloneGraph _solver = new();

    private Node BuildGraph(int[][] adjList)
    {
        if (adjList.Length == 0) return null!;
        var nodes = new Node[adjList.Length];
        for (int i = 0; i < adjList.Length; i++)
            nodes[i] = new Node(i + 1);
        for (int i = 0; i < adjList.Length; i++)
            foreach (var neighbor in adjList[i])
                nodes[i].neighbors.Add(nodes[neighbor - 1]);
        return nodes[0];
    }

    private List<int> BfsValues(Node node)
    {
        if (node == null) return new List<int>();
        var visited = new HashSet<int>();
        var queue = new Queue<Node>();
        queue.Enqueue(node);
        visited.Add(node.val);
        var result = new List<int>();
        while (queue.Count > 0)
        {
            var cur = queue.Dequeue();
            result.Add(cur.val);
            foreach (var n in cur.neighbors)
            {
                if (!visited.Contains(n.val))
                {
                    visited.Add(n.val);
                    queue.Enqueue(n);
                }
            }
        }
        result.Sort();
        return result;
    }

    [Fact]
    public void Solve_Example1_4Nodes_ReturnsClone()
    {
        var node = BuildGraph([[2, 4], [1, 3], [2, 4], [1, 3]]);
        var cloned = _solver.Solve(node);
        Assert.NotNull(cloned);
        Assert.NotSame(node, cloned);
        Assert.Equal(BfsValues(node), BfsValues(cloned));
    }

    [Fact]
    public void Solve_SingleNode_ReturnsClone()
    {
        var node = new Node(1);
        var cloned = _solver.Solve(node);
        Assert.NotNull(cloned);
        Assert.NotSame(node, cloned);
        Assert.Equal(1, cloned.val);
        Assert.Empty(cloned.neighbors);
    }

    [Fact]
    public void Solve_Null_ReturnsNull()
    {
        Assert.Null(_solver.Solve(null!));
    }

    [Fact]
    public void Solve_TwoNodes_ReturnsClone()
    {
        var n1 = new Node(1);
        var n2 = new Node(2);
        n1.neighbors.Add(n2);
        n2.neighbors.Add(n1);
        var cloned = _solver.Solve(n1);
        Assert.NotSame(n1, cloned);
        Assert.Equal(1, cloned!.val);
        Assert.Single(cloned.neighbors);
        Assert.Equal(2, cloned.neighbors[0].val);
        Assert.NotSame(n2, cloned.neighbors[0]);
    }
}
