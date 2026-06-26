# Batch Fill Problem Descriptions for NeetCode 150
# 此腳本為所有批次建立的題目填入正確的題目描述、範例和方法簽名

$rootDir = Resolve-Path "$PSScriptRoot\..\..\..\.."
$problemsDir = "$rootDir\LeetCodePractice\Problems"

# 題目資料: Name → @{Desc, Example, Method}
$problemData = @{
    # === Arrays & Hashing ===
    "ContainsDuplicate" = @{
        Desc = "Given an integer array nums, return true if any value appears at least twice in the array, and false if every element is distinct."
        Example = "Input: nums = [1,2,3,1]`nOutput: true"
        Constraints = "1 <= nums.length <= 10^5, -10^9 <= nums[i] <= 10^9"
        Method = "public bool Solve(int[] nums)"
        Usings = "System.Collections.Generic"
    }
    "ValidAnagram" = @{
        Desc = "Given two strings s and t, return true if t is an anagram of s, and false otherwise."
        Example = "Input: s = 'anagram', t = 'nagarma'`nOutput: true"
        Constraints = "1 <= s.length, t.length <= 5*10^4"
        Method = "public bool Solve(string s, string t)"
        Usings = ""
    }
    "GroupAnagrams" = @{
        Desc = "Given an array of strings strs, group the anagrams together. You can return the answer in any order."
        Example = "Input: strs = ['eat','tea','tan','ate','nat','bat']`nOutput: [['bat'],['nat','tan'],['ate','eat','tea']]"
        Constraints = "1 <= strs.length <= 10^4, 0 <= strs[i].length <= 100"
        Method = "public IList<IList<string>> Solve(string[] strs)"
        Usings = "System.Collections.Generic"
    }
    "TopKFrequentElements" = @{
        Desc = "Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order."
        Example = "Input: nums = [1,1,1,2,2,3], k = 2`nOutput: [1,2]"
        Constraints = "1 <= nums.length <= 10^5, k is in the range [1, unique elements]"
        Method = "public int[] Solve(int[] nums, int k)"
        Usings = "System.Collections.Generic"
    }
    "ProductOfArrayExceptSelf" = @{
        Desc = "Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i]. You must solve it without division and in O(n) time."
        Example = "Input: nums = [1,2,3,4]`nOutput: [24,12,8,6]"
        Constraints = "2 <= nums.length <= 10^5, -30 <= nums[i] <= 30"
        Method = "public int[] Solve(int[] nums)"
        Usings = ""
    }
    "ValidSudoku" = @{
        Desc = "Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the rules: each row, each column, and each 3x3 sub-box must contain digits 1-9 without repetition."
        Example = "Input: board = [['5','3','.',...]]`nOutput: true"
        Constraints = "board.length == 9, board[i].length == 9"
        Method = "public bool Solve(char[][] board)"
        Usings = "System.Collections.Generic"
    }
    "EncodeAndDecodeStrings" = @{
        Desc = "Design an algorithm to encode a list of strings to a single string and decode it back."
        Example = "Input: ['hello','world']`nOutput: encode -> '5#hello5#world' -> decode -> ['hello','world']"
        Constraints = "0 <= strs.length <= 100, 0 <= strs[i].length <= 200"
        Method = "public string Encode(IList<string> strs)`n    public List<string> Decode(string s)"
        Usings = "System.Collections.Generic"
    }
    "LongestConsecutiveSequence" = @{
        Desc = "Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence. You must write an algorithm that runs in O(n) time."
        Example = "Input: nums = [100,4,200,1,3,2]`nOutput: 4 (sequence: [1,2,3,4])"
        Constraints = "0 <= nums.length <= 10^5, -10^9 <= nums[i] <= 10^9"
        Method = "public int Solve(int[] nums)"
        Usings = "System.Collections.Generic"
    }

    # === Two Pointers ===
    "ValidPalindrome" = @{
        Desc = "Given a string s, return true if it is a palindrome, considering only alphanumeric characters and ignoring cases."
        Example = "Input: s = 'A man, a plan, a canal: Panama'`nOutput: true"
        Constraints = "1 <= s.length <= 2*10^5"
        Method = "public bool Solve(string s)"
        Usings = ""
    }
    "TwoSumII" = @{
        Desc = "Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, find two numbers that add up to a specific target number. Return the indices of the two numbers (1-indexed)."
        Example = "Input: numbers = [2,7,11,15], target = 9`nOutput: [1,2]"
        Constraints = "2 <= numbers.length <= 3*10^4, -1000 <= numbers[i] <= 1000"
        Method = "public int[] Solve(int[] numbers, int target)"
        Usings = ""
    }
    "ThreeSum" = @{
        Desc = "Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0."
        Example = "Input: nums = [-1,0,1,2,-1,-4]`nOutput: [[-1,-1,2],[-1,0,1]]"
        Constraints = "3 <= nums.length <= 3000, -10^5 <= nums[i] <= 10^5"
        Method = "public IList<IList<int>> Solve(int[] nums)"
        Usings = "System.Collections.Generic"
    }
    "ContainerWithMostWater" = @{
        Desc = "Given an integer array height of length n, find two lines that together with the x-axis form a container that contains the most water."
        Example = "Input: height = [1,8,6,2,5,4,8,3,7]`nOutput: 49"
        Constraints = "n == height.length, 2 <= n <= 10^5, 0 <= height[i] <= 10^4"
        Method = "public int Solve(int[] height)"
        Usings = ""
    }
    "TrappingRainWater" = @{
        Desc = "Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining."
        Example = "Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]`nOutput: 6"
        Constraints = "n == height.length, 1 <= n <= 2*10^4, 0 <= height[i] <= 10^5"
        Method = "public int Solve(int[] height)"
        Usings = ""

    # === Sliding Window ===
    "BestTimeToBuyAndSellStock" = @{
        Desc = "Given an array prices where prices[i] is the price of a given stock on day i, find the maximum profit you can achieve by buying and selling one share of the stock."
        Example = "Input: prices = [7,1,5,3,6,4]`nOutput: 5"
        Constraints = "1 <= prices.length <= 10^5, 0 <= prices[i] <= 10^4"
        Method = "public int Solve(int[] prices)"
        Usings = ""
    }
    "LongestSubstringWithoutRepeatingCharacters" = @{
        Desc = "Given a string s, find the length of the longest substring without repeating characters."
        Example = "Input: s = 'abcabcbb'`nOutput: 3 (abc)"
        Constraints = "0 <= s.length <= 5*10^4, s consists of English letters, digits, symbols and spaces"
        Method = "public int Solve(string s)"
        Usings = "System.Collections.Generic"
    }
    "LongestRepeatingCharacterReplacement" = @{
        Desc = "Given a string s and an integer k, you can choose any character and change it to any other uppercase English character at most k times. Return the length of the longest substring containing the same letter."
        Example = "Input: s = 'ABAB', k = 2`nOutput: 4"
        Constraints = "1 <= s.length <= 10^5, 0 <= k <= s.length"
        Method = "public int Solve(string s, int k)"
        Usings = ""
    }
    "PermutationInString" = @{
        Desc = "Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise."
        Example = "Input: s1 = 'ab', s2 = 'eidbaooo'`nOutput: true"
        Constraints = "1 <= s1.length, s2.length <= 10^4"
        Method = "public bool Solve(string s1, string s2)"
        Usings = ""
    }
    "MinimumWindowSubstring" = @{
        Desc = "Given two strings s and t, return the minimum window substring of s such that every character in t (including duplicates) is included in the window."
        Example = "Input: s = 'ADOBECODEBANC', t = 'ABC'`nOutput: 'BANC'"
        Constraints = "1 <= s.length, t.length <= 10^5"
        Method = "public string Solve(string s, string t)"
        Usings = "System.Collections.Generic"
    }
    "SlidingWindowMaximum" = @{
        Desc = "Given an array nums and a sliding window of size k, return an array containing the maximum element for each window position."
        Example = "Input: nums = [1,3,-1,-3,5,3,6,7], k = 3`nOutput: [3,3,5,5,6,7]"
        Constraints = "1 <= nums.length <= 10^5, 1 <= k <= nums.length"
        Method = "public int[] Solve(int[] nums, int k)"
        Usings = "System.Collections.Generic"
    }

    # === Stack ===
    "ValidParentheses" = @{
        Desc = "Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid. A string is valid if brackets close in the correct order."
        Example = "Input: s = '()[]{}'`nOutput: true"
        Constraints = "1 <= s.length <= 10^4"
        Method = "public bool Solve(string s)"
        Usings = "System.Collections.Generic"
    }
    "MinStack" = @{
        Desc = "Design a stack that supports push, pop, top, and retrieving the minimum element in constant time."
        Example = "MinStack minStack = new MinStack(); minStack.Push(-2); minStack.Push(0); minStack.Push(-3); minStack.GetMin(); // return -3"
        Constraints = "-2^31 <= val <= 2^31-1, Methods pop, top and getMin operations will always be called on non-empty stacks"
        Method = "public void Push(int val)`n    public void Pop()`n    public int Top()`n    public int GetMin()"
        Usings = "System.Collections.Generic"
    }
    "EvaluateReversePolishNotation" = @{
        Desc = "Evaluate the value of an arithmetic expression in Reverse Polish Notation. Valid operators are +, -, *, /. Each operand may be an integer or another expression."
        Example = "Input: tokens = ['2','1','+','3','*']`nOutput: 9 ((2 + 1) * 3)"
        Constraints = "1 <= tokens.length <= 10^4"
        Method = "public int Solve(string[] tokens)"
        Usings = "System.Collections.Generic"
    }
    "GenerateParentheses" = @{
        Desc = "Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses."
        Example = "Input: n = 3`nOutput: ['((()))','(()())','(())()','()(())','()()()']"
        Constraints = "1 <= n <= 8"
        Method = "public IList<string> Solve(int n)"
        Usings = "System.Collections.Generic"
    }
    "DailyTemperatures" = @{
        Desc = "Given an array of integers temperatures represents the daily temperatures, return an array answer such that answer[i] is the number of days until a warmer temperature."
        Example = "Input: temperatures = [73,74,75,71,69,72,76,73]`nOutput: [1,1,4,2,1,1,0,0]"
        Constraints = "1 <= temperatures.length <= 10^5, 30 <= temperatures[i] <= 100"
        Method = "public int[] Solve(int[] temperatures)"
        Usings = ""
    }
    "CarFleet" = @{
        Desc = "Given a target value and two arrays position and speed (both same length), return the number of car fleets that will arrive at the target."
        Example = "Input: target = 12, position = [10,8,0,5,3], speed = [2,4,1,1,3]`nOutput: 3"
        Constraints = "1 <= position.length <= 10^5, 0 < target <= 10^6"
        Method = "public int Solve(int target, int[] position, int[] speed)"
        Usings = ""
    }
    "LargestRectangleInHistogram" = @{
        Desc = "Given an array of integers heights representing the histogram's bar height where the width of each bar is 1, return the area of the largest rectangle in the histogram."
        Example = "Input: heights = [2,1,5,6,2,3]`nOutput: 10"
        Constraints = "1 <= heights.length <= 10^5, 0 <= heights[i] <= 10^4"
        Method = "public int Solve(int[] heights)"
        Usings = ""
    }

    # === Binary Search ===
    "BinarySearch" = @{
        Desc = "Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums. If target exists, return its index. Otherwise, return -1."
        Example = "Input: nums = [-1,0,3,5,9,12], target = 9`nOutput: 4"
        Constraints = "1 <= nums.length <= 10^4, -10^4 < nums[i], target < 10^4"
        Method = "public int Solve(int[] nums, int target)"
        Usings = ""
    }
    "SearchA2DMatrix" = @{
        Desc = "Write an efficient algorithm that searches for a value target in an m x n integer matrix. Integers in each row are sorted from left to right, and the first integer of each row is greater than the last integer of the previous row."
        Example = "Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 3`nOutput: true"
        Constraints = "1 <= m,n <= 100, -10^4 <= matrix[i][j], target <= 10^4"
        Method = "public bool Solve(int[][] matrix, int target)"
        Usings = ""
    }
    "KokoEatingBananas" = @{
        Desc = "Koko loves to eat bananas. There are n piles of bananas, the ith pile has piles[i] bananas. Koko can eat at most k bananas per hour. Return the minimum integer k such that she can eat all bananas within h hours."
        Example = "Input: piles = [3,6,7,11], h = 8`nOutput: 4"
        Constraints = "1 <= piles.length <= 10^4, piles.length <= h <= 10^9, 1 <= piles[i] <= 10^9"
        Method = "public int Solve(int[] piles, int h)"
        Usings = ""
    }
    "FindMinimumInRotatedSortedArray" = @{
        Desc = "Given the sorted rotated array nums of unique elements, return the minimum element in O(log n) time."
        Example = "Input: nums = [3,4,5,1,2]`nOutput: 1"
        Constraints = "1 <= nums.length <= 5000, all unique"
        Method = "public int Solve(int[] nums)"
        Usings = ""
    }
    "SearchInRotatedSortedArray" = @{
        Desc = "Given the rotated sorted array nums, search for target in O(log n) time. Return its index or -1."
        Example = "Input: nums = [4,5,6,7,0,1,2], target = 0`nOutput: 4"
        Constraints = "1 <= nums.length <= 5000, unique values"
        Method = "public int Solve(int[] nums, int target)"
        Usings = ""
    }
    "TimeBasedKeyValueStore" = @{
        Desc = "Design a time-based key-value data structure that stores multiple values for the same key at different timestamps and retrieves the key's value at a certain timestamp."
        Example = "set('foo','bar',1); get('foo',1) -> 'bar'; get('foo',3) -> 'bar' (closest prev timestamp)"
        Constraints = "1 <= key.length, value.length <= 100, timestamps are strictly increasing"
        Method = "public void Set(string key, string value, int timestamp)`n    public string Get(string key, int timestamp)"
        Usings = "System.Collections.Generic"
    }
    "MedianOfTwoSortedArrays" = @{
        Desc = "Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays in O(log(m+n)) time."
        Example = "Input: nums1 = [1,3], nums2 = [2]`nOutput: 2.0"
        Constraints = "0 <= m,n <= 1000, -10^6 <= nums1[i], nums2[i] <= 10^6"
        Method = "public double Solve(int[] nums1, int[] nums2)"
        Usings = ""
    }

    # === Linked List ===
    "ReverseLinkedList" = @{
        Desc = "Given the head of a singly linked list, reverse the list and return the reversed list."
        Example = "Input: head = [1,2,3,4,5]`nOutput: [5,4,3,2,1]"
        Constraints = "0 <= nodes <= 5000, -5000 <= Node.val <= 5000"
        Method = "public ListNode Solve(ListNode head)"
        Usings = "System.Collections.Generic"
        ListNode = $true
    }
    "MergeTwoSortedLists" = @{
        Desc = "Merge two sorted linked lists into one sorted linked list."
        Example = "Input: list1 = [1,2,4], list2 = [1,3,4]`nOutput: [1,1,2,3,4,4]"
        Constraints = "0 <= nodes <= 50, -100 <= Node.val <= 100"
        Method = "public ListNode Solve(ListNode list1, ListNode list2)"
        Usings = ""
        ListNode = $true
    }
    "ReorderList" = @{
        Desc = "Reorder a linked list L0 -> Ln -> L1 -> Ln-1 -> L2 -> Ln-2 -> ... in-place."
        Example = "Input: head = [1,2,3,4]`nOutput: [1,4,2,3]"
        Constraints = "1 <= nodes <= 5*10^4, -10^4 <= Node.val <= 10^4"
        Method = "public void Solve(ListNode head)"
        Usings = ""
        ListNode = $true
    }
    "RemoveNthNodeFromEndOfList" = @{
        Desc = "Given the head of a linked list, remove the nth node from the end and return the head."
        Example = "Input: head = [1,2,3,4,5], n = 2`nOutput: [1,2,3,5]"
        Constraints = "1 <= nodes <= 30, 1 <= n <= nodes"
        Method = "public ListNode Solve(ListNode head, int n)"
        Usings = ""
        ListNode = $true
    }
    "AddTwoNumbers" = @{
        Desc = "Given two non-empty linked lists representing two non-negative integers (digits stored in reverse order), add the two numbers and return the sum as a linked list."
        Example = "Input: l1 = [2,4,3], l2 = [5,6,4]`nOutput: [7,0,8] (342 + 465 = 807)"
        Constraints = "1 <= nodes <= 100, 0 <= Node.val <= 9"
        Method = "public ListNode Solve(ListNode l1, ListNode l2)"
        Usings = ""
        ListNode = $true
    }
    "LinkedListCycle" = @{
        Desc = "Given head of a linked list, determine if the list has a cycle in it."
        Example = "Input: head = [3,2,0,-4], pos = 1`nOutput: true"
        Constraints = "0 <= nodes <= 10^4, -10^5 <= Node.val <= 10^5"
        Method = "public bool Solve(ListNode head)"
        Usings = ""
        ListNode = $true
    }
    "FindTheDuplicateNumber" = @{
        Desc = "Given an array of integers nums containing n+1 integers where each integer is in the range [1, n] inclusive, find the duplicate number."
        Example = "Input: nums = [1,3,4,2,2]`nOutput: 2"
        Constraints = "1 <= n <= 10^5"
        Method = "public int Solve(int[] nums)"
        Usings = ""
    }
    "LRUCache" = @{
        Desc = "Design a data structure that follows the constraints of a Least Recently Used (LRU) cache. Implement LRUCache class with Get and Put in O(1) time."
        Example = "LRUCache lru = new LRUCache(2); lru.Put(1,1); lru.Put(2,2); lru.Get(1); lru.Put(3,3); // evicts key 2"
        Constraints = "1 <= capacity <= 3000, 0 <= key,value <= 10^4, at most 2*10^5 calls"
        Method = "public int Get(int key)`n    public void Put(int key, int value)"
        Usings = "System.Collections.Generic"
    }
    "MergeKSortedLists" = @{
        Desc = "Merge k sorted linked lists and return it as one sorted list."
        Example = "Input: lists = [[1,4,5],[1,3,4],[2,6]]`nOutput: [1,1,2,3,4,4,5,6]"
        Constraints = "k == lists.length, 0 <= k <= 10^4, 0 <= nodes per list <= 500"
        Method = "public ListNode Solve(ListNode[] lists)"
        Usings = "System.Collections.Generic"
        ListNode = $true
    }
    "ReverseNodesInKGroup" = @{
        Desc = "Given the head of a linked list, reverse the nodes of the list k at a time and return the modified list."
        Example = "Input: head = [1,2,3,4,5], k = 2`nOutput: [2,1,4,3,5]"
        Constraints = "1 <= nodes <= 5000, 1 <= k <= nodes"
        Method = "public ListNode Solve(ListNode head, int k)"
        Usings = ""
        ListNode = $true
    }
    "CopyListWithRandomPointer" = @{
        Desc = "A linked list of length n is given such that each node contains an additional random pointer. Construct a deep copy of the list."
        Example = "Input: head = [[7,null],[13,0],[11,4],[10,2],[1,0]]`nOutput: [[7,null],[13,0],[11,4],[10,2],[1,0]]"
        Constraints = "0 <= n <= 1000, -10^4 <= Node.val <= 10^4"
        Method = "public Node Solve(Node head)"
        Usings = "System.Collections.Generic"
    }

    # === Backtracking ===
    "Subsets" = @{
        Desc = "Given an integer array nums of unique elements, return all possible subsets (the power set)."
        Example = "Input: nums = [1,2,3]`nOutput: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]"
        Constraints = "1 <= nums.length <= 10, -10 <= nums[i] <= 10, all unique"
        Method = "public IList<IList<int>> Solve(int[] nums)"
        Usings = "System.Collections.Generic"
    }
    "CombinationSum" = @{
        Desc = "Given an array of distinct integers candidates and target, return all unique combinations where candidate numbers sum to target. The same number may be used unlimited times."
        Example = "Input: candidates = [2,3,6,7], target = 7`nOutput: [[2,2,3],[7]]"
        Constraints = "1 <= candidates.length <= 30, 1 <= candidates[i] <= 200"
        Method = "public IList<IList<int>> Solve(int[] candidates, int target)"
        Usings = "System.Collections.Generic"
    }
    "Permutations" = @{
        Desc = "Given an array nums of distinct integers, return all the possible permutations."
        Example = "Input: nums = [1,2,3]`nOutput: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]"
        Constraints = "1 <= nums.length <= 6, -10 <= nums[i] <= 10, all unique"
        Method = "public IList<IList<int>> Solve(int[] nums)"
        Usings = "System.Collections.Generic"
    }
    "SubsetsII" = @{
        Desc = "Given an integer array nums that may contain duplicates, return all possible subsets (the power set). The solution set must not contain duplicate subsets."
        Example = "Input: nums = [1,2,2]`nOutput: [[],[1],[1,2],[1,2,2],[2],[2,2]]"
        Constraints = "1 <= nums.length <= 10, -10 <= nums[i] <= 10"
        Method = "public IList<IList<int>> Solve(int[] nums)"
        Usings = "System.Collections.Generic"
    }
    "CombinationSumII" = @{
        Desc = "Given a collection of candidate numbers and a target, find all unique combinations where candidates sum to target. Each number may be used only once."
        Example = "Input: candidates = [10,1,2,7,6,1,5], target = 8`nOutput: [[1,1,6],[1,2,5],[1,7],[2,6]]"
        Constraints = "1 <= candidates.length <= 100, 1 <= target <= 30"
        Method = "public IList<IList<int>> Solve(int[] candidates, int target)"
        Usings = "System.Collections.Generic"
    }
    "WordSearch" = @{
        Desc = "Given an m x n board of characters and a string word, return true if word exists in the grid. The word can be constructed from adjacent cells (horizontal or vertical)."
        Example = "Input: board = [['A','B','C','E'],['S','F','C','S'],['A','D','E','E']], word = 'ABCCED'`nOutput: true"
        Constraints = "1 <= m,n <= 6, 1 <= word.length <= 15"
        Method = "public bool Solve(char[][] board, string word)"
        Usings = ""
    }
    "PalindromePartitioning" = @{
        Desc = "Given a string s, partition s such that every substring of the partition is a palindrome. Return all possible palindrome partitions."
        Example = "Input: s = 'aab'`nOutput: [['a','a','b'],['aa','b']]"
        Constraints = "1 <= s.length <= 16"
        Method = "public IList<IList<string>> Solve(string s)"
        Usings = "System.Collections.Generic"
    }
    "LetterCombinationsOfAPhoneNumber" = @{
        Desc = "Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. (Mapping: 2->abc, 3->def, 4->ghi, 5->jkl, 6->mno, 7->pqrs, 8->tuv, 9->wxyz)"
        Example = "Input: digits = '23'`nOutput: ['ad','ae','af','bd','be','bf','cd','ce','cf']"
        Constraints = "0 <= digits.length <= 4"
        Method = "public IList<string> Solve(string digits)"
        Usings = "System.Collections.Generic"
    }
    "NQueens" = @{
        Desc = "The n-queens puzzle: place n queens on an n x n chessboard such that no two queens attack each other. Return all distinct solutions."
        Example = "Input: n = 4`nOutput: [[.Q..,...Q,Q...,..Q.],[..Q.,Q...,...Q,.Q..]]"
        Constraints = "1 <= n <= 9"
        Method = "public IList<IList<string>> Solve(int n)"
        Usings = "System.Collections.Generic"
    }
}

# TreeNode definition for tree problems
$treeNodeDef = @'
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
'@

# ListNode definition
$listNodeDef = @'
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}
'@

$nodeDef = @'
public class Node {
    public int val;
    public Node next;
    public Node random;
    public Node(int val=0, Node next=null, Node random=null) {
        this.val = val;
        this.next = next;
        this.random = random;
    }
}
'@

$treeProblems = @("InvertBinaryTree","MaximumDepthOfBinaryTree","DiameterOfBinaryTree","BalancedBinaryTree","SameTree","SubtreeOfAnotherTree","LowestCommonAncestorOfBST","BinaryTreeLevelOrderTraversal","BinaryTreeRightSideView","CountGoodNodesInBinaryTree","ValidateBinarySearchTree","KthSmallestElementInBST","ConstructBinaryTreeFromPreorderAndInorder","BinaryTreeMaximumPathSum","SerializeAndDeserializeBinaryTree")
$listNodeProblems = @("ReverseLinkedList","MergeTwoSortedLists","ReorderList","RemoveNthNodeFromEndOfList","AddTwoNumbers","LinkedListCycle","MergeKSortedLists","ReverseNodesInKGroup")
$copyListProblems = @("CopyListWithRandomPointer")
$heapProblems = @("KthLargestElementInAStream","LastStoneWeight","KClosestPointsToOrigin","KthLargestElementInAnArray","TaskScheduler","FindMedianFromDataStream")
$designProblems = @("MinStack","LRUCache","TimeBasedKeyValueStore","ImplementTrie","DesignAddAndSearchWordsDataStructure","DesignTwitter")

# Graph problems
$graphProblems = @{
    "NumberOfIslands" = "Given an m x n 2D binary grid which represents a map of '1's (land) and '0's (water), return the number of islands.`nExample: grid = [['1','1','0','0','0'],['1','1','0','0','0'],['0','0','1','0','0'],['0','0','0','1','1']] => 3`nMethod: public int Solve(char[][] grid)"
    "CloneGraph" = "Given a reference of a node in a connected undirected graph, return a deep copy (clone) of the graph.`nMethod: public Node Solve(Node node)"
    "MaxAreaOfIsland" = "Given an m x n binary grid, find the maximum area of an island.`nMethod: public int Solve(int[][] grid)"
    "PacificAtlanticWaterFlow" = "Given an m x n matrix of heights, return a 2D list of grid coordinates where water can flow to both the Pacific and Atlantic oceans.`nMethod: public IList<IList<int>> Solve(int[][] heights)"
    "SurroundedRegions" = "Given an m x n board containing 'X' and 'O', capture all regions surrounded by 'X'.`nMethod: public void Solve(char[][] board)"
    "RottingOranges" = "Given an m x n grid where each cell can have value 0, 1, or 2 (rotten orange), return the minimum number of minutes until no cell has a fresh orange.`nMethod: public int Solve(int[][] grid)"
    "CourseSchedule" = "Given numCourses and prerequisites pairs, determine if you can finish all courses.`nMethod: public bool Solve(int numCourses, int[][] prerequisites)"
    "CourseScheduleII" = "Given numCourses and prerequisites, return the ordering of courses you should take to finish all courses.`nMethod: public int[] Solve(int numCourses, int[][] prerequisites)"
    "RedundantConnection" = "Given a graph that started as a tree with n nodes, find the edge that can be removed to make it a tree again.`nMethod: public int[] Solve(int[][] edges)"
    "WordLadder" = "Given two words beginWord, endWord and a dictionary wordList, return the length of the shortest transformation sequence from beginWord to endWord.`nMethod: public int Solve(string beginWord, string endWord, IList<string> wordList)"
}

# DP problems
$dpProblems = @{
    "ClimbingStairs" = "You are climbing a staircase. It takes n steps to reach the top. Each time you can climb 1 or 2 steps. In how many distinct ways can you climb to the top?`nMethod: public int Solve(int n)"
    "MinCostClimbingStairs" = "Given an array cost where cost[i] is the cost of step i, find the minimum cost to reach the top of the floor.`nMethod: public int Solve(int[] cost)"
    "HouseRobber" = "Given an array of money in each house, return the maximum amount you can rob tonight without robbing adjacent houses.`nMethod: public int Solve(int[] nums)"
    "HouseRobberII" = "Same as House Robber but houses are arranged in a circle.`nMethod: public int Solve(int[] nums)"
    "LongestPalindromicSubstring" = "Given a string s, return the longest palindromic substring in s.`nMethod: public string Solve(string s)"
    "PalindromicSubstrings" = "Given a string s, return the number of palindromic substrings in it.`nMethod: public int Solve(string s)"
    "DecodeWays" = "Given a string s containing digits, return the number of ways to decode it (A=1,...,Z=26).`nMethod: public int Solve(string s)"
    "CoinChange" = "Given coin denominations and amount, return the fewest number of coins needed to make up that amount.`nMethod: public int Solve(int[] coins, int amount)"
    "MaximumProductSubarray" = "Given an integer array nums, find the contiguous subarray with the largest product.`nMethod: public int Solve(int[] nums)"
    "WordBreak" = "Given a string s and a dictionary of strings wordDict, return true if s can be segmented into space-separated dictionary words.`nMethod: public bool Solve(string s, IList<string> wordDict)"
    "LongestIncreasingSubsequence" = "Given an integer array nums, return the length of the longest strictly increasing subsequence.`nMethod: public int Solve(int[] nums)"
    "PartitionEqualSubsetSum" = "Given an integer array nums, return true if you can partition the array into two subsets with equal sum.`nMethod: public bool Solve(int[] nums)"
    "UniquePaths" = "Given m x n grid, return the number of possible unique paths from top-left to bottom-right moving only down or right.`nMethod: public int Solve(int m, int n)"
    "LongestCommonSubsequence" = "Given two strings, return the length of their longest common subsequence.`nMethod: public int Solve(string text1, string text2)"
    "BestTimeToBuyAndSellStockWithCooldown" = "Given prices, find max profit after buying/selling with a 1-day cooldown after selling.`nMethod: public int Solve(int[] prices)"
    "CoinChangeII" = "Given coin denominations and amount, return the number of combinations that make up that amount.`nMethod: public int Solve(int amount, int[] coins)"
    "TargetSum" = "Given an array and a target, return the number of ways to assign + and - to make sum equal target.`nMethod: public int Solve(int[] nums, int target)"
    "InterleavingString" = "Given strings s1, s2, s3, determine if s3 is formed by an interleaving of s1 and s2.`nMethod: public bool Solve(string s1, string s2, string s3)"
    "EditDistance" = "Given two strings, return the minimum number of operations (insert, delete, replace) to convert word1 to word2.`nMethod: public int Solve(string word1, string word2)"
    "DistinctSubsequences" = "Given two strings s and t, return the number of distinct subsequences of s which equal t.`nMethod: public int Solve(string s, string t)"
    "RegularExpressionMatching" = "Given an input string s and a pattern p, implement regular expression matching with support for '.' and '*'.`nMethod: public bool Solve(string s, string p)"
    "BurstBalloons" = "Given an array nums, burst balloons strategically to maximize coins.`nMethod: public int Solve(int[] nums)"
    "LongestIncreasingPathInAMatrix" = "Given an m x n matrix, return the length of the longest increasing path.`nMethod: public int Solve(int[][] matrix)"
}

# Greedy problems
$greedyProblems = @{
    "MaximumSubarray" = "Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum.`nMethod: public int Solve(int[] nums)"
    "JumpGame" = "Given an array of non-negative integers, determine if you can reach the last index.`nMethod: public bool Solve(int[] nums)"
    "JumpGameII" = "Given an array of non-negative integers, return the minimum number of jumps to reach the last index.`nMethod: public int Solve(int[] nums)"
    "GasStation" = "Given gas stations with gas[i] cost[i], return the starting station index to complete the circuit.`nMethod: public int Solve(int[] gas, int[] cost)"
    "HandOfStraights" = "Given an array hand and groupSize, return true if the cards can be rearranged into consecutive groups.`nMethod: public bool Solve(int[] hand, int groupSize)"
    "MergeTripletsToFormTargetTriplet" = "Given triplets array and a target triplet, determine if you can form target by merging triplets (taking max of each position).`nMethod: public bool Solve(int[][] triplets, int[] target)"
    "PartitionLabels" = "Given a string s, partition it into as many parts as possible so each letter appears in at most one part.`nMethod: public IList<int> Solve(string s)"
    "ValidParenthesisString" = "Given a string s containing '(', ')', and '*', determine if it is valid. '*' can be '(' or ')' or empty.`nMethod: public bool Solve(string s)"
}

# Interval problems
$intervalProblems = @{
    "InsertInterval" = "Given an array of non-overlapping intervals and a new interval, insert the new interval and merge if needed.`nMethod: public int[][] Solve(int[][] intervals, int[] newInterval)"
    "MergeIntervals" = "Given an array of intervals, merge all overlapping intervals.`nMethod: public int[][] Solve(int[][] intervals)"
    "NonOverlappingIntervals" = "Given intervals, return the minimum number to remove to make the rest non-overlapping.`nMethod: public int Solve(int[][] intervals)"
    "MeetingRooms" = "Given an array of meeting time intervals, determine if a person could attend all meetings.`nMethod: public bool Solve(int[][] intervals)"
    "MeetingRoomsII" = "Given an array of meeting time intervals, return the minimum number of conference rooms required.`nMethod: public int Solve(int[][] intervals)"
    "MinimumIntervalToIncludeEachQuery" = "Given intervals and an array of queries, return the size of the smallest interval containing each query.`nMethod: public int[] Solve(int[][] intervals, int[] queries)"
}

# Tree problems data
$treeData = @{
    "InvertBinaryTree" = "Given the root of a binary tree, invert the tree and return its root.`nMethod: public TreeNode Solve(TreeNode root)"
    "MaximumDepthOfBinaryTree" = "Given the root of a binary tree, return its maximum depth.`nMethod: public int Solve(TreeNode root)"
    "DiameterOfBinaryTree" = "Given the root of a binary tree, return the length of the diameter (longest path between any two nodes).`nMethod: public int Solve(TreeNode root)"
    "BalancedBinaryTree" = "Given a binary tree, determine if it is height-balanced.`nMethod: public bool Solve(TreeNode root)"
    "SameTree" = "Given the roots of two binary trees p and q, check if they are the same.`nMethod: public bool Solve(TreeNode p, TreeNode q)"
    "SubtreeOfAnotherTree" = "Given the roots of two binary trees, check if one tree is a subtree of the other.`nMethod: public bool Solve(TreeNode root, TreeNode subRoot)"
    "LowestCommonAncestorOfBST" = "Given a BST, find the lowest common ancestor of two given nodes.`nMethod: public TreeNode Solve(TreeNode root, TreeNode p, TreeNode q)"
    "BinaryTreeLevelOrderTraversal" = "Given the root of a binary tree, return the level order traversal of its nodes' values.`nMethod: public IList<IList<int>> Solve(TreeNode root)"
    "BinaryTreeRightSideView" = "Given the root of a binary tree, return the values of the nodes you can see from the right side.`nMethod: public IList<int> Solve(TreeNode root)"
    "CountGoodNodesInBinaryTree" = "Given a binary tree, count good nodes where no node in the root-to-node path has a value greater than the current node.`nMethod: public int Solve(TreeNode root)"
    "ValidateBinarySearchTree" = "Given the root of a binary tree, determine if it is a valid BST.`nMethod: public bool Solve(TreeNode root)"
    "KthSmallestElementInBST" = "Given the root of a BST and an integer k, return the kth smallest value.`nMethod: public int Solve(TreeNode root, int k)"
    "ConstructBinaryTreeFromPreorderAndInorder" = "Given two integer arrays preorder and inorder, construct and return the binary tree.`nMethod: public TreeNode Solve(int[] preorder, int[] inorder)"
    "BinaryTreeMaximumPathSum" = "Given the root of a binary tree, return the maximum path sum (any node to any node).`nMethod: public int Solve(TreeNode root)"
    "SerializeAndDeserializeBinaryTree" = "Design an algorithm to serialize and deserialize a binary tree.`nMethod: public string Serialize(TreeNode root)`n    public TreeNode Deserialize(string data)"
}

# Remaining problems
$remaining = @{
    "ImplementTrie" = "Implement a trie (prefix tree) with insert, search, and startsWith methods.`nMethods: public void Insert(string word), public bool Search(string word), public bool StartsWith(string prefix)"
    "DesignAddAndSearchWordsDataStructure" = "Design a data structure that supports adding new words and searching for words with '.' wildcard.`nMethods: public void AddWord(string word), public bool Search(string word)"
    "WordSearchII" = "Given an m x n board and a list of words, find all words on the board.`nMethod: public IList<string> Solve(char[][] board, string[] words)"
    "KthLargestElementInAStream" = "Design a class to find the kth largest element in a stream of numbers.`nConstructor: public KthLargest(int k, int[] nums), Method: public int Add(int val)"
    "LastStoneWeight" = "Smash stones together: the heavier stone breaks the lighter one. Return the weight of the last remaining stone.`nMethod: public int Solve(int[] stones)"
    "KClosestPointsToOrigin" = "Given an array of points, return the k closest points to the origin (0,0).`nMethod: public int[][] Solve(int[][] points, int k)"
    "KthLargestElementInAnArray" = "Given an integer array and k, return the kth largest element.`nMethod: public int Solve(int[] nums, int k)"
    "LcTaskScheduler" = "Given a tasks array and cooldown n, return the minimum time to complete all tasks. Note: class is LcTaskScheduler (not TaskScheduler) to avoid .NET naming conflict.`nMethod: public int Solve(char[] tasks, int n)"
    "FindMedianFromDataStream" = "Design a class to find the median from a data stream.`nMethods: public void AddNum(int num), public double FindMedian()"
    "DesignTwitter" = "Design a simplified Twitter with postTweet, getNewsFeed, follow, unfollow.`nMethods: public void PostTweet(int userId, int tweetId), public IList<int> GetNewsFeed(int userId), public void Follow(int followerId, int followeeId), public void Unfollow(int followerId, int followeeId)"
    "ReconstructItinerary" = "Given a list of airline tickets, reconstruct the itinerary in order.`nMethod: public IList<string> Solve(IList<IList<string>> tickets)"
    "MinCostToConnectAllPoints" = "Given an array of points, return the minimum cost to connect all points (Manhattan distance).`nMethod: public int Solve(int[][] points)"
    "NetworkDelayTime" = "Given a network of n nodes and travel times, return the minimum time for all nodes to receive a signal from k.`nMethod: public int Solve(int[][] times, int n, int k)"
    "SwimInRisingWater" = "Given an n x n grid of heights, find the minimum time to swim from (0,0) to (n-1,n-1).`nMethod: public int Solve(int[][] grid)"
    "CheapestFlightsWithinKStops" = "Find the cheapest price from src to dst with at most k stops.`nMethod: public int Solve(int n, int[][] flights, int src, int dst, int k)"
    "SingleNumber" = "Given a non-empty array where every element appears twice except one, find that single one.`nMethod: public int Solve(int[] nums)"
    "NumberOf1Bits" = "Given a positive integer, return the number of set bits (Hamming weight).`nMethod: public int Solve(int n)"
    "CountingBits" = "Given an integer n, return an array result where result[i] is the number of 1 bits for each i from 0 to n.`nMethod: public int[] Solve(int n)"
    "ReverseBits" = "Reverse bits of a given 32-bit unsigned integer.`nMethod: public uint Solve(uint n)"
    "MissingNumber" = "Given an array containing n distinct numbers from 0 to n, find the missing number.`nMethod: public int Solve(int[] nums)"
    "SumOfTwoIntegers" = "Given two integers a and b, return their sum without using + or -.`nMethod: public int Solve(int a, int b)"
    "ReverseInteger" = "Given a signed 32-bit integer x, return x with its digits reversed.`nMethod: public int Solve(int x)"
    "RotateImage" = "Rotate an n x n matrix 90 degrees clockwise in-place.`nMethod: public void Solve(int[][] matrix)"
    "SpiralMatrix" = "Given an m x n matrix, return all elements in spiral order.`nMethod: public IList<int> Solve(int[][] matrix)"
    "SetMatrixZeroes" = "Given an m x n matrix, if an element is 0, set its entire row and column to 0 in-place.`nMethod: public void Solve(int[][] matrix)"
    "HappyNumber" = "A happy number is a number defined by the sum of squares of digits eventually reaching 1. Determine if n is happy.`nMethod: public bool Solve(int n)"
    "PlusOne" = "Given a large integer represented as an array of digits, increment by one.`nMethod: public int[] Solve(int[] digits)"
    "PowXN" = "Implement pow(x, n) (x^n).`nMethod: public double Solve(double x, int n)"
    "MultiplyStrings" = "Given two non-negative integers represented as strings, return the product as a string.`nMethod: public string Solve(string num1, string num2)"
    "DetectSquares" = "Design a class to detect squares formed by points in a 2D plane.`nMethods: public void Add(int[] point), public int Count(int[] point)"
}

Write-Host "開始批次更新題目描述..." -ForegroundColor Cyan

# Process each file
Get-ChildItem "$problemsDir/*.cs" | Where-Object {
    $_.Name -notin @('CommandParser.cs','DeviceParameterCache.cs','ProblemTemplate.cs','TwoSum.cs','WaferScanOptimizer.cs')
} | ForEach-Object {
    $fileName = $_.BaseName
    $content = Get-Content $_.FullName -Raw
    
    # Skip if already has proper description (not containing TODO in summary)
    if ($content -notmatch 'TODO: 加入題目描述與範例') {
        Write-Host "⏭️  跳過 $fileName (已填寫)" -ForegroundColor Yellow
        return
    }
    
    $updated = $false
    
    # Try to find problem data
    $info = $null
    
    # Check various lookup tables
    if ($problemData.ContainsKey($fileName)) { $info = $problemData[$fileName] }
    elseif ($treeData.ContainsKey($fileName)) { 
        $lines = $treeData[$fileName] -split "`n"
        $desc = $lines[0]
        $methodLine = ($lines | Where-Object { $_ -match 'Method:' } | Select-Object -First 1) -replace 'Method: '
        $info = @{Desc=$desc; Method=$methodLine; Usings="System.Collections.Generic"}
    }
    elseif ($graphProblems.ContainsKey($fileName)) { 
        $lines = $graphProblems[$fileName] -split "`n"
        $desc = $lines[0]
        $methodLine = ($lines | Where-Object { $_ -match 'Method:' } | Select-Object -First 1) -replace 'Method: '
        $info = @{Desc=$desc; Method=$methodLine; Usings="System.Collections.Generic"}
    }
    elseif ($dpProblems.ContainsKey($fileName)) { 
        $lines = $dpProblems[$fileName] -split "`n"
        $desc = $lines[0]
        $methodLine = ($lines | Where-Object { $_ -match 'Method:' } | Select-Object -First 1) -replace 'Method: '
        $info = @{Desc=$desc; Method=$methodLine; Usings=""}
    }
    elseif ($greedyProblems.ContainsKey($fileName)) { 
        $lines = $greedyProblems[$fileName] -split "`n"
        $desc = $lines[0]
        $methodLine = ($lines | Where-Object { $_ -match 'Method:' } | Select-Object -First 1) -replace 'Method: '
        $info = @{Desc=$desc; Method=$methodLine; Usings="System.Collections.Generic"}
    }
    elseif ($intervalProblems.ContainsKey($fileName)) { 
        $lines = $intervalProblems[$fileName] -split "`n"
        $desc = $lines[0]
        $methodLine = ($lines | Where-Object { $_ -match 'Method:' } | Select-Object -First 1) -replace 'Method: '
        $info = @{Desc=$desc; Method=$methodLine; Usings=""}
    }
    elseif ($remaining.ContainsKey($fileName)) { 
        $lines = $remaining[$fileName] -split "`n"
        $desc = $lines[0]
        $methodLine = ($lines | Where-Object { $_ -match 'Method' } | Select-Object -First 1)
        if ($methodLine) { $methodLine = ($methodLine -split ': ', 2)[1] }
        $info = @{Desc=$desc; Method=$methodLine; Usings="System.Collections.Generic"}
    }
    
    if (-not $info) {
        Write-Host "⚠️  找不到 $fileName 的資料" -ForegroundColor Red
        return
    }
    
    # Build new XML doc
    $desc = $info.Desc
    $methodSig = $info.Method
    $usings = if ($info.Usings -ne "") { "using $($info.Usings);`n" } else { "" }
    
    # Build summary lines
    $newSummary = @"
$usings"@ + 'using System;' + @"

namespace LeetCodePractice.Problems;

/// <summary>
/// $desc
/// 
/// 對應 LeetCode：$fileName 問題
/// 來源：NeetCode 150
/// 
/// 範例：
/// $($info.Example -replace "`n","`n/// ")
/// 
/// 限制條件：
/// $($info.Constraints -replace "`n","`n/// ")
/// </summary>
"@
    
    # Replace summary section
    $content = $content -replace '(?s)using System;.*?/// </summary>', $newSummary
    
    # Replace method signature
    if ($methodSig -and $methodSig -ne "") {
        # Handle multiple methods
        $methods = $methodSig -split '`n' | ForEach-Object { $_.Trim() }
        
        # Replace the TODO method comment and body
        $content = $content -replace '(?s)// TODO: 實作你的解法.*?throw new NotImplementedException\(\);', "// TODO: 實作解法`n        throw new NotImplementedException();"
        
        # Replace the commented-out method signature
        $firstMethod = $methods[0] -replace 'public', '// public'
        $content = $content -replace '(?s)// public ReturnType Solve\(Parameters\).*?// \{}', $firstMethod
    }
    
    # Add ListNode class if needed
    if ($listNodeProblems -contains $fileName) {
        $content = $content -replace 'public class \w+', "$listNodeDef`r`n`r`npublic class `$0"
    }
    
    # Add TreeNode class if needed
    if ($treeProblems -contains $fileName) {
        $content = $content -replace 'public class \w+', "$treeNodeDef`r`n`r`npublic class `$0"
    }
    
    # Add Node class for CopyListWithRandomPointer
    if ($copyListProblems -contains $fileName) {
        $content = $content -replace 'public class \w+', "$nodeDef`r`n`r`npublic class `$0"
    }
    
    Set-Content $_.FullName $content
    Write-Host "✅ 已更新 $fileName" -ForegroundColor Green
    $updated = $true
}

Write-Host ""
Write-Host "===== 完成 =====" -ForegroundColor Cyan
