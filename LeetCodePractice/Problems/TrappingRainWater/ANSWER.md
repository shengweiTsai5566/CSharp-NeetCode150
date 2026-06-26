# Trapping Rain Water

## 解題思路

使用**雙指針**搭配左右兩側的最大高度來計算每個位置能接多少雨水。

具體方法：
1. 初始化 `left = 0`、`right = n - 1`，以及 `leftMax = 0`、`rightMax = 0`。
2. 當 `left < right` 時：
   - 如果 `height[left] < height[right]`，表示左側是瓶頸：
     - 若 `height[left] >= leftMax`，更新 `leftMax`。
     - 否則該位置可接的水量為 `leftMax - height[left]`，加入結果。
     - `left++`。
   - 否則右側是瓶頸：
     - 若 `height[right] >= rightMax`，更新 `rightMax`。
     - 否則該位置可接的水量為 `rightMax - height[right]`，加入結果。
     - `right--`。

這個方法的關鍵在於：每個位置能接的水量取決於**左右兩側最高柱子中較小的那個**減去當前高度。雙指針法不需要額外的陣列來儲存左右最大值。

## 時間複雜度

- **時間**: O(n) — 一次遍歷
- **空間**: O(1) — 只使用常數額外空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class TrappingRainWater
{
    public int Solve(int[] height)
    {
        int left = 0, right = height.Length - 1;
        int leftMax = 0, rightMax = 0;
        int totalWater = 0;

        while (left < right)
        {
            if (height[left] < height[right])
            {
                if (height[left] >= leftMax)
                    leftMax = height[left];
                else
                    totalWater += leftMax - height[left];
                left++;
            }
            else
            {
                if (height[right] >= rightMax)
                    rightMax = height[right];
                else
                    totalWater += rightMax - height[right];
                right--;
            }
        }

        return totalWater;
    }
}
```
