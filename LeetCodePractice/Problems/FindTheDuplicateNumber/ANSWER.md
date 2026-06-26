# Find the Duplicate Number

## 解題思路
將陣列視為一個鏈結串列，其中 `nums[i]` 指向 `nums[nums[i]]`，因為數字範圍在 `[1, n]` 且長度為 `n+1`，必然存在重複數字形成一個環。此問題轉化為在鏈結串列中找環的入口點（Floyd's Tortoise and Hare 演算法）：

1. 第一階段：使用快慢指標，`slow = nums[slow]`，`fast = nums[nums[fast]]`，找到兩者在環中的相遇點。
2. 第二階段：將 `slow` 重置為 0，`slow` 和 `fast` 每次都走一步，再次相遇的點即為重複數字（環的入口）。

此方法不需修改原陣列且只使用 O(1) 額外空間。

## 時間複雜度
- **時間**: O(n) — 線性時間遍歷
- **空間**: O(1) — 只使用了常數額外空間

## 程式碼

```csharp
namespace LeetCodePractice.Problems;

public class FindTheDuplicateNumber
{
    public int Solve(int[] nums)
    {
        int slow = 0;
        int fast = 0;

        // Phase 1: find intersection point
        do
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while (slow != fast);

        // Phase 2: find the entrance of the cycle
        slow = 0;
        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[fast];
        }

        return slow;
    }
}
```
