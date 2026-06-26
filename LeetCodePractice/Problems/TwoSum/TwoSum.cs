using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

/// <summary>
/// Two Sum
/// 對應 LeetCode：LC 1 Two Sum（NeetCode 150）
/// 
/// 題目描述：
/// Given an array of integers nums and an integer target,
/// return indices of the two numbers such that they add up to target.
/// 
/// 假設每個輸入都有恰好一個解，且不能使用相同元素兩次。
/// 答案可以以任何順序回傳。
/// 
/// 範例：
/// Input: nums = [2,7,11,15], target = 9
/// Output: [0,1]
/// 
/// 限制：
/// - 2 <= nums.length <= 10^4
/// - -10^9 <= nums[i] <= 10^9
/// - -10^9 <= target <= 10^9
/// - 只有一個有效答案存在
/// </summary>
public class TwoSum
{
    public int[] Solve(int[] nums, int target)
    {
        // TODO: 使用 Dictionary 儲存已遍歷的元素與其索引
        // 1. 遍歷 nums
        // 2. 計算 complement = target - nums[i]
        // 3. 若 complement 存在於 dictionary 中，回傳 [dict[complement], i]
        // 4. 否則將 nums[i] 與 i 存入 dictionary
        throw new NotImplementedException();
    }
}

