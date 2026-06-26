using System.Collections.Generic;

namespace LeetCodePractice.Problems;

/// <summary>
/// Definition for a graph node (undirected graph) or linked list node with random pointer.
/// For graph: val + neighbors
/// For linked list: val + next + random
/// </summary>
public class Node
{
    public int val;
    public IList<Node> neighbors;
    public Node next;
    public Node random;

    // Graph node constructor
    public Node(int _val)
    {
        val = _val;
        neighbors = new List<Node>();
        next = null!;
        random = null!;
    }

    // Default constructor
    public Node()
    {
        val = 0;
        neighbors = new List<Node>();
        next = null!;
        random = null!;
    }
}
