# Reverse Nodes in k-Group

## 解題思路
使用遞迴方式，每次處理 k 個節點為一組進行反轉：

1. 先檢查當前鏈結串列是否有足夠的 k 個節點，若不足則直接回傳原頭節點。
2. 對前 k 個節點進行反轉（標準鏈結串列反轉邏輯）。
3. 反轉後，原頭節點變成該組的尾節點，將其 `next` 指向下一組反轉後的結果（遞迴處理）。
4. 回傳該組的新頭節點（即原第 k 個節點）。

此方法僅改變節點指標方向，不修改節點的值，符合題目限制。

## 時間複雜度
- **時間**: O(n) — 每個節點恰好被訪問一次
- **空間**: O(n/k) — 遞迴深度，最多 n/k 層（也可改為迭代實現以達到 O(1) 空間）

## 程式碼

```csharp
namespace LeetCodePractice.Problems;

public class ReverseNodesInKGroup
{
    public ListNode Solve(ListNode head, int k)
    {
        // Check if there are at least k nodes
        ListNode curr = head;
        int count = 0;
        while (curr != null && count < k)
        {
            curr = curr.next;
            count++;
        }

        if (count < k)
            return head;

        // Reverse first k nodes
        ListNode prev = null;
        ListNode current = head;
        for (int i = 0; i < k; i++)
        {
            ListNode next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }

        // Recursively process the rest and connect
        head.next = Solve(current, k);

        return prev;
    }
}
```
