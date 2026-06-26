# Search a 2D Matrix

## 解題思路
將二維矩陣視為一個已排序的一維陣列來進行二元搜尋。

由於每一列從左到右排序，且下一列的第一個元素大於上一列的最後一個元素，因此可以將 `m x n` 的矩陣視為長度為 `m * n` 的一維排序陣列。

- `left = 0`，`right = m * n - 1`。
- 每次計算中間索引 `mid`，將其轉換為二維座標：
  - `row = mid / n`
  - `col = mid % n`
- 比較 `matrix[row][col]` 與 `target`，決定收縮左邊界或右邊界。
- 若找到則回傳 `true`，否則回傳 `false`。

## 時間複雜度
- **時間**: O(log(m * n)) — 對 m × n 個元素進行二元搜尋
- **空間**: O(1) — 只需幾個變數

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class SearchA2DMatrix
{
    public bool Solve(int[][] matrix, int target)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;
        int left = 0;
        int right = m * n - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int row = mid / n;
            int col = mid % n;
            int val = matrix[row][col];

            if (val == target)
                return true;
            else if (val < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return false;
    }
}
```
