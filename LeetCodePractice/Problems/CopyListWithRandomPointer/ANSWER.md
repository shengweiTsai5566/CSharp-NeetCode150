# Copy List with Random Pointer

## 解題思路
使用 **交錯複製法（Interleaving）** 進行深度拷貝，不需使用額外 Dictionary 儲存映射關係：

1. **第一遍**：遍歷原鏈結串列，為每個原節點建立一個拷貝節點，並將拷貝節點插入在原節點之後。例如：`A → A' → B → B' → C → C'`。
2. **第二遍**：遍歷交錯後的鏈結串列，設置每個拷貝節點的 `random` 指標。若 `node.random` 不為 null，則 `node.next.random = node.random.next`。
3. **第三遍**：將交錯串列拆分回原串列與拷貝串列，還原 `next` 指標。

此方法達到 O(1) 額外空間（不計輸出空間）。

## 時間複雜度
- **時間**: O(n) — 三遍線性遍歷
- **空間**: O(1) — 不使用額外的資料結構（不計輸出空間）

## 程式碼

```csharp
namespace LeetCodePractice.Problems;

public class CopyListWithRandomPointer
{
    public Node Solve(Node head)
    {
        if (head == null) return null!;

        // Step 1: Interleave copied nodes
        Node curr = head;
        while (curr != null)
        {
            Node copy = new Node(curr.val);
            copy.next = curr.next;
            curr.next = copy;
            curr = copy.next;
        }

        // Step 2: Set random pointers for copied nodes
        curr = head;
        while (curr != null)
        {
            if (curr.random != null)
                curr.next.random = curr.random.next;
            curr = curr.next.next;
        }

        // Step 3: Separate original and copied lists
        Node dummy = new Node();
        Node copyCurr = dummy;
        curr = head;
        while (curr != null)
        {
            Node copy = curr.next;
            curr.next = copy.next;
            copyCurr.next = copy;
            copyCurr = copy;
            curr = curr.next;
        }

        return dummy.next;
    }
}
```
