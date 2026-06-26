# Reorder List

## 解題思路
本題要求將鏈結串列重新排列為 `L0 → Ln → L1 → Ln-1 → L2 → Ln-2 → ...` 的形式。可以分解為三個步驟：

1. **找到鏈結串列的中點**：使用快慢指針（slow/fast），slow 每次走一步，fast 每次走兩步。當 fast 到達尾端時，slow 即為中點。
2. **反轉後半段**：從中點之後反轉後半段鏈結串列。
3. **合併兩個串列**：將前半段與反轉後的後半段交錯合併（L0→Ln→L1→Ln-1→...）。

注意：若串列長度為奇數，中點前後長度差 1，但交錯合併時以 `second.next` 是否為 null 作為終止條件即可。

## 時間/空間複雜度
- **時間**: O(n)
- **空間**: O(1)

## 程式碼

```csharp
public class ReorderList
{
    public void Solve(ListNode head)
    {
        if (head == null || head.next == null)
            return;

        // Step 1: 找到中點
        ListNode slow = head, fast = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        // Step 2: 反轉後半段
        ListNode second = Reverse(slow.next);
        slow.next = null!; // 斷開前後半段
        ListNode first = head;

        // Step 3: 交錯合併
        while (second != null)
        {
            ListNode tmp1 = first.next;
            ListNode tmp2 = second.next;
            first.next = second;
            second.next = tmp1;
            first = tmp1;
            second = tmp2;
        }
    }

    private ListNode Reverse(ListNode head)
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
}
```
