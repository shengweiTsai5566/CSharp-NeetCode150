# Two Sum II - Input Array Is Sorted

## 解題思路

因為陣列已經是**非遞減排序**的，可以使用**雙指針（Two Pointers）** 技巧：
- 左指針 `left` 指向陣列開頭（最小值），右指針 `right` 指向陣列結尾（最大值）。
- 計算 `numbers[left] + numbers[right]` 的和：
  - 若和等於 `target`，回傳 `[left + 1, right + 1]`（題目為 1-indexed）。
  - 若和小於 `target`，表示需要更大的數，將 `left` 右移。
  - 若和大於 `target`，表示需要更小的數，將 `right` 左移。
- 重複直到找到答案（題目保證有唯一解）。

此方法滿足題目要求的常數額外空間限制。

## 時間複雜度

- **時間**: O(n) — 最多遍歷一次陣列
- **空間**: O(1) — 只使用常數額外空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class TwoSumII
{
    public int[] Solve(int[] numbers, int target)
    {
        int left = 0;
        int right = numbers.Length - 1;

        while (left < right)
        {
            int sum = numbers[left] + numbers[right];

            if (sum == target)
                return new int[] { left + 1, right + 1 };
            else if (sum < target)
                left++;
            else
                right--;
        }

        // 題目保證有解，不會執行到這裡
        return new int[] { -1, -1 };
    }
}
```
