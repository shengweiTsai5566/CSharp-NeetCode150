# Maximum Subarray

## 解題思路

使用 **Kadane's Algorithm（卡丹演算法）**，這是最優的貪婪/DP解法。

核心概念：掃描陣列時，維護兩個變數：
- `currentSum`：以當前位置結尾的最大子陣列和
- `maxSum`：到目前為止找到的全局最大子陣列和

**轉移邏輯**：
- 對於每個元素 `nums[i]`，決定要將它加入之前的子陣列，還是從它重新開始
- `currentSum = Math.Max(nums[i], currentSum + nums[i])`
- `maxSum = Math.Max(maxSum, currentSum)`

**關鍵思維**：如果 `currentSum` 變成負數，那麼它對後面元素的貢獻只會更糟，所以應該從下一個元素重新開始計算。

## 時間複雜度

- **時間**: O(n) — 只需一次遍歷
- **空間**: O(1) — 只使用常數額外空間

## 程式碼

```csharp
public class MaximumSubarray
{
    public int Solve(int[] nums)
    {
        int currentSum = nums[0];
        int maxSum = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            currentSum = Math.Max(nums[i], currentSum + nums[i]);
            maxSum = Math.Max(maxSum, currentSum);
        }

        return maxSum;
    }
}
```
