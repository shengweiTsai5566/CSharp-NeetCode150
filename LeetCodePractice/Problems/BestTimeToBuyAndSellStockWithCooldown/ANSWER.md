# Best Time to Buy and Sell Stock with Cooldown

## 解題思路

給定股票每日價格，可以進行多次交易（買入 → 賣出），但賣出後隔天必須冷卻（不能買入）。求最大利潤。這是一道**狀態機動態規劃**問題。

**關鍵思考：**
定義三種狀態：
1. **`hold`**（持有股票）：今天結束時手上持有股票的最大利潤。
   - 可能來自：昨天就持有（`hold`）或今天剛買入（`cooldown - prices[i]`）。
2. **`cooldown`**（冷卻中）：今天結束時處於冷卻期（剛賣出股票）的最大利潤。
   - 來自昨天賣出：昨天 `sold` 的利潤。
3. **`sold`**（不持股且非冷卻）：今天結束時不持有股票且不在冷卻期的最大利潤。
   - 可能來自：昨天就不持股（`sold`）或昨天冷卻今天恢復（`cooldown`）。

**轉移方程：**
```
newHold     = max(hold, cooldown - prices[i])
newCooldown = sold
newSold     = max(sold, cooldown)
```

初始化：
- `hold = -prices[0]`（第一天買入）
- `cooldown = 0`（第一天不可能賣出）
- `sold = 0`（第一天不交易）

最終答案為 `max(sold, cooldown)`，因為最後一天持有股票沒有意義。

## 時間複雜度

- **時間**: O(n) — 一次遍歷
- **空間**: O(1) — 只使用三個變數

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class BestTimeToBuyAndSellStockWithCooldown
{
    public int Solve(int[] prices)
    {
        int hold = -prices[0];
        int cooldown = 0;
        int sold = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            int newHold = Math.Max(hold, cooldown - prices[i]);
            int newCooldown = sold;
            int newSold = Math.Max(sold, cooldown);

            hold = newHold;
            cooldown = newCooldown;
            sold = newSold;
        }

        return Math.Max(sold, cooldown);
    }
}
```
