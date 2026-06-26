# Search in Rotated Sorted Array

## 解題思路
在旋轉排序陣列中搜尋目標值，使用改良的二分搜尋。關鍵是要判斷當前 `mid` 落在左側有序區還是右側有序區。

1. 若 `nums[left] <= nums[mid]`：左半邊是有序的
   - 若 `target` 在 `[nums[left], nums[mid])` 之間，搜尋左半邊
   - 否則搜尋右半邊
2. 否則：右半邊是有序的
   - 若 `target` 在 `(nums[mid], nums[right]]` 之間，搜尋右半邊
   - 否則搜尋左半邊

每次迭代都能排除一半元素，達到 O(log n) 的時間複雜度。

## 時間/空間複雜度
- **時間**: O(log n)
- **空間**: O(1)

## 程式碼

```csharp
public class SearchInRotatedSortedArray
{
    public int Solve(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] == target)
                return mid;

            // 左半邊有序
            if (nums[left] <= nums[mid])
            {
                if (target >= nums[left] && target < nums[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            // 右半邊有序
            else
            {
                if (target > nums[mid] && target <= nums[right])
                    left = mid + 1;
                else
                    right = mid - 1;
            }
        }

        return -1;
    }
}
```
