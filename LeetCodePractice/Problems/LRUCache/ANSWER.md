# LRU Cache

## 解題思路
使用雙向鏈結串列（Doubly Linked List）搭配雜湊表（Dictionary）實現 O(1) 的 get 與 put 操作：

- **Dictionary**：以 key 為索引，快速找到對應的鏈結節點。
- **雙向鏈結串列**：維護節點的使用順序，最近使用的節點移到頭部，最久未使用的節點在尾部。

操作說明：
- `get(key)`：若 key 存在，將對應節點移至鏈結串列頭部，並回傳 value；否則回傳 -1。
- `put(key, value)`：若 key 已存在，更新值並移至頭部；若不存在，建立新節點加入頭部。若超出容量，移除尾部節點（LRU 節點）並從 Dictionary 中刪除。

為了簡化邊界處理，使用 dummy head 和 dummy tail 哨兵節點。

## 時間複雜度
- **時間**: O(1) — get 和 put 均為平均 O(1)
- **空間**: O(capacity) — 最多儲存 capacity 個 key-value 對

## 程式碼

```csharp
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class LRUCache
{
    private class DLinkedNode
    {
        public int key;
        public int value;
        public DLinkedNode prev;
        public DLinkedNode next;
    }

    private readonly int _capacity;
    private readonly Dictionary<int, DLinkedNode> _cache;
    private readonly DLinkedNode _head;
    private readonly DLinkedNode _tail;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _cache = new Dictionary<int, DLinkedNode>(capacity);
        _head = new DLinkedNode();
        _tail = new DLinkedNode();
        _head.next = _tail;
        _tail.prev = _head;
    }

    public int Get(int key)
    {
        if (!_cache.TryGetValue(key, out var node))
            return -1;

        MoveToHead(node);
        return node.value;
    }

    public void Put(int key, int value)
    {
        if (_cache.TryGetValue(key, out var node))
        {
            node.value = value;
            MoveToHead(node);
            return;
        }

        var newNode = new DLinkedNode { key = key, value = value };
        _cache.Add(key, newNode);
        AddToHead(newNode);

        if (_cache.Count > _capacity)
        {
            var tail = RemoveTail();
            _cache.Remove(tail.key);
        }
    }

    private void AddToHead(DLinkedNode node)
    {
        node.prev = _head;
        node.next = _head.next;
        _head.next.prev = node;
        _head.next = node;
    }

    private void RemoveNode(DLinkedNode node)
    {
        node.prev.next = node.next;
        node.next.prev = node.prev;
    }

    private void MoveToHead(DLinkedNode node)
    {
        RemoveNode(node);
        AddToHead(node);
    }

    private DLinkedNode RemoveTail()
    {
        var node = _tail.prev;
        RemoveNode(node);
        return node;
    }
}
```
