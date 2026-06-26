# Batch update all LeetCode problem files with proper method signatures and descriptions
param(
    [string]$ProblemsDir = (Resolve-Path "$PSScriptRoot\..\..\..\..\LeetCodePractice\Problems").Path
)

# Define problem metadata: ClassName = @{LC=..., Signature=..., Description=..., NeedsGeneric=$false, NeedsListNode=$false, NeedsTreeNode=$false, NeedsNode=$false}
$problems = @{
    # ===== Arrays & Hashing =====
    "ContainsDuplicate" = @{ LC=217; Desc="Return true if any value appears twice in the array."; Signatures=@("public bool Solve(int[] nums)"); NeedsGeneric=$false }
    "ValidAnagram" = @{ LC=242; Desc="Return true if t is an anagram of s."; Signatures=@("public bool Solve(string s, string t)"); NeedsGeneric=$false }
    "GroupAnagrams" = @{ LC=49; Desc="Group the anagrams together. Each group is a list of strings."; Signatures=@("public IList<IList<string>> Solve(string[] strs)"); NeedsGeneric=$true }
    "TopKFrequentElements" = @{ LC=347; Desc="Return the k most frequent elements in any order."; Signatures=@("public int[] Solve(int[] nums, int k)"); NeedsGeneric=$false }
    "ProductOfArrayExceptSelf" = @{ LC=238; Desc="Return an array where result[i] is the product of all elements except nums[i]. Solve in O(n) without division."; Signatures=@("public int[] Solve(int[] nums)"); NeedsGeneric=$false }
    "ValidSudoku" = @{ LC=36; Desc="Determine if a 9x9 Sudoku board is valid. Only filled cells need validation."; Signatures=@("public bool Solve(char[][] board)"); NeedsGeneric=$false }
    "EncodeAndDecodeStrings" = @{ LC=271; Desc="Design an algorithm to encode a list of strings to a single string and decode it back."; Signatures=@("public string Encode(IList<string> strs)","public List<string> Decode(string s)"); NeedsGeneric=$true }
    "LongestConsecutiveSequence" = @{ LC=128; Desc="Return the length of the longest consecutive elements sequence. Solve in O(n) time."; Signatures=@("public int Solve(int[] nums)"); NeedsGeneric=$false }

    # ===== Two Pointers =====
    "ValidPalindrome" = @{ LC=125; Desc="Return true if the string is a valid palindrome, considering only alphanumeric characters and ignoring case."; Signatures=@("public bool Solve(string s)"); NeedsGeneric=$false }
    "TwoSumII" = @{ LC=167; Desc="Return the indices (1-indexed) of two numbers that add up to target. The array is sorted in non-decreasing order."; Signatures=@("public int[] Solve(int[] numbers, int target)"); NeedsGeneric=$false }
    "ThreeSum" = @{ LC=15; Desc="Find all unique triplets in the array that sum to zero."; Signatures=@("public IList<IList<int>> Solve(int[] nums)"); NeedsGeneric=$true }
    "ContainerWithMostWater" = @{ LC=11; Desc="Return the maximum area of water a container can hold. Choose two vertical lines that together form a container."; Signatures=@("public int Solve(int[] height)"); NeedsGeneric=$false }
    "TrappingRainWater" = @{ LC=42; Desc="Given an elevation map, compute how much water it can trap after raining."; Signatures=@("public int Solve(int[] height)"); NeedsGeneric=$false }

    # ===== Sliding Window =====
    "BestTimeToBuyAndSellStock" = @{ LC=121; Desc="Return the maximum profit from buying and selling one stock. You must buy before you sell."; Signatures=@("public int Solve(int[] prices)"); NeedsGeneric=$false }
    "LongestSubstringWithoutRepeatingCharacters" = @{ LC=3; Desc="Return the length of the longest substring without repeating characters."; Signatures=@("public int Solve(string s)"); NeedsGeneric=$false }
    "LongestRepeatingCharacterReplacement" = @{ LC=424; Desc="Return the length of the longest substring containing the same letter after at most k replacements."; Signatures=@("public int Solve(string s, int k)"); NeedsGeneric=$false }
    "PermutationInString" = @{ LC=567; Desc="Return true if s2 contains a permutation of s1."; Signatures=@("public bool Solve(string s1, string s2)"); NeedsGeneric=$false }
    "MinimumWindowSubstring" = @{ LC=76; Desc="Return the minimum window substring of s such that every character in t is included."; Signatures=@("public string Solve(string s, string t)"); NeedsGeneric=$false }
    "SlidingWindowMaximum" = @{ LC=239; Desc="Return an array containing the maximum element in each sliding window of size k."; Signatures=@("public int[] Solve(int[] nums, int k)"); NeedsGeneric=$false }

    # ===== Stack =====
    "ValidParentheses" = @{ LC=20; Desc="Return true if the input string has valid parentheses ordering."; Signatures=@("public bool Solve(string s)"); NeedsGeneric=$false }
    "MinStack" = @{ LC=155; Desc="Design a stack that supports push, pop, top, and retrieving the minimum element in O(1) time."; Signatures=@("public void Push(int val)","public void Pop()","public int Top()","public int GetMin()"); NeedsGeneric=$false }
    "EvaluateReversePolishNotation" = @{ LC=150; Desc="Evaluate the value of an arithmetic expression in Reverse Polish Notation."; Signatures=@("public int Solve(string[] tokens)"); NeedsGeneric=$false }
    "GenerateParentheses" = @{ LC=22; Desc="Generate all combinations of well-formed parentheses with n pairs."; Signatures=@("public IList<string> Solve(int n)"); NeedsGeneric=$true }
    "DailyTemperatures" = @{ LC=739; Desc="Return an array such that result[i] is the number of days until a warmer temperature."; Signatures=@("public int[] Solve(int[] temperatures)"); NeedsGeneric=$false }
    "CarFleet" = @{ LC=853; Desc="Return the number of car fleets that will arrive at the destination."; Signatures=@("public int Solve(int target, int[] position, int[] speed)"); NeedsGeneric=$false }
    "LargestRectangleInHistogram" = @{ LC=84; Desc="Return the largest rectangle area that can be formed in a histogram."; Signatures=@("public int Solve(int[] heights)"); NeedsGeneric=$false }

    # ===== Binary Search =====
    "BinarySearch" = @{ LC=704; Desc="Return the index of target in the sorted array, or -1 if not found."; Signatures=@("public int Solve(int[] nums, int target)"); NeedsGeneric=$false }
    "SearchA2DMatrix" = @{ LC=74; Desc="Return true if target exists in the 2D matrix. Each row is sorted, and the first element of each row is greater than the last of the previous."; Signatures=@("public bool Solve(int[][] matrix, int target)"); NeedsGeneric=$false }
    "KokoEatingBananas" = @{ LC=875; Desc="Return the minimum integer k such that Koko can eat all bananas within h hours."; Signatures=@("public int Solve(int[] piles, int h)"); NeedsGeneric=$false }
    "FindMinimumInRotatedSortedArray" = @{ LC=153; Desc="Return the minimum element in a rotated sorted array. Solve in O(log n) time."; Signatures=@("public int Solve(int[] nums)"); NeedsGeneric=$false }
    "SearchInRotatedSortedArray" = @{ LC=33; Desc="Return the index of target in a rotated sorted array, or -1 if not found. Solve in O(log n) time."; Signatures=@("public int Solve(int[] nums, int target)"); NeedsGeneric=$false }
    "TimeBasedKeyValueStore" = @{ LC=981; Desc="Design a time-based key-value store that supports setting values at specific timestamps and retrieving values closest to a timestamp."; Signatures=@("public void Set(string key, string value, int timestamp)","public string Get(string key, int timestamp)"); NeedsGeneric=$true }
    "MedianOfTwoSortedArrays" = @{ LC=4; Desc="Return the median of two sorted arrays. Solve in O(log(m+n)) time."; Signatures=@("public double Solve(int[] nums1, int[] nums2)"); NeedsGeneric=$false }

    # ===== Linked List =====
    "ReverseLinkedList" = @{ LC=206; Desc="Reverse a singly linked list and return the new head."; Signatures=@("public ListNode Solve(ListNode head)"); NeedsListNode=$true }
    "MergeTwoSortedLists" = @{ LC=21; Desc="Merge two sorted linked lists into one sorted linked list."; Signatures=@("public ListNode Solve(ListNode list1, ListNode list2)"); NeedsListNode=$true }
    "ReorderList" = @{ LC=143; Desc="Reorder the list to L0→Ln→L1→Ln-1→L2→... in-place."; Signatures=@("public void Solve(ListNode head)"); NeedsListNode=$true }
    "RemoveNthNodeFromEndOfList" = @{ LC=19; Desc="Remove the nth node from the end of the list and return the head."; Signatures=@("public ListNode Solve(ListNode head, int n)"); NeedsListNode=$true }
    "AddTwoNumbers" = @{ LC=2; Desc="Add two numbers represented as linked lists and return the sum as a linked list."; Signatures=@("public ListNode Solve(ListNode l1, ListNode l2)"); NeedsListNode=$true }
    "LinkedListCycle" = @{ LC=141; Desc="Return true if there is a cycle in the linked list."; Signatures=@("public bool Solve(ListNode head)"); NeedsListNode=$true }
    "MergeKSortedLists" = @{ LC=23; Desc="Merge k sorted linked lists into one sorted linked list."; Signatures=@("public ListNode Solve(ListNode[] lists)"); NeedsListNode=$true; NeedsGeneric=$true }
    "ReverseNodesInKGroup" = @{ LC=25; Desc="Reverse the nodes of the linked list k at a time and return the modified list."; Signatures=@("public ListNode Solve(ListNode head, int k)"); NeedsListNode=$true }
    "CopyListWithRandomPointer" = @{ LC=138; Desc="Create a deep copy of a linked list where each node has an additional random pointer."; Signatures=@("public Node Solve(Node head)"); NeedsNode=$true; NeedsGeneric=$true }
    "FindTheDuplicateNumber" = @{ LC=287; Desc="Return the duplicate number in an array containing n+1 integers in range [1, n]. Solve without modifying the array."; Signatures=@("public int Solve(int[] nums)"); NeedsGeneric=$false }
    "LRUCache" = @{ LC=146; Desc="Design a data structure that follows the Least Recently Used (LRU) cache constraint. Both Get and Put should run in O(1) time."; Signatures=@("public int Get(int key)","public void Put(int key, int value)"); NeedsGeneric=$true }

    # ===== Trees =====
    "InvertBinaryTree" = @{ LC=226; Desc="Invert a binary tree and return its root."; Signatures=@("public TreeNode Solve(TreeNode root)"); NeedsTreeNode=$true }
    "MaximumDepthOfBinaryTree" = @{ LC=104; Desc="Return the maximum depth of a binary tree."; Signatures=@("public int Solve(TreeNode root)"); NeedsTreeNode=$true }
    "DiameterOfBinaryTree" = @{ LC=543; Desc="Return the diameter (length of the longest path between any two nodes) of a binary tree."; Signatures=@("public int Solve(TreeNode root)"); NeedsTreeNode=$true }
    "BalancedBinaryTree" = @{ LC=110; Desc="Return true if the binary tree is height-balanced (depth of subtrees never differs by more than 1)."; Signatures=@("public bool Solve(TreeNode root)"); NeedsTreeNode=$true }
    "SameTree" = @{ LC=100; Desc="Return true if two binary trees are structurally identical and have the same values."; Signatures=@("public bool Solve(TreeNode p, TreeNode q)"); NeedsTreeNode=$true }
    "SubtreeOfAnotherTree" = @{ LC=572; Desc="Return true if subRoot is a subtree of root."; Signatures=@("public bool Solve(TreeNode root, TreeNode subRoot)"); NeedsTreeNode=$true }
    "LowestCommonAncestorOfBST" = @{ LC=235; Desc="Return the lowest common ancestor of two nodes in a BST."; Signatures=@("public TreeNode Solve(TreeNode root, TreeNode p, TreeNode q)"); NeedsTreeNode=$true }
    "BinaryTreeLevelOrderTraversal" = @{ LC=102; Desc="Return the level order traversal of a binary tree as a list of lists."; Signatures=@("public IList<IList<int>> Solve(TreeNode root)"); NeedsTreeNode=$true; NeedsGeneric=$true }
    "BinaryTreeRightSideView" = @{ LC=199; Desc="Return the values of nodes visible from the right side of the binary tree."; Signatures=@("public IList<int> Solve(TreeNode root)"); NeedsTreeNode=$true; NeedsGeneric=$true }
    "CountGoodNodesInBinaryTree" = @{ LC=1448; Desc="Count the number of good nodes where the path from root to node has no greater value than the node's value."; Signatures=@("public int Solve(TreeNode root)"); NeedsTreeNode=$true }
    "ValidateBinarySearchTree" = @{ LC=98; Desc="Return true if the binary tree is a valid binary search tree."; Signatures=@("public bool Solve(TreeNode root)"); NeedsTreeNode=$true }
    "KthSmallestElementInBST" = @{ LC=230; Desc="Return the kth smallest element in a BST (1-indexed)."; Signatures=@("public int Solve(TreeNode root, int k)"); NeedsTreeNode=$true }
    "ConstructBinaryTreeFromPreorderAndInorder" = @{ LC=105; Desc="Construct a binary tree from its preorder and inorder traversals."; Signatures=@("public TreeNode Solve(int[] preorder, int[] inorder)"); NeedsTreeNode=$true }
    "BinaryTreeMaximumPathSum" = @{ LC=124; Desc="Return the maximum path sum in a binary tree. A path can start and end at any node."; Signatures=@("public int Solve(TreeNode root)"); NeedsTreeNode=$true }
    "SerializeAndDeserializeBinaryTree" = @{ LC=297; Desc="Design an algorithm to serialize and deserialize a binary tree."; Signatures=@("public string Serialize(TreeNode root)","public TreeNode Deserialize(string data)"); NeedsTreeNode=$true }

    # ===== Tries & Heap =====
    "ImplementTrie" = @{ LC=208; Desc="Implement a trie with insert, search, and startsWith methods."; Signatures=@("public void Insert(string word)","public bool Search(string word)","public bool StartsWith(string prefix)"); NeedsGeneric=$false }
    "DesignAddAndSearchWordsDataStructure" = @{ LC=211; Desc="Design a data structure that supports adding words and searching with dot wildcards."; Signatures=@("public void AddWord(string word)","public bool Search(string word)"); NeedsGeneric=$false }
    "WordSearchII" = @{ LC=212; Desc="Return all words on the board that are in the word list."; Signatures=@("public IList<string> Solve(char[][] board, string[] words)"); NeedsGeneric=$true }
    "KthLargestElementInAStream" = @{ LC=703; Desc="Design a class that returns the kth largest element from a stream."; Signatures=@("public int Add(int val)"); NeedsGeneric=$true }
    "LastStoneWeight" = @{ LC=1046; Desc="Return the weight of the last remaining stone after smashing all stones."; Signatures=@("public int Solve(int[] stones)"); NeedsGeneric=$false }
    "KClosestPointsToOrigin" = @{ LC=973; Desc="Return the k closest points to the origin (0, 0)."; Signatures=@("public int[][] Solve(int[][] points, int k)"); NeedsGeneric=$false }
    "KthLargestElementInAnArray" = @{ LC=215; Desc="Return the kth largest element in the array."; Signatures=@("public int Solve(int[] nums, int k)"); NeedsGeneric=$false }
    "LcTaskScheduler" = @{ LC=621; Desc="Return the minimum time to finish all tasks given the cooling interval n."; Signatures=@("public int Solve(char[] tasks, int n)"); NeedsGeneric=$true }
    "FindMedianFromDataStream" = @{ LC=295; Desc="Design a data structure that supports adding numbers and finding the median."; Signatures=@("public void AddNum(int num)","public double FindMedian()"); NeedsGeneric=$true }
    "DesignTwitter" = @{ LC=355; Desc="Design a simplified Twitter with posting tweets, news feed, follow, and unfollow."; Signatures=@("public void PostTweet(int userId, int tweetId)","public IList<int> GetNewsFeed(int userId)","public void Follow(int followerId, int followeeId)","public void Unfollow(int followerId, int followeeId)"); NeedsGeneric=$true }

    # ===== Backtracking =====
    "Subsets" = @{ LC=78; Desc="Return all possible subsets (the power set)."; Signatures=@("public IList<IList<int>> Solve(int[] nums)"); NeedsGeneric=$true }
    "CombinationSum" = @{ LC=39; Desc="Return all unique combinations where the chosen numbers sum to target. You may reuse the same number."; Signatures=@("public IList<IList<int>> Solve(int[] candidates, int target)"); NeedsGeneric=$true }
    "Permutations" = @{ LC=46; Desc="Return all possible permutations of the array."; Signatures=@("public IList<IList<int>> Solve(int[] nums)"); NeedsGeneric=$true }
    "SubsetsII" = @{ LC=90; Desc="Return all possible subsets (duplicates not allowed in result). The array may contain duplicates."; Signatures=@("public IList<IList<int>> Solve(int[] nums)"); NeedsGeneric=$true }
    "CombinationSumII" = @{ LC=40; Desc="Return all unique combinations where the chosen numbers sum to target. Each number may be used only once."; Signatures=@("public IList<IList<int>> Solve(int[] candidates, int target)"); NeedsGeneric=$true }
    "WordSearch" = @{ LC=79; Desc="Return true if the word exists in the 2D board (adjacent cells only)."; Signatures=@("public bool Solve(char[][] board, string word)"); NeedsGeneric=$false }
    "PalindromePartitioning" = @{ LC=131; Desc="Return all possible palindrome partitioning of string s."; Signatures=@("public IList<IList<string>> Solve(string s)"); NeedsGeneric=$true }
    "LetterCombinationsOfAPhoneNumber" = @{ LC=17; Desc="Return all possible letter combinations that the number could represent (telephone keypad)."; Signatures=@("public IList<string> Solve(string digits)"); NeedsGeneric=$true }
    "NQueens" = @{ LC=51; Desc="Return all distinct solutions to the N-Queens puzzle."; Signatures=@("public IList<IList<string>> Solve(int n)"); NeedsGeneric=$true }

    # ===== Graphs =====
    "NumberOfIslands" = @{ LC=200; Desc="Return the number of islands in a 2D grid. '1' is land, '0' is water."; Signatures=@("public int Solve(char[][] grid)"); NeedsGeneric=$false }
    "CloneGraph" = @{ LC=133; Desc="Return a deep copy (clone) of an undirected graph. Each node has a value and a list of neighbors."; Signatures=@("public Node Solve(Node node)"); NeedsNodeGraph=$true; NeedsGeneric=$true }
    "MaxAreaOfIsland" = @{ LC=695; Desc="Return the maximum area of an island in a 2D grid."; Signatures=@("public int Solve(int[][] grid)"); NeedsGeneric=$false }
    "PacificAtlanticWaterFlow" = @{ LC=417; Desc="Return all cells where water can flow to both the Pacific and Atlantic oceans."; Signatures=@("public IList<IList<int>> Solve(int[][] heights)"); NeedsGeneric=$true }
    "SurroundedRegions" = @{ LC=130; Desc="Capture all surrounded regions by flipping 'O' to 'X' (except those on the border)."; Signatures=@("public void Solve(char[][] board)"); NeedsGeneric=$false }
    "RottingOranges" = @{ LC=994; Desc="Return the minimum number of minutes until all oranges rot, or -1 if impossible."; Signatures=@("public int Solve(int[][] grid)"); NeedsGeneric=$false }
    "CourseSchedule" = @{ LC=207; Desc="Return true if it is possible to finish all courses given prerequisite pairs."; Signatures=@("public bool Solve(int numCourses, int[][] prerequisites)"); NeedsGeneric=$true }
    "CourseScheduleII" = @{ LC=210; Desc="Return the ordering of courses to finish all courses, or an empty array if impossible."; Signatures=@("public int[] Solve(int numCourses, int[][] prerequisites)"); NeedsGeneric=$false }
    "RedundantConnection" = @{ LC=684; Desc="Return an edge that can be removed to make the graph a tree (no cycles)."; Signatures=@("public int[] Solve(int[][] edges)"); NeedsGeneric=$false }
    "WordLadder" = @{ LC=127; Desc="Return the length of the shortest transformation sequence from beginWord to endWord."; Signatures=@("public int Solve(string beginWord, string endWord, IList<string> wordList)"); NeedsGeneric=$true }

    # ===== Advanced Graphs =====
    "ReconstructItinerary" = @{ LC=332; Desc="Return the itinerary that reuses all tickets, in lexical order when multiple routes exist."; Signatures=@("public IList<string> Solve(IList<IList<string>> tickets)"); NeedsGeneric=$true }
    "MinCostToConnectAllPoints" = @{ LC=1584; Desc="Return the minimum cost to connect all points using Manhattan distance."; Signatures=@("public int Solve(int[][] points)"); NeedsGeneric=$false }
    "NetworkDelayTime" = @{ LC=743; Desc="Return the minimum time for all nodes to receive the signal, or -1 if impossible."; Signatures=@("public int Solve(int[][] times, int n, int k)"); NeedsGeneric=$false }
    "SwimInRisingWater" = @{ LC=778; Desc="Return the minimum maximum elevation along a path from (0,0) to (n-1,n-1)."; Signatures=@("public int Solve(int[][] grid)"); NeedsGeneric=$false }
    "CheapestFlightsWithinKStops" = @{ LC=787; Desc="Return the cheapest price from src to dst with at most k stops, or -1 if impossible."; Signatures=@("public int Solve(int n, int[][] flights, int src, int dst, int k)"); NeedsGeneric=$false }

    # ===== 1-D DP =====
    "ClimbingStairs" = @{ LC=70; Desc="Return the number of distinct ways to climb to the top of a staircase with n steps (1 or 2 steps at a time)."; Signatures=@("public int Solve(int n)"); NeedsGeneric=$false }
    "MinCostClimbingStairs" = @{ LC=746; Desc="Return the minimum cost to reach the top of the floor. You can start from index 0 or 1."; Signatures=@("public int Solve(int[] cost)"); NeedsGeneric=$false }
    "HouseRobber" = @{ LC=198; Desc="Return the maximum amount of money you can rob without robbing adjacent houses."; Signatures=@("public int Solve(int[] nums)"); NeedsGeneric=$false }
    "HouseRobberII" = @{ LC=213; Desc="Return the maximum amount you can rob from houses arranged in a circle (first and last are adjacent)."; Signatures=@("public int Solve(int[] nums)"); NeedsGeneric=$false }
    "LongestPalindromicSubstring" = @{ LC=5; Desc="Return the longest palindromic substring in s."; Signatures=@("public string Solve(string s)"); NeedsGeneric=$false }
    "PalindromicSubstrings" = @{ LC=647; Desc="Return the number of palindromic substrings in the string."; Signatures=@("public int Solve(string s)"); NeedsGeneric=$false }
    "DecodeWays" = @{ LC=91; Desc="Return the number of ways to decode a string of digits using A-Z mapping (1-26)."; Signatures=@("public int Solve(string s)"); NeedsGeneric=$false }
    "CoinChange" = @{ LC=322; Desc="Return the fewest number of coins needed to make up the amount, or -1 if impossible."; Signatures=@("public int Solve(int[] coins, int amount)"); NeedsGeneric=$false }
    "MaximumProductSubarray" = @{ LC=152; Desc="Return the maximum product subarray. The subarray must be contiguous."; Signatures=@("public int Solve(int[] nums)"); NeedsGeneric=$false }
    "WordBreak" = @{ LC=139; Desc="Return true if the string can be segmented into words from the dictionary."; Signatures=@("public bool Solve(string s, IList<string> wordDict)"); NeedsGeneric=$true }
    "LongestIncreasingSubsequence" = @{ LC=300; Desc="Return the length of the longest strictly increasing subsequence."; Signatures=@("public int Solve(int[] nums)"); NeedsGeneric=$false }
    "PartitionEqualSubsetSum" = @{ LC=416; Desc="Return true if the array can be partitioned into two subsets with equal sum."; Signatures=@("public bool Solve(int[] nums)"); NeedsGeneric=$false }

    # ===== 2-D DP =====
    "UniquePaths" = @{ LC=62; Desc="Return the number of unique paths from top-left to bottom-right of an m×n grid (move only right or down)."; Signatures=@("public int Solve(int m, int n)"); NeedsGeneric=$false }
    "LongestCommonSubsequence" = @{ LC=1143; Desc="Return the length of the longest common subsequence of two strings."; Signatures=@("public int Solve(string text1, string text2)"); NeedsGeneric=$false }
    "BestTimeToBuyAndSellStockWithCooldown" = @{ LC=309; Desc="Return the maximum profit from buying/selling stock with a 1-day cooldown after selling."; Signatures=@("public int Solve(int[] prices)"); NeedsGeneric=$false }
    "CoinChangeII" = @{ LC=518; Desc="Return the number of combinations that make up the amount (unlimited coins)."; Signatures=@("public int Solve(int amount, int[] coins)"); NeedsGeneric=$false }
    "TargetSum" = @{ LC=494; Desc="Return the number of ways to assign + and - to make the sum equal to target."; Signatures=@("public int Solve(int[] nums, int target)"); NeedsGeneric=$false }
    "InterleavingString" = @{ LC=97; Desc="Return true if s3 is formed by interleaving s1 and s2, preserving character order."; Signatures=@("public bool Solve(string s1, string s2, string s3)"); NeedsGeneric=$false }
    "LongestIncreasingPathInAMatrix" = @{ LC=329; Desc="Return the length of the longest increasing path in a 2D matrix."; Signatures=@("public int Solve(int[][] matrix)"); NeedsGeneric=$false }
    "DistinctSubsequences" = @{ LC=115; Desc="Return the number of distinct subsequences of s that equal t."; Signatures=@("public int Solve(string s, string t)"); NeedsGeneric=$false }
    "EditDistance" = @{ LC=72; Desc="Return the minimum number of operations (insert, delete, replace) to convert word1 to word2."; Signatures=@("public int Solve(string word1, string word2)"); NeedsGeneric=$false }
    "BurstBalloons" = @{ LC=312; Desc="Return the maximum coins you can collect by bursting balloons strategically."; Signatures=@("public int Solve(int[] nums)"); NeedsGeneric=$false }
    "RegularExpressionMatching" = @{ LC=10; Desc="Return true if s matches p with support for '.' and '*' wildcards."; Signatures=@("public bool Solve(string s, string p)"); NeedsGeneric=$false }

    # ===== Greedy =====
    "MaximumSubarray" = @{ LC=53; Desc="Return the sum of the contiguous subarray with the largest sum (Kadane's algorithm)."; Signatures=@("public int Solve(int[] nums)"); NeedsGeneric=$false }
    "JumpGame" = @{ LC=55; Desc="Return true if you can reach the last index. Each element represents your maximum jump length."; Signatures=@("public bool Solve(int[] nums)"); NeedsGeneric=$false }
    "JumpGameII" = @{ LC=45; Desc="Return the minimum number of jumps to reach the last index."; Signatures=@("public int Solve(int[] nums)"); NeedsGeneric=$false }
    "GasStation" = @{ LC=134; Desc="Return the starting gas station index to complete the circuit, or -1 if impossible."; Signatures=@("public int Solve(int[] gas, int[] cost)"); NeedsGeneric=$false }
    "HandOfStraights" = @{ LC=846; Desc="Return true if the hand can be rearranged into groups of consecutive cards of size groupSize."; Signatures=@("public bool Solve(int[] hand, int groupSize)"); NeedsGeneric=$true }
    "MergeTripletsToFormTargetTriplet" = @{ LC=1899; Desc="Return true if you can form the target triplet by merging triplets (taking max of each position)."; Signatures=@("public bool Solve(int[][] triplets, int[] target)"); NeedsGeneric=$false }
    "PartitionLabels" = @{ LC=763; Desc="Return the list of partition sizes so that letters appear in at most one partition."; Signatures=@("public IList<int> Solve(string s)"); NeedsGeneric=$true }
    "ValidParenthesisString" = @{ LC=678; Desc="Return true if the string with '*' wildcards can be a valid parentheses string."; Signatures=@("public bool Solve(string s)"); NeedsGeneric=$false }

    # ===== Intervals =====
    "InsertInterval" = @{ LC=57; Desc="Insert a new interval into a sorted, non-overlapping interval list, merging if needed."; Signatures=@("public int[][] Solve(int[][] intervals, int[] newInterval)"); NeedsGeneric=$false }
    "MergeIntervals" = @{ LC=56; Desc="Merge all overlapping intervals and return the non-overlapping intervals."; Signatures=@("public int[][] Solve(int[][] intervals)"); NeedsGeneric=$false }
    "NonOverlappingIntervals" = @{ LC=435; Desc="Return the minimum number of intervals to remove to make the rest non-overlapping."; Signatures=@("public int Solve(int[][] intervals)"); NeedsGeneric=$false }
    "MeetingRooms" = @{ LC=252; Desc="Return true if a person can attend all meetings (no overlapping intervals)."; Signatures=@("public bool Solve(int[][] intervals)"); NeedsGeneric=$false }
    "MeetingRoomsII" = @{ LC=253; Desc="Return the minimum number of conference rooms required for all meetings."; Signatures=@("public int Solve(int[][] intervals)"); NeedsGeneric=$false }
    "MinimumIntervalToIncludeEachQuery" = @{ LC=1851; Desc="Return the minimum interval size containing each query, or -1 if none."; Signatures=@("public int[] Solve(int[][] intervals, int[] queries)"); NeedsGeneric=$false }

    # ===== Math & Geometry =====
    "RotateImage" = @{ LC=48; Desc="Rotate the n×n matrix 90 degrees clockwise in-place."; Signatures=@("public void Solve(int[][] matrix)"); NeedsGeneric=$false }
    "SpiralMatrix" = @{ LC=54; Desc="Return the elements of the matrix in spiral order."; Signatures=@("public IList<int> Solve(int[][] matrix)"); NeedsGeneric=$true }
    "SetMatrixZeroes" = @{ LC=73; Desc="Set entire row and column to zero if an element is zero. Do it in-place."; Signatures=@("public void Solve(int[][] matrix)"); NeedsGeneric=$false }
    "HappyNumber" = @{ LC=202; Desc="Return true if n is a happy number (cycle ends at 1 after summing squares of digits)."; Signatures=@("public bool Solve(int n)"); NeedsGeneric=$false }
    "PlusOne" = @{ LC=66; Desc="Return the array of digits incremented by one."; Signatures=@("public int[] Solve(int[] digits)"); NeedsGeneric=$false }
    "PowXN" = @{ LC=50; Desc="Compute x raised to the power n (x^n)."; Signatures=@("public double Solve(double x, int n)"); NeedsGeneric=$false }
    "MultiplyStrings" = @{ LC=43; Desc="Return the product of two non-negative integers represented as strings."; Signatures=@("public string Solve(string num1, string num2)"); NeedsGeneric=$false }
    "DetectSquares" = @{ LC=2013; Desc="Design a data structure to count the number of axis-aligned squares from given points."; Signatures=@("public void Add(int[] point)","public int Count(int[] point)"); NeedsGeneric=$true }

    # ===== Bit Manipulation =====
    "SingleNumber" = @{ LC=136; Desc="Return the single number that appears only once (others appear twice). Solve in linear time with constant space."; Signatures=@("public int Solve(int[] nums)"); NeedsGeneric=$false }
    "NumberOf1Bits" = @{ LC=191; Desc="Return the number of '1' bits in the binary representation of n."; Signatures=@("public int Solve(int n)"); NeedsGeneric=$false }
    "CountingBits" = @{ LC=338; Desc="Return an array where result[i] is the number of 1 bits in binary representation of i."; Signatures=@("public int[] Solve(int n)"); NeedsGeneric=$false }
    "ReverseBits" = @{ LC=190; Desc="Reverse the bits of a 32-bit unsigned integer."; Signatures=@("public uint Solve(uint n)"); NeedsGeneric=$false }
    "MissingNumber" = @{ LC=268; Desc="Return the missing number in the range [0, n] from the array of n distinct numbers."; Signatures=@("public int Solve(int[] nums)"); NeedsGeneric=$false }
    "SumOfTwoIntegers" = @{ LC=371; Desc="Return the sum of two integers without using + or - operators."; Signatures=@("public int Solve(int a, int b)"); NeedsGeneric=$false }
    "ReverseInteger" = @{ LC=7; Desc="Return the reversed digits of a 32-bit signed integer. Return 0 if overflow."; Signatures=@("public int Solve(int x)"); NeedsGeneric=$false }
}

# Helper function to get ListNode class definition
function GetListNodeClass() {
    return @"
/// <summary>
/// Definition for a singly-linked list node.
/// </summary>
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
"@
}

# Helper function to get TreeNode class definition
function GetTreeNodeClass() {
    return @"
/// <summary>
/// Definition for a binary tree node.
/// </summary>
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
"@
}

# Helper function to get Node class for CopyListWithRandomPointer
function GetNodeClassRandom() {
    return @"
/// <summary>
/// Definition for a linked list node with a random pointer.
/// </summary>
public class Node
{
    public int val;
    public Node next;
    public Node random;

    public Node(int val = 0, Node next = null, Node random = null)
    {
        this.val = val;
        this.next = next;
        this.random = random;
    }
}
"@
}

# Helper function to get Node class for CloneGraph
function GetNodeClassGraph() {
    return @"
/// <summary>
/// Definition for a graph node.
/// </summary>
public class Node
{
    public int val;
    public IList<Node> neighbors;

    public Node()
    {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val)
    {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }
}
"@
}

# Build description text with examples based on the problem
function GetDescription($meta) {
    $lc = $meta.LC
    $desc = $meta.Desc
    $sig = $meta.Signatures[0]
    
    $descText = @"
/// <summary>
/// $(GetProblemTitle $lc)
/// 對應 LeetCode：LC $lc
/// 來源：NeetCode 150
///
/// $desc
///
/// 方法簽名：$sig
/// </summary>
"@
    return $descText
}

# Get problem title from the class name (convert PascalCase to spaced words)
function GetProblemTitle($lc) {
    # We'll use the filename-derived title
    return ""
}

$updatedCount = 0
$files = Get-ChildItem "$ProblemsDir\*.cs" | Where-Object { $_.Name -notin @('CommandParser.cs','DeviceParameterCache.cs','ProblemTemplate.cs','TwoSum.cs','WaferScanOptimizer.cs') }

# Sort files alphabetically for consistent processing
$files = $files | Sort-Object Name

Write-Host "Found $($files.Count) files to process..."

foreach ($file in $files) {
    $className = [System.IO.Path]::GetFileNameWithoutExtension($file.Name)
    
    if (-not $problems.ContainsKey($className)) {
        Write-Host "  SKIP: $className - no metadata found"
        continue
    }
    
    $meta = $problems[$className]
    $content = Get-Content $file.FullName -Raw
    
    $updated = $false
    $originalContent = $content
    
    # 1. Replace the entire original summary block (with the TODO line) with a new description
    $signature = $meta.Signatures[0]
    
    # Convert signature text to description format example
    $descExample = ""
    if ($meta.Signatures.Count -gt 1) {
        $descExample = ($meta.Signatures | ForEach-Object { "/// 方法簽名：$_" }) -join "`r`n"
    } else {
        $descExample = "/// 方法簽名：$signature"
    }
    
    $problemTitle = ($className -creplace '([A-Z])', ' $1').Trim()
    
    $newDescBlock = @"
/// <summary>
/// $problemTitle
/// 對應 LeetCode：LC $($meta.LC)
/// 來源：NeetCode 150
/// 難度：{DIFFICULTY}
/// 分類：{CATEGORY}
///
/// $(if ($meta.Desc) { $meta.Desc } else { "" })
///
$descExample
/// </summary>
"@
    
    # Try approach 1: match the entire old-style summary block (with TODO)
    $pattern1 = '(?s)/// <summary>\r?\n(?:/// .*\r?\n)*/// TODO: 加入題目描述與範例\r?\n/// </summary>'
    # Try approach 2: match the broken nested summary (from first /// <summary> to last /// </summary>)
    $pattern2 = '(?s)/// <summary>\r?\n(?:/// .*\r?\n)*/// \r?\n/// <summary>\r?\n(?:/// .*\r?\n)*/// </summary>\r?\n/// </summary>'
    
    $found = $false
    if ($content -match $pattern1) {
        $found = $true
        $origBlock = $matches[0]
    } elseif ($content -match $pattern2) {
        $found = $true
        $origBlock = $matches[0]
    }
    
    if ($found) {
        $difficulty = "Unknown"
        $category = "Unknown"
        if ($origBlock -match '/// 難度：(.+)') { $difficulty = $matches[1] }
        if ($origBlock -match '/// 分類：(.+)') { $category = $matches[1] }
        
        $newBlockWithMeta = $newDescBlock -replace '{DIFFICULTY}', $difficulty -replace '{CATEGORY}', $category
        
        $content = $content -replace [regex]::Escape($origBlock), $newBlockWithMeta
        $updated = $true
    } else {
        Write-Host "  WARN: $className - could not find summary block"
    }
    
    # 2. Replace the commented-out method signature with actual method signature
    $oldMethodBlock = @"
    // TODO: 實作你的解法
    // public ReturnType Solve(Parameters)
    // {
    //     throw new NotImplementedException();
    // }
"@
    
    if ($meta.Signatures.Count -gt 1) {
        # Multi-method class (LRUCache, MinStack, Trie, etc.)
        $multiMethods = @()
        $multiMethods += "    // TODO: 實作你的解法"
        foreach ($ms in $meta.Signatures) {
            $multiMethods += "    $ms"
            $multiMethods += "    {"
            $multiMethods += "        throw new NotImplementedException();"
            $multiMethods += "    }"
            $multiMethods += ""
        }
        # Remove trailing empty line
        if ($multiMethods[-1] -eq "") { $multiMethods = $multiMethods[0..($multiMethods.Length-2)] }
        $newMethodBlock = $multiMethods -join "`r`n"
    } else {
        # Single method class
        $newMethodBlock = @"
    $signature
    {
        throw new NotImplementedException();
    }
"@
    }
    
    if ($content.Contains($oldMethodBlock)) {
        $content = $content -replace [regex]::Escape($oldMethodBlock), $newMethodBlock
        $updated = $true
    } else {
        Write-Host "  WARN: $className - could not find commented method block"
        # Try alternative: find the pattern
        Write-Host "         Content snippet:"
        $lines = $content -split "`r`n|`n"
        for ($i = 0; $i -lt $lines.Count; $i++) {
            if ($lines[$i] -match "TODO: 實作") {
                Write-Host "         Line $($i+1): $($lines[$i])"
                break
            }
        }
    }
    
    # 3. Add necessary using statements
    $needsGeneric = $meta.NeedsGeneric
    $needsListNode = $meta.NeedsListNode
    $needsTreeNode = $meta.NeedsTreeNode
    $needsNode = $meta.NeedsNode
    $needsNodeGraph = $meta.NeedsNodeGraph
    
    # Check if we need to add using System.Collections.Generic;
    if ($needsGeneric -and -not $content.Contains("using System.Collections.Generic;")) {
        $content = $content -replace "using System;", "using System;`r`nusing System.Collections.Generic;"
        $updated = $true
    }
    
    # 4. Add class definitions if needed
    # Insert before the problem class
    $classDeclaration = "public class $className"
    $classPattern = [regex]::Escape($classDeclaration)
    
    if ($needsListNode) {
        $listNodeClass = GetListNodeClass
        if (-not $content.Contains("public class ListNode")) {
            $content = $content -replace $classPattern, "$listNodeClass`r`n`r`n$classDeclaration"
            $updated = $true
        }
    }
    
    if ($needsTreeNode) {
        $treeNodeClass = GetTreeNodeClass
        if (-not $content.Contains("public class TreeNode")) {
            $content = $content -replace $classPattern, "$treeNodeClass`r`n`r`n$classDeclaration"
            $updated = $true
        }
    }
    
    if ($needsNode) {
        $nodeClass = GetNodeClassRandom
        if (-not $content.Contains("public class Node")) {
            $content = $content -replace $classPattern, "$nodeClass`r`n`r`n$classDeclaration"
            $updated = $true
        }
    }
    
    if ($needsNodeGraph) {
        $nodeClass = GetNodeClassGraph
        if (-not $content.Contains("public class Node")) {
            $content = $content -replace $classPattern, "$nodeClass`r`n`r`n$classDeclaration"
            $updated = $true
        }
    }
    
    # Write the file if changed
    if ($updated) {
        $content = $content -replace "`r`n?|`n", "`r`n"  # Normalize line endings
        Set-Content -Path $file.FullName -Value $content -NoNewline -Encoding UTF8
        $updatedCount++
        Write-Host "  UPDATED: $className"
    } else {
        Write-Host "  NO CHANGE: $className"
    }
}

Write-Host "`nDone! Updated $updatedCount files."
