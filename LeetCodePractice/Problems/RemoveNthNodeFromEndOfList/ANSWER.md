# Remove Nth Node From End of List

## 解題思路
刪除鏈結串列倒數第 n 個節點，使用**快慢指針（雙指針）**技巧，只需一趟遍歷：

1. 建立一個 `dummy` 虛擬頭節點（簡化刪除 head 的邊界情況）
2. `fast` 指針先走 n 步
3. 然後 `slow`（從 dummy 開始）和 `fast` 同時前進，直到 `fast` 到達尾端
4. 此時 `slow.next` 即為倒數第 n 個節點，將其跳過（`slow.next = slow.next.next`）
5. 回傳 `dummy.next`

因為 fast 先走 n 步，當 fast 走到 null 時，slow 與 fast 之間差距 n 步，所以 slow.next 就是倒數第 n 個節點。

## 時間/空間複雜度
- **時間**: O(n)
- **空間**: O(1)

## 程式碼

```csharp
public class RemoveNthNodeFromEndOfList
{
    public ListNode Solve(ListNode head, int n)
    {
        var dummy = new ListNode(0, head);
        ListNode slow = dummy, fast = dummy;

        // fast 先走 n 步
        for (int i = 0; i < n; i++)
            fast = fast.next;

        // 同時移動直到 fast 到達尾端
        while (fast.next != null)
        {
            slow = slow.next;
            fast = fast.next;
        }

        // 刪除倒數第 n 個節點
        slow.next = slow.next.next;

        return dummy.next;
    }
}
```
