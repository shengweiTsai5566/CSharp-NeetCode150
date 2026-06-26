# Merge Two Sorted Lists

## 解題思路
合併兩個已排序的鏈結串列，可使用**迭代**（雙指針）或**遞迴**方法。

### 迭代法
1. 建立一個 `dummy` 虛擬頭節點，簡化邊界處理
2. 用 `curr` 指針追蹤當前合併位置
3. 同時遍歷兩個串列，每次選較小值的節點接在 `curr` 後面
4. 當其中一個串列遍歷完，直接接上另一個串列的剩餘部分
5. 回傳 `dummy.next`

### 遞迴法
比較兩個頭節點的值，較小的節點作為結果，其 `next` 指向對剩餘部分遞迴合併的結果。

## 時間/空間複雜度
- **時間**: O(m + n)
- **空間**:
  - 迭代法：O(1)
  - 遞迴法：O(m + n)（遞迴呼叫棧深度）

## 程式碼

```csharp
public class MergeTwoSortedLists
{
    // 迭代解法
    public ListNode Solve(ListNode list1, ListNode list2)
    {
        var dummy = new ListNode(0);
        var curr = dummy;

        while (list1 != null && list2 != null)
        {
            if (list1.val <= list2.val)
            {
                curr.next = list1;
                list1 = list1.next;
            }
            else
            {
                curr.next = list2;
                list2 = list2.next;
            }
            curr = curr.next;
        }

        // 接上剩餘部分
        curr.next = list1 ?? list2;

        return dummy.next;
    }

    // 遞迴解法（可選）
    public ListNode SolveRecursive(ListNode list1, ListNode list2)
    {
        if (list1 == null) return list2;
        if (list2 == null) return list1;

        if (list1.val <= list2.val)
        {
            list1.next = SolveRecursive(list1.next, list2);
            return list1;
        }
        else
        {
            list2.next = SolveRecursive(list1, list2.next);
            return list2;
        }
    }
}
```
