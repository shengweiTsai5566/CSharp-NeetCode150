# Rotate Image

## 解題思路
給定一個 n×n 的二維矩陣，將其順時針旋轉 90 度，且必須**原地（in-place）**修改。

方法：先**轉置（Transpose）**再**反轉每一行**。
1. 轉置：將 `matrix[i][j]` 與 `matrix[j][i]` 交換（i < j）。
2. 反轉每一行：對每一列，將 `matrix[i][j]` 與 `matrix[i][n - 1 - j]` 交換。

這個方法直觀且容易實作，時間複雜度 O(n²)，空間複雜度 O(1)。

另一種等價的解法是分層旋轉（Layer-by-Layer），每次交換四個對應位置的元素，但寫法較複雜。

## 時間複雜度
- **時間**: O(n²) — 需遍歷矩陣中所有元素
- **空間**: O(1) — 原地修改

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class RotateImage
{
    public void Solve(int[][] matrix)
    {
        int n = matrix.Length;

        // Step 1: 轉置（Transpose）
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
            }
        }

        // Step 2: 反轉每一行
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n / 2; j++)
            {
                (matrix[i][j], matrix[i][n - 1 - j]) = (matrix[i][n - 1 - j], matrix[i][j]);
            }
        }
    }
}
```
