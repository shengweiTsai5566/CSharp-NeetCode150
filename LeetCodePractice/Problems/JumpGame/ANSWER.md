# Jump Game

## 解題思路

使用 **貪婪演算法（Greedy）** 從左向右遍歷，追蹤當前能到達的最遠索引。

- 初始化 `reachable = 0`（表示當前能到達的最遠位置）
- 遍歷陣列中的每個位置 `i`：
  - 如果 `i > reachable`，表示無法到達此位置，回傳 `false`
  - 更新 `reachable = Math.Max(reachable, i + nums[i])`
  - 如果 `reachable >= nums.Length - 1`，表示可以到達最後一個位置，回傳 `true`

**關鍵思維**：不需要考慮具體要跳幾步，只需要追蹤當前能到達的最遠範圍即可。如果遍歷過程中某個位置超出了可達範圍，就表示無法到達終點。

## 時間複雜度

- **時間**: O(n) — 只需一次遍歷
- **空間**: O(1) — 只使用常數額外空間

## 程式碼

```csharp
public class JumpGame
{
    public bool Solve(int[] nums)
    {
        int reachable = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > reachable)
                return false;
            reachable = Math.Max(reachable, i + nums[i]);
            if (reachable >= nums.Length - 1)
                return true;
        }
        return true;
    }
}
```
