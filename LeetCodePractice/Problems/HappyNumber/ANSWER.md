# Happy Number

## 解題思路
快樂數的定義：從一個正整數開始，重複將其替換為各位數字的平方和，若最終能變成 1 則為快樂數；若進入不包含 1 的循環則不是。

使用 **Floyd 環路檢測演算法（快慢指標）**：
1. 定義一個輔助函數計算數字的各位平方和。
2. 慢指標每次計算一次平方和，快指標每次計算兩次平方和。
3. 若快指標等於 1，回傳 true。
4. 若快指標追上慢指標（形成循環），則回傳 false。

這個方法不需要額外的 HashSet 來記錄已出現的數字，空間複雜度為 O(1)。

## 時間複雜度
- **時間**: O(log n) — 每次計算平方和需要的位數運算
- **空間**: O(1) — 僅使用常數空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class HappyNumber
{
    public bool Solve(int n)
    {
        int slow = n;
        int fast = GetNext(n);

        while (fast != 1 && slow != fast)
        {
            slow = GetNext(slow);
            fast = GetNext(GetNext(fast));
        }

        return fast == 1;
    }

    private int GetNext(int n)
    {
        int sum = 0;
        while (n > 0)
        {
            int digit = n % 10;
            sum += digit * digit;
            n /= 10;
        }
        return sum;
    }
}
```
