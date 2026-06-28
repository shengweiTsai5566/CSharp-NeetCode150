# LRU Cache 完整引導教學

## 📖 題目

**LeetCode 146 - LRU Cache** (難度：Medium)

設計一個資料結構，實作 Least Recently Used (LRU) 快取機制：

- `LRUCache(int capacity)` — 初始化容量
- `int get(int key)` — 回傳 value；不存在回傳 -1
- `void put(int key, int value)` — 新增或更新；超出容量則淘汰最久未使用的 key

**要求：** `get` 和 `put` 都必須是 **O(1)**。

---

## 🌍 現實應用場景

| 場景 | 說明 |
|------|------|
| 瀏覽器快取 | 暫存圖片/CSS/JS，滿了淘汰最久沒看的網站資源 |
| Redis / Memcached | 記憶體資料庫用 LRU 淘汰舊資料（如 Redis `allkeys-lru`） |
| MySQL InnoDB Buffer Pool | 快取常查詢的資料頁，滿了淘汰最久沒用的頁面 |
| 作業系統 Page Replacement | RAM 不足時決定哪些頁面搬到 swap |
| 後端 API 快取 | 熱門商品/資料快取，避免每次都查資料庫 |

> 💡 LRU 利用「時間局部性（Temporal Locality）」：剛剛用過的資料很可能馬上再用。

---

## 🧠 核心原理

要達到 O(1)，你需要兩種資料結構**搭配使用**：

| 資料結構 | 用途 | 為什麼 O(1) |
|----------|------|-------------|
| `Dictionary<int, DLinkedNode>` | 用 key 快速找到節點 | 雜湊表 |
| 雙向鏈結串列 (Doubly Linked List) | 維護使用順序 | 插入/刪除只需改前後節點的指標 |

### 為什麼不用單向鏈結串列？

單向鏈結串列刪除節點時，需要知道**前一個節點**才能改它的 `next`，但你無法從當前節點 O(1) 找到前一個節點。雙向鏈結串列有 `prev`，可以直接 O(1) 操作。

---

## 🚀 一步一步寫程式

### Step 0 — 內部類別 DLinkedNode

每個節點存 key、value，以及前後指標：

```csharp
private class DLinkedNode
{
    public int key;
    public int value;
    public DLinkedNode prev;
    public DLinkedNode next;
}
```

### Step 1 — 宣告欄位與建構子

```csharp
int _capacity;                          // 快取容量
Dictionary<int, DLinkedNode> _cache;    // O(1) 查找用
DLinkedNode _head;                      // dummy head（哨兵節點）
DLinkedNode _tail;                      // dummy tail（哨兵節點）

public LRUCache(int capacity)
{
    _capacity = capacity;
    _cache = new Dictionary<int, DLinkedNode>(capacity);
    _head = new DLinkedNode();
    _tail = new DLinkedNode();
    _head.next = _tail;     // 串起來：head ←→ tail
    _tail.prev = _head;
}
```

> **為什麼要用 dummy head/tail？**
>
> 空串列時 `_head.next` 和 `_tail.prev` 永遠有值（指向對方），不需要寫 `if (head == null)` 判斷邊界情況，所有操作程式碼統一。

```
初始狀態（你以為是空的）：
  _head          _tail

但實際上已經連好了：
  _head ──────────────→ _tail
  _head ←────────────── _tail
```

這就是**一開始的 2 條線**：
- `_head.next` 指向 `_tail`
- `_tail.prev` 指向 `_head`

> 💡 **這就是 dummy node 的威力！** 你不用判斷串列是不是空的，
> `_head.next` 和 `_tail.prev` 從建構子開始就有值了，所有操作程式碼全部通用！

---

### 🧪 第一次呼叫 `AddToHead(node)` 時（串列為空）

```csharp
node.next = _head.next;        // _head.next 是 _tail，所以 node.next = _tail ✅
node.prev = _head;             // node.prev = _head ✅
node.next.prev = node;         // node.next 是 _tail，所以 _tail.prev = node ✅ ← 🎯 改了 _tail！
node.prev.next = node;         // node.prev 是 _head，所以 _head.next = node ✅
```

結果：
```
_head ──────────────→ node ──────────────→ _tail
_head ←────────────── node ←────────────── _tail
```

串起來了！🎉

> 🔑 **重點：** `node.next.prev = node` 這一行，在串列為空時改的是 `_tail`、在有節點時改的是「第一個節點」，
> **兩種情況都自動處理好了！** 這就是為什麼不需要特別判斷或改 `_tail`。

---

### Step 2 — AddToHead：將節點加到 _head 後面（最新位置）

```csharp
private void AddToHead(DLinkedNode node)
{
    node.next = _head.next;       // node 往後指向「原本的第一個」
    node.prev = _head;            // node 往前指向 head
    node.next.prev = node;        // 「原本的第一個」往前指向 node
    node.prev.next = node;        // head 往後指向 node
}
```

### 🎨 圖解 `AddToHead`

假設串列裡已經有一個節點 A：

```
Step 0: 初始狀態

  _head                   A                    _tail
  ┌─────┐     prev ←───── ┐ ┌─────┐     prev ←───── ┐ ┌─────┐
  │     │ ←────────────── │ │     │ ←────────────── │ │     │
  │     │ ──────────────→ │ │     │ ──────────────→ │ │     │
  └─────┘     next ─────→ └ └─────┘     next ─────→ └ └─────┘
```

現在要插入新節點 **node**，目標變成：

```
  _head ←→ node ←→ A ←→ _tail
```

---

### Step 1: `node.next = _head.next`

把 node 的 **next** 指向 **A**（原本 `_head.next` 就是 A）。

```
                       node
                      ┌─────┐
                      │next─┼──→  A
                      │     │
                      └─────┘
```

### Step 2: `node.prev = _head`

把 node 的 **prev** 指向 **_head**。

```
  _head                node
  ┌─────┐             ┌─────┐
  │     │ ←───────────┼prev │
  │next─┼──→  A       │next─┼──→  A
  └─────┘             └─────┘
```

> ✅ node 自己的兩條線都接好了

---

### Step 3: `node.next.prev = node`

`node.next` = A，所以這行 = **A.prev = node**

把 A 的 **prev** 指向 node。

```
  _head                node                     A
  ┌─────┐             ┌─────┐     prev ←───────┐ ┌─────┐
  │     │ ←───────────┼prev │ ←──────────────── │ │     │
  │next─┼──→  A       │next─┼──→  A            │ │     │
  └─────┘             └─────┘                  └ └─────┘
```

### Step 4: `node.prev.next = node`

`node.prev` = _head，所以這行 = **_head.next = node**

把 _head 的 **next** 指向 node。

```
  _head ──────────────→ node ──────────────→ A
  ┌─────┐             ┌─────┐     prev ←───────┐ ┌─────┐
  │     │ ←───────────┼prev │ ←──────────────── │ │     │
  │next─┼──→ node     │next─┼──→  A            │ │     │
  └─────┘             └─────┘                  └ └─────┘
```

**完成！** 🎉 `_head ←→ node ←→ A ←→ _tail`

---

### 💡 重點記憶法

```
   1             2              3                4
node.next   node.prev    node.next.prev    node.prev.next
= 後面      = 前面      = node (改後面)    = node (改前面)
```

**口訣：「先接自己的兩條線，再去改前後的指向！」**

| 行 | 白話 |
|----|------|
| 1 | node 往後指向「原本的第一個」 |
| 2 | node 往前指向 head |
| 3 | 「原本的第一個」往前指向 node |
| 4 | head 往後指向 node |

> 💡 口訣：**先接好自己的兩條線（next 和 prev），再去改前後節點的指向。**

### Step 3 — RemoveNode：將節點從串列移除

```csharp
private void RemoveNode(DLinkedNode node)
{
    node.prev.next = node.next;   // 前面的跳過 node，指向後面的
    node.next.prev = node.prev;   // 後面的跳過 node，指回前面的
}
```

**只要 2 行，不管 node 在頭部、中間還是尾部都通用！**

#### 🎨 視覺化：三個位置都能用

**刪除中間的 B：**
```
之前： A ←→ B ←→ C

node.prev.next = node.next   → A.next = C  ✅
node.next.prev = node.prev   → C.prev = A  ✅

之後： A ←→ C
```

**刪除第一個 A（緊接在 head 後）：**
```
之前： _head ←→ A ←→ B ←→ _tail

node.prev.next = node.next   → _head.next = B  ✅
node.next.prev = node.prev   → B.prev = _head  ✅

之後： _head ←→ B ←→ _tail
```

**刪除最後一個 C（_tail 前）：**
```
之前： _head ←→ A ←→ B ←→ C ←→ _tail

node.prev.next = node.next   → B.next = _tail  ✅
node.next.prev = node.prev   → _tail.prev = B  ✅

之後： _head ←→ A ←→ B ←→ _tail
```

---

> 💡 **關鍵：** 每個節點都有 `prev` 和 `next`，不需要知道 node 在哪裡。
> 「node 前面的，往後跳過 node，直接連到 node 後面的」
> 「node 後面的，往前跳過 node，直接連到 node 前面的」
> 就這 2 行，放諸四海皆準！

### Step 4 — MoveToHead：把節點移到頭部

```csharp
private void MoveToHead(DLinkedNode node)
{
    RemoveNode(node);   // 從原來位置拆掉
    AddToHead(node);    // 插到 head 後面
}
```

**什麼時候用到？** `get(key)` 或 `put(key)` 更新已存在的 key 時。

---

### 🤔 為什麼永遠只加在 `_head` 之後？

因為我們把串列設計成：

```
_head  ←→ [最新用過的] ←→ [第二新的] ←→ ... ←→ [最久沒用的] ←→ _tail
  ↑                                                       ↑
  └─ 新來的或剛用過的，都插這裡                               └─ 要淘汰就抓這裡
```

#### 🔄 完整的 LRU 運作流程

```
新加入 put(1,1)：
  _head ←→ [1] ←→ _tail

再加入 put(2,2)：
  _head ←→ [2] ←→ [1] ←→ _tail
             ↑最新       ↑最久沒用

呼叫 get(1) → 把 1 搬到 head 後面：
  _head ←→ [1] ←→ [2] ←→ _tail
             ↑最新       ↑最久沒用

容量滿了，put(3,3) → 先加 [3] 到 head 後，再踢掉最尾巴的 [2]：
  _head ←→ [3] ←→ [1] ←→ _tail  →  踢掉 [2]
             ↑最新       ↑最久沒用
```

#### 💡 口訣

> **「新來的插頭，被用的移頭，滿了砍尾巴」**

| 操作 | 動作 |
|------|------|
| 新 `put` | `AddToHead` |
| 被 `get` 或更新 | `MoveToHead`（= `RemoveNode` + `AddToHead`）|
| 滿了 | `RemoveTail` 踢掉 `_tail.prev` |

---

### Step 5 — RemoveTail：移除並回傳最久沒用的節點

```csharp
private DLinkedNode RemoveTail()
{
    var tailNode = _tail.prev;   // _tail 前面的就是最久沒用的
    RemoveNode(tailNode);        // 從串列移除
    return tailNode;             // 回傳，等等要從 Dictionary 也刪掉
}
```

### Step 6 — Get 方法

```csharp
public int Get(int key)
{
    if (_cache.TryGetValue(key, out var node))
    {
        MoveToHead(node);     // 被讀取 → 變成最新用過
        return node.value;
    }
    return -1;
}
```

> ⚠️ 要用 `TryGetValue`，不能用 `_cache[key]`，否則 key 不存在時會拋例外！

### Step 7 — Put 方法

```csharp
public void Put(int key, int value)
{
    if (_cache.TryGetValue(key, out var node))
    {
        // key 已存在 → 更新值，移到頭部
        node.value = value;
        MoveToHead(node);
    }
    else
    {
        // key 不存在 → 建新節點
        var newNode = new DLinkedNode { key = key, value = value };
        _cache[key] = newNode;     // 加入 Dictionary
        AddToHead(newNode);         // 加入串列頭部

        // 超出容量 → 淘汰最久沒用的
        if (_cache.Count > _capacity)
        {
            var tail = RemoveTail();
            _cache.Remove(tail.key);   // Dictionary 也刪掉
        }
    }
}
```

---

## 🔄 完整流程視覺化

以 `capacity = 2` 為例：

```
put(1, 1) → _head ←→ [1] ←→ _tail
put(2, 2) → _head ←→ [2] ←→ [1] ←→ _tail
                         ↑最新    ↑最久
get(1)    → 把 1 搬到 head 後
           _head ←→ [1] ←→ [2] ←→ _tail
                         ↑最新    ↑最久
put(3, 3) → 容量滿了！加 [3] 到 head 後，RemoveTail 踢掉 [2]
           _head ←→ [3] ←→ [1] ←→ _tail   (2 被淘汰)
get(2)    → -1（已被淘汰）
put(4, 4) → 容量滿了！踢掉 [1]
           _head ←→ [4] ←→ [3] ←→ _tail   (1 被淘汰)
```

---

## 📊 時間複雜度分析

| 操作 | 複雜度 | 原因 |
|------|:------:|------|
| `get(key)` | O(1) | Dictionary 查找 → MoveToHead（2 次指標操作）|
| `put(key, value)` | O(1) | Dictionary 查找 → 新增或更新 → 可能 RemoveTail |

**空間複雜度：** O(capacity) — 最多存 capacity 個節點

---

## 💡 常見錯誤

| 錯誤寫法 | 問題 | 正確寫法 |
|----------|------|----------|
| `_cache[key]` 取值 | key 不存在會拋例外 | `_cache.TryGetValue(key, out var node)` |
| 忘記加淘汰檢查 | 超出容量不會淘汰 | `if (_cache.Count > _capacity)` + `RemoveTail()` |
| 只用 `RemoveNode` 不用 `RemoveTail` | 不知道要刪誰 | 永遠刪 `_tail.prev`（最久沒用） |
| 沒從 Dictionary 刪除 | 節點被移除了但 Dictionary 還有 | `_cache.Remove(tail.key)` |

---

## 🎯 總結

```
     新來的插頭 (AddToHead)
     被用的移頭 (MoveToHead)
     滿了砍尾巴 (RemoveTail)
         + Dictionary 同步刪除
```

LRU Cache 的精髓 = **雙向鏈結串列管順序 + Dictionary 管查找**，兩者搭配，O(1) 達成！
