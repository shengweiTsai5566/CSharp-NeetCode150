# Clone Graph

## 解題思路
使用深度優先搜尋（DFS）搭配雜湊表（Dictionary）來記錄已複製的節點，避免重複複製和無窮迴圈。

1. 從給定的節點開始，對每個節點進行 DFS。
2. 如果節點已經被複製過，直接回傳對應的拷貝。
3. 否則，建立一個新節點（值相同），存入雜湊表，然後遞迴複製所有鄰居節點。

也可以使用 BFS 搭配佇列來實作，概念相同。

## 時間複雜度
- **時間**: O(V + E) — V 為節點數，E 為邊數，需訪問每個節點和邊一次
- **空間**: O(V) — 需要雜湊表儲存所有節點的拷貝，以及遞迴呼叫棧的空間

## 程式碼

```csharp
public class CloneGraph
{
    private Dictionary<Node, Node> _visited = new();

    public Node Solve(Node node)
    {
        if (node == null) return null;

        if (_visited.ContainsKey(node))
            return _visited[node];

        var clone = new Node(node.val);
        _visited[node] = clone;

        foreach (var neighbor in node.neighbors)
        {
            clone.neighbors.Add(Solve(neighbor));
        }

        return clone;
    }
}
```
