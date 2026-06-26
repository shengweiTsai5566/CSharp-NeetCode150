# Spiral Matrix

## 解題思路
給定一個 m×n 的矩陣，以**螺旋順序**回傳所有元素。

使用**四個邊界指標**來控制遍歷範圍：
1. `top`：尚未遍歷的最上層列索引
2. `bottom`：尚未遍歷的最下層列索引
3. `left`：尚未遍歷的最左層行索引
4. `right`：尚未遍歷的最右層行索引

重複以下步驟直到邊界交錯：
- 從左到右遍歷最上層（top），然後 top++。
- 從上到下遍歷最右層（right），然後 right--。
- 若 top <= bottom，從右到左遍歷最下層（bottom），然後 bottom--。
- 若 left <= right，從下到上遍歷最左層（left），然後 left++。

## 時間複雜度
- **時間**: O(m × n) — 遍歷矩陣中所有元素一次
- **空間**: O(1) — 不計輸出陣列，僅使用常數空間

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class SpiralMatrix
{
    public IList<int> Solve(int[][] matrix)
    {
        var result = new List<int>();
        int top = 0, bottom = matrix.Length - 1;
        int left = 0, right = matrix[0].Length - 1;

        while (top <= bottom && left <= right)
        {
            // 從左到右
            for (int j = left; j <= right; j++)
                result.Add(matrix[top][j]);
            top++;

            // 從上到下
            for (int i = top; i <= bottom; i++)
                result.Add(matrix[i][right]);
            right--;

            if (top <= bottom)
            {
                // 從右到左
                for (int j = right; j >= left; j--)
                    result.Add(matrix[bottom][j]);
                bottom--;
            }

            if (left <= right)
            {
                // 從下到上
                for (int i = bottom; i >= top; i--)
                    result.Add(matrix[i][left]);
                left++;
            }
        }

        return result;
    }
}
```
