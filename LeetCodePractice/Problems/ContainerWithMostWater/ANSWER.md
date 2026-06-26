# Container With Most Water

## 解題思路

使用**雙指針**從陣列的兩端向中間移動。容器的容積由較短的那條線決定（木桶效應），計算公式為：`min(height[left], height[right]) * (right - left)`。

核心邏輯：
1. 初始化 `left = 0`、`right = n - 1`，`maxArea = 0`。
2. 每次計算當前容器面積並更新最大值。
3. 移動**較短的那條線**的指針，因為較短的線是容量的瓶頸，移動較長的線不可能得到更大的面積。
4. 重複直到 `left >= right`。

這個貪婪策略的正確性在於：每次移動指針時，雖然寬度減少，但有可能遇到更高的線來補償，而移動較短的那一側才保留這種可能性。

## 時間複雜度

- **時間**: O(n) — 一次遍歷
- **空間**: O(1) — 只使用常數額外空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class ContainerWithMostWater
{
    public int Solve(int[] height)
    {
        int left = 0, right = height.Length - 1;
        int maxArea = 0;

        while (left < right)
        {
            int currentHeight = Math.Min(height[left], height[right]);
            int currentWidth = right - left;
            int currentArea = currentHeight * currentWidth;

            maxArea = Math.Max(maxArea, currentArea);

            // 移動較短的那一側
            if (height[left] < height[right])
                left++;
            else
                right--;
        }

        return maxArea;
    }
}
```
