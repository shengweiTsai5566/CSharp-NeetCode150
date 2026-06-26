# Reverse Integer

## 解題思路
給定一個 32 位元帶號整數，將其數字反轉。若反轉後超出 32 位元整數範圍 `[-2³¹, 2³¹ - 1]`，則回傳 0。

逐位彈出再推入：
1. 每次取出 x 的最低位（`pop = x % 10`），並將 x 除以 10。
2. 將 pop 推入 result 的尾部：`result = result * 10 + pop`。
3. 在推入前檢查是否會溢位：
   - 正數溢位：`result > int.MaxValue / 10` 或在等於時 `pop > 7`。
   - 負數溢位：`result < int.MinValue / 10` 或在等於時 `pop < -8`。
4. 回傳 result。

## 時間複雜度
- **時間**: O(log₁₀ n) — n 為 x 的位數，最多 10 位
- **空間**: O(1) — 僅使用常數空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class ReverseInteger
{
    public int Solve(int x)
    {
        int result = 0;

        while (x != 0)
        {
            int pop = x % 10;
            x /= 10;

            // 正數溢位檢查
            if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && pop > 7))
                return 0;

            // 負數溢位檢查
            if (result < int.MinValue / 10 || (result == int.MinValue / 10 && pop < -8))
                return 0;

            result = result * 10 + pop;
        }

        return result;
    }
}
```
