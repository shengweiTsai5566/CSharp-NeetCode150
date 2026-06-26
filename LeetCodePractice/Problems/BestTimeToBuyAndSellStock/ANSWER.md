# Best Time to Buy and Sell Stock

## 解題思路

使用**單次遍歷**搭配「最低買入價格」追蹤。核心概念是一邊遍歷價格陣列，一邊記錄到目前為止的最低價格，並計算如果在當天賣出能獲得多少利潤，更新最大利潤。

步驟：
1. 初始化 `minPrice = int.MaxValue`、`maxProfit = 0`。
2. 遍歷每一天的價格：
   - 若當前價格低於 `minPrice`，更新 `minPrice`（找到更好的買點）。
   - 否則計算 `price - minPrice` 作為當天賣出的利潤，更新 `maxProfit`。
3. 回傳 `maxProfit`。

這個方法等價於「在每個賣出日，回頭找之前的最低買入價」，時間複雜度 O(n)，空間複雜度 O(1)。

## 時間複雜度

- **時間**: O(n) — 一次遍歷
- **空間**: O(1) — 只使用常數額外空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class BestTimeToBuyAndSellStock
{
    public int Solve(int[] prices)
    {
        int minPrice = int.MaxValue;
        int maxProfit = 0;

        foreach (int price in prices)
        {
            if (price < minPrice)
                minPrice = price;
            else
                maxProfit = Math.Max(maxProfit, price - minPrice);
        }

        return maxProfit;
    }
}
```
