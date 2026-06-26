# Partition Equal Subset Sum

## 解題思路

給定一個整數陣列，判斷是否可以將其分割成兩個子集，使兩個子集的元素總和相等。這是一道**0/1 背包問題**的變形。

**關鍵思考：**
- 若能分割成兩個和相等的子集，則總和 `totalSum` 必須為偶數。
- 目標是找出是否存在一個子集，其元素和為 `target = totalSum / 2`。
- 定義 `dp[i]` 表示是否存在一個子集的和為 `i`。
- 初始化 `dp[0] = true`（空子集的和為 0）。
- 對於每個數字 `num`，從 `target` 向下遍歷到 `num`：
  - 若 `dp[j - num]` 為 `true`，則 `dp[j] = true`。
- 最終回傳 `dp[target]`。

**為什麼從 target 向下遍歷？**
- 這是 0/1 背包問題的關鍵：每個物品只能使用一次。若從前往後遍歷，同一個數字可能會被重複使用。

## 時間複雜度

- **時間**: O(n × target) — n 為陣列長度，target = totalSum / 2
- **空間**: O(target) — 一維 DP 陣列

## 程式碼

```csharp
using System;
using System.Linq;

namespace LeetCodePractice.Problems;

public class PartitionEqualSubsetSum
{
    public bool Solve(int[] nums)
    {
        int totalSum = nums.Sum();
        if (totalSum % 2 != 0) return false;

        int target = totalSum / 2;
        bool[] dp = new bool[target + 1];
        dp[0] = true;

        foreach (int num in nums)
        {
            for (int j = target; j >= num; j--)
            {
                if (dp[j - num])
                    dp[j] = true;
            }
        }

        return dp[target];
    }
}
```
