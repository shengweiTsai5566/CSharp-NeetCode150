# Linked List Cycle

## 解題思路
使用快慢指標（Floyd's Cycle Detection Algorithm）。初始化兩個指標 `slow` 和 `fast` 都指向 head，`slow` 每次移動一步，`fast` 每次移動兩步。如果鏈結串列中存在環，則 `slow` 和 `fast` 終究會在環中相遇；若 `fast` 到達串列尾端（null），則表示無環。此方法僅使用 O(1) 額外空間。

## 時間複雜度
- **時間**: O(n) — 最壞情況下需要遍歷整個鏈結串列
- **空間**: O(1) — 只使用了兩個指標

## 程式碼

```csharp
namespace LeetCodePractice.Problems;

public class LinkedListCycle
{
    public bool Solve(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast)
                return true;
        }

        return false;
    }
}
```
