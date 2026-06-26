# Koko Eating Bananas

## 解題思路
這題是典型的「二分搜尋答案」問題。我們要找到最小的整數速度 `k`，讓 Koko 能在 `h` 小時內吃完所有香蕉。

搜尋範圍：最小速度為 1，最大速度為 `max(piles)`（因為即使吃再快，每小時最多也只能消耗一整堆）。

對於每個候選速度 `k`，計算總共需要的小時數：對每一堆 `pile`，需要 `ceil(pile / k)` 小時。若總時數 `<= h`，則 `k` 可行，我們嘗試更小的速度（收縮右邊界）；否則需要更快速度（收縮左邊界）。

## 時間/空間複雜度
- **時間**: O(n log m)，其中 n 是堆數，m 是最大堆的香蕉數（二分搜尋範圍）
- **空間**: O(1)

## 程式碼

```csharp
public class KokoEatingBananas
{
    public int Solve(int[] piles, int h)
    {
        int left = 1, right = piles.Max();

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (CanEatAll(piles, h, mid))
                right = mid;
            else
                left = mid + 1;
        }

        return left;
    }

    private bool CanEatAll(int[] piles, int h, int k)
    {
        long hours = 0;
        foreach (int pile in piles)
        {
            hours += (pile + k - 1) / k; // 等同於 Math.Ceiling(pile / (double)k)
        }
        return hours <= h;
    }
}
```
