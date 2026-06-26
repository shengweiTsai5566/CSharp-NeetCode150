# Add Two Numbers

## 解題思路
使用一個 dummy head 節點來簡化鏈結串列操作。遍歷兩個鏈結串列，逐位相加並處理進位（carry）。每次計算 sum = l1.val + l2.val + carry，新節點的值為 sum % 10，carry = sum / 10。當兩個串列都遍歷完且 carry 為 0 時結束。

## 時間複雜度
- **時間**: O(max(m, n)) — 只需遍歷較長的鏈結串列一次
- **空間**: O(max(m, n)) — 需要建立一個新的鏈結串列儲存結果

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class AddTwoNumbers
{
    public ListNode Solve(ListNode l1, ListNode l2)
    {
        var dummy = new ListNode(0);
        var curr = dummy;
        int carry = 0;

        while (l1 != null || l2 != null || carry != 0)
        {
            int sum = carry;
            if (l1 != null) { sum += l1.val; l1 = l1.next; }
            if (l2 != null) { sum += l2.val; l2 = l2.next; }

            carry = sum / 10;
            curr.next = new ListNode(sum % 10);
            curr = curr.next;
        }

        return dummy.next;
    }
}
```
