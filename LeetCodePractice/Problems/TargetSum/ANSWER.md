# Target Sum

## 解題思路

本題可轉化為**子集和問題（Subset Sum）**。將陣列分為兩組：一組加正號（sumP），一組加負號（sumN），則：

```
sumP - sumN = target
sumP + sumN = total
=> sumP = (total + target) / 2
```

因此問題轉化為：找出和為 `(total + target) / 2` 的子集個數。

使用 **1D DP**：
- 定義 `dp[i]` 為湊出和為 `i` 的方法數
- 初始化 `dp[0] = 1`
- 對每個數字 `num`，從 `target` 反向遍歷到 `num`，更新 `dp[j] += dp[j - num]`

**注意事項**：
- 若 `(total + target)` 為奇數或 `target` 絕對值大於 `total`，直接回傳 0

## 時間複雜度

- **時間**: O(n × sum) — n 為陣列長度，sum 為總和
- **空間**: O(sum) — 使用 1D DP 陣列

## 程式碼

```csharp
public class TargetSum
{
    public int Solve(int[] nums, int target)
    {
        int total = nums.Sum();
        if (Math.Abs(target) > total || (total + target) % 2 != 0)
            return 0;

        int sum = (total + target) / 2;
        int[] dp = new int[sum + 1];
        dp[0] = 1;

        foreach (int num in nums)
        {
            for (int j = sum; j >= num; j--)
            {
                dp[j] += dp[j - num];
            }
        }

        return dp[sum];
    }
}
```
