# Reverse Linked List

## 解題思路
反轉單向鏈結串列，可以使用**迭代**或**遞迴**兩種方式。

### 迭代法
使用三個指針：`prev`（前一個節點）、`curr`（當前節點）、`next`（下一個節點暫存）。遍歷串列時，將 `curr.next` 指向 `prev`，然後三個指針同時向前移動，最後 `prev` 即為新的 head。

### 遞迴法
假設 `head` 之後的部分已經反轉完成（`newHead = Reverse(head.next)`），此時 `head.next.next` 指向 `head`（反轉指針），再將 `head.next` 設為 `null`。

## 時間/空間複雜度
- **時間**: O(n)（兩種方法都需要遍歷所有節點）
- **空間**:
  - 迭代法：O(1)
  - 遞迴法：O(n)（遞迴呼叫棧深度）

## 程式碼

```csharp
public class ReverseLinkedList
{
    // 迭代解法
    public ListNode Solve(ListNode head)
    {
        ListNode prev = null!;
        ListNode curr = head;

        while (curr != null)
        {
            ListNode next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        return prev;
    }

    // 遞迴解法（可選）
    public ListNode SolveRecursive(ListNode head)
    {
        if (head == null || head.next == null)
            return head;

        ListNode newHead = SolveRecursive(head.next);
        head.next.next = head;
        head.next = null!;

        return newHead;
    }
}
```
