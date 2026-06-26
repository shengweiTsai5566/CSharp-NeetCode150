# Device Parameter Cache（高效能設備參數 LRU 快取）

**對應 LeetCode：** LC 146 LRU Cache

**面試難度：** Medium-Hard（Senior 級 GC 優化題）

---

## 解題思路

### 問題理解
機台高速運作時需頻繁讀取晶圓幾何修正參數。為了防止記憶體洩漏（Memory Leak）與頻繁 GC，快取必須：
- 有容量限制
- **嚴禁在更新時頻繁 new 物件**
- 支援 O(1) 的 Get 與 Put

### Senior 實作重點：Array-based Doubly Linked List

一般 LeetCode 解法使用 `LinkedListNode`，但頻繁的 Put 會導致大量 Heap 配置，引發 GC 停頓。

**面試官期待的方案**：用預先配置的 struct 陣列模擬雙向鏈結串列：

1. **預先配置**：在建構子中配置固定大小的 `Node[]` 陣列（Array Pool 概念）
2. **struct 節點**：每個節點包含 `Key`、`Value`、`Prev`（前驅索引）、`Next`（後繼索引）
3. **空閒列表（Free List）**：用 `_freeStack` 或鏈結串列追蹤可重用的節點位置
4. **Dictionary 映射**：`Dictionary<int, int>` 儲存 Key → 節點索引的對應

### 演算法步驟

**Get(key)**：
1. 從 Dictionary 取得節點索引，若不存在回傳 -1
2. 將該節點移到鏈結串列頭部（標記為最近使用）
3. 回傳節點的 Value

**Put(key, value)**：
1. 若 Key 已存在：更新 Value，移到頭部
2. 若 Key 不存在：
   - 從 Free List 取得一個空節點（若已滿則淘汰尾部節點）
   - 寫入 Key/Value
   - 插入鏈結串列頭部
   - 更新 Dictionary

---

## 時間複雜度

| 操作 | 複雜度 |
|------|--------|
| Get | **O(1)** |
| Put | **O(1)** |
| 空間 | **O(capacity)** |

## 空間複雜度

- **一般 LinkedList 版本**：O(n) — 每個節點是 Heap 物件，有 GC 壓力
- **Array-based 版本**：O(n) — 預先配置陣列，**零 GC 分配**

---

## 完整解答程式碼（Array-based 版本）

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class DeviceParameterCache
{
    private struct CacheNode
    {
        public int Key;
        public int Value;
        public int Prev;
        public int Next;
    }

    private readonly CacheNode[] _nodes;
    private readonly Dictionary<int, int> _map; // key → node index
    private readonly int _capacity;
    private int _head;      // 最近使用的節點索引
    private int _tail;      // 最久未使用的節點索引
    private int _free;      // 空閒列表頭部索引
    private int _count;

    public DeviceParameterCache(int capacity)
    {
        _capacity = capacity;
        _nodes = new CacheNode[capacity];
        _map = new Dictionary<int, int>(capacity);

        // 初始化空閒列表：所有節點位置都可用
        for (int i = 0; i < capacity - 1; i++)
            _nodes[i].Next = i + 1;

        _nodes[capacity - 1].Next = -1;
        _free = 0;
        _head = -1;
        _tail = -1;
        _count = 0;
    }

    public int Get(int key)
    {
        if (!_map.TryGetValue(key, out int idx))
            return -1;

        MoveToHead(idx);
        return _nodes[idx].Value;
    }

    public void Put(int key, int value)
    {
        if (_map.TryGetValue(key, out int idx))
        {
            _nodes[idx].Value = value;
            MoveToHead(idx);
            return;
        }

        // 需要新節點
        int newNodeIdx;

        if (_count >= _capacity)
        {
            // 淘汰最久未使用（尾部）
            newNodeIdx = _tail;
            _map.Remove(_nodes[newNodeIdx].Key);
            RemoveTail();
        }
        else
        {
            // 從 Free List 取得節點
            newNodeIdx = _free;
            _free = _nodes[_free].Next;
            _count++;
        }

        _nodes[newNodeIdx] = new CacheNode { Key = key, Value = value, Prev = -1, Next = -1 };
        _map[key] = newNodeIdx;
        AddToHead(newNodeIdx);
    }

    private void MoveToHead(int idx)
    {
        if (idx == _head) return;

        // 從原位置移除
        RemoveNode(idx);
        // 插入頭部
        AddToHead(idx);
    }

    private void RemoveNode(int idx)
    {
        int prev = _nodes[idx].Prev;
        int next = _nodes[idx].Next;

        if (prev != -1) _nodes[prev].Next = next;
        else _head = next;

        if (next != -1) _nodes[next].Prev = prev;
        else _tail = prev;
    }

    private void AddToHead(int idx)
    {
        _nodes[idx].Next = _head;
        _nodes[idx].Prev = -1;

        if (_head != -1) _nodes[_head].Prev = idx;
        _head = idx;

        if (_tail == -1) _tail = idx;
    }

    private void RemoveTail()
    {
        int newTail = _nodes[_tail].Prev;
        if (newTail != -1) _nodes[newTail].Next = -1;
        else _head = -1;

        _tail = newTail;
    }
}
```

---

## 面試重點提示

| 問題 | 你的回答 |
|------|---------|
| 為什麼不用 `LinkedListNode`？ | 每個 `new LinkedListNode()` 都在 Heap 上分配，頻繁 Put 會觸發 GC，在設備控制中是致命缺點 |
| Array-based 的優勢？ | 預先配置連續記憶體、Zero-allocation、Cache locality 更好 |
| Free List 的作用？ | O(1) 取得空閒節點位置，避免搜尋 |
| 還有其他改進？ | 可以使用 `MemoryPool<T>` 或 `ArrayPool<T>` 進一步優化 |

> 💡 **面試小提示**：這題在設備控制的 Senior 面試中非常常見，重點不是 LRU 邏輯本身，而是 **你如何避免 GC**。Array-based 方案 + Free List 是面試官最想聽到的答案。
