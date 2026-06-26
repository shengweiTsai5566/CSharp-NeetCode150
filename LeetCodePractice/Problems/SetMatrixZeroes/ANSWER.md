# Set Matrix Zeroes

## 解題思路
給定一個 m×n 的矩陣，若某個元素為 0，則將其所在行與列的所有元素設為 0，必須**原地修改**。

使用**常數空間（O(1)）**的解法：
1. 先檢查第一行和第一列是否原本就包含 0（用兩個布林變數記錄）。
2. 將第一行和第一列作為**標記陣列**：遍歷矩陣其餘部分，若 `matrix[i][j] == 0`，則將 `matrix[i][0]` 和 `matrix[0][j]` 設為 0。
3. 根據標記，將對應的行和列設為 0（從倒數第一行/列開始，避免影響標記）。
4. 最後根據步驟 1 的記錄，處理第一行和第一列。

## 時間複雜度
- **時間**: O(m × n) — 需遍歷矩陣中所有元素
- **空間**: O(1) — 僅使用常數空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class SetMatrixZeroes
{
    public void Solve(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;

        bool firstRowZero = false;
        bool firstColZero = false;

        // 檢查第一行是否有 0
        for (int j = 0; j < n; j++)
        {
            if (matrix[0][j] == 0)
            {
                firstRowZero = true;
                break;
            }
        }

        // 檢查第一列是否有 0
        for (int i = 0; i < m; i++)
        {
            if (matrix[i][0] == 0)
            {
                firstColZero = true;
                break;
            }
        }

        // 用第一行和第一列作為標記
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                if (matrix[i][j] == 0)
                {
                    matrix[i][0] = 0;
                    matrix[0][j] = 0;
                }
            }
        }

        // 根據標記設為 0（從後往前避免覆蓋）
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                if (matrix[i][0] == 0 || matrix[0][j] == 0)
                {
                    matrix[i][j] = 0;
                }
            }
        }

        // 處理第一行
        if (firstRowZero)
        {
            for (int j = 0; j < n; j++)
                matrix[0][j] = 0;
        }

        // 處理第一列
        if (firstColZero)
        {
            for (int i = 0; i < m; i++)
                matrix[i][0] = 0;
        }
    }
}
```
