# Jump Game II

## 解題思路
使用 **Greedy（貪心）** 策略。在 BFS 的概念下，維護當前跳躍能到達的最遠邊界 (`currentEnd`) 與下一步能到達的最遠邊界 (`farthest`)。遍歷陣列，每一步更新 `farthest`，當抵達 `currentEnd` 時，表示必須再跳一次，將跳躍次數加一，並將 `currentEnd` 更新為 `farthest`。重複直到抵達最後一個位置。

關鍵觀察：不需知道具體跳躍路徑，只需追蹤每次跳躍能覆蓋的最遠範圍即可。

## 時間/空間複雜度
- **時間複雜度**：O(n) — 只需一次遍歷
- **空間複雜度**：O(1) — 只使用常數空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class JumpGameII
{
    public int Solve(int[] nums)
    {
        int jumps = 0;
        int currentEnd = 0;
        int farthest = 0;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            farthest = Math.Max(farthest, i + nums[i]);

            if (i == currentEnd)
            {
                jumps++;
                currentEnd = farthest;
            }
        }

        return jumps;
    }
}
```
