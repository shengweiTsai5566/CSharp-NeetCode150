# Find Minimum in Rotated Sorted Array

## 解題思路
在旋轉排序陣列中找最小值，可利用二分搜尋。關鍵觀察：在旋轉點左側的元素都大於右側的最小值。

初始化 `left = 0`、`right = n - 1`。每次取 `mid`：
- 若 `nums[mid] > nums[right]`：最小值在右半邊（mid 左側是較大的部分），`left = mid + 1`
- 否則：最小值在左半邊（包含 mid），`right = mid`

當 `left == right` 時即找到最小值。

此方法利用陣列中**唯一**的旋轉點特性，每次排除一半元素。

## 時間/空間複雜度
- **時間**: O(log n)
- **空間**: O(1)

## 程式碼

```csharp
public class FindMinimumInRotatedSortedArray
{
    public int Solve(int[] nums)
    {
        int left = 0, right = nums.Length - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] > nums[right])
                left = mid + 1;
            else
                right = mid;
        }

        return nums[left];
    }
}
```
