# Batch Scaffold NeetCode 150
# 此腳本批次建立 NeetCode 150 所有題目的模板檔案
# 執行方式：在專案根目錄執行 .\.agents\skills\leetcode-helper\scripts\batch-scaffold-neetcode150.ps1

$rootDir = Resolve-Path "$PSScriptRoot\..\..\..\.."
$problemsDir = "$rootDir\LeetCodePractice\Problems"
$testsDir = "$rootDir\LeetCodePractice.Tests"
$problemListPath = "$rootDir\.agents\skills\leetcode-helper\resources\problem-list.md"

# 確保目錄存在
if (-not (Test-Path $problemsDir)) { New-Item -ItemType Directory -Path $problemsDir -Force }
if (-not (Test-Path $testsDir)) { New-Item -ItemType Directory -Path $testsDir -Force }

# ===== 題目資料 =====
# 格式: @{Name="題目名稱"; Number=LC編號; Difficulty="難度"; Category="分類"; Source="來源"}

$problems = @(
    # === Arrays & Hashing ===
    @{Name="ContainsDuplicate"; Number=217; Difficulty="Easy"; Category="Arrays & Hashing"; Source="NeetCode 150"}
    @{Name="ValidAnagram"; Number=242; Difficulty="Easy"; Category="Arrays & Hashing"; Source="NeetCode 150"}
    @{Name="TwoSum"; Number=1; Difficulty="Easy"; Category="Arrays & Hashing"; Source="NeetCode 150"}
    @{Name="GroupAnagrams"; Number=49; Difficulty="Medium"; Category="Arrays & Hashing"; Source="NeetCode 150"}
    @{Name="TopKFrequentElements"; Number=347; Difficulty="Medium"; Category="Arrays & Hashing"; Source="NeetCode 150"}
    @{Name="ProductOfArrayExceptSelf"; Number=238; Difficulty="Medium"; Category="Arrays & Hashing"; Source="NeetCode 150"}
    @{Name="ValidSudoku"; Number=36; Difficulty="Medium"; Category="Arrays & Hashing"; Source="NeetCode 150"}
    @{Name="EncodeAndDecodeStrings"; Number=271; Difficulty="Medium"; Category="Arrays & Hashing"; Source="NeetCode 150"}
    @{Name="LongestConsecutiveSequence"; Number=128; Difficulty="Medium"; Category="Arrays & Hashing"; Source="NeetCode 150"}

    # === Two Pointers ===
    @{Name="ValidPalindrome"; Number=125; Difficulty="Easy"; Category="Two Pointers"; Source="NeetCode 150"}
    @{Name="TwoSumII"; Number=167; Difficulty="Medium"; Category="Two Pointers"; Source="NeetCode 150"}
    @{Name="ThreeSum"; Number=15; Difficulty="Medium"; Category="Two Pointers"; Source="NeetCode 150"}
    @{Name="ContainerWithMostWater"; Number=11; Difficulty="Medium"; Category="Two Pointers"; Source="NeetCode 150"}
    @{Name="TrappingRainWater"; Number=42; Difficulty="Hard"; Category="Two Pointers"; Source="NeetCode 150"}

    # === Sliding Window ===
    @{Name="BestTimeToBuyAndSellStock"; Number=121; Difficulty="Easy"; Category="Sliding Window"; Source="NeetCode 150"}
    @{Name="LongestSubstringWithoutRepeatingCharacters"; Number=3; Difficulty="Medium"; Category="Sliding Window"; Source="NeetCode 150"}
    @{Name="LongestRepeatingCharacterReplacement"; Number=424; Difficulty="Medium"; Category="Sliding Window"; Source="NeetCode 150"}
    @{Name="PermutationInString"; Number=567; Difficulty="Medium"; Category="Sliding Window"; Source="NeetCode 150"}
    @{Name="MinimumWindowSubstring"; Number=76; Difficulty="Hard"; Category="Sliding Window"; Source="NeetCode 150"}
    @{Name="SlidingWindowMaximum"; Number=239; Difficulty="Hard"; Category="Sliding Window"; Source="NeetCode 150"}

    # === Stack ===
    @{Name="ValidParentheses"; Number=20; Difficulty="Easy"; Category="Stack"; Source="NeetCode 150"}
    @{Name="MinStack"; Number=155; Difficulty="Medium"; Category="Stack"; Source="NeetCode 150"}
    @{Name="EvaluateReversePolishNotation"; Number=150; Difficulty="Medium"; Category="Stack"; Source="NeetCode 150"}
    @{Name="GenerateParentheses"; Number=22; Difficulty="Medium"; Category="Stack"; Source="NeetCode 150"}
    @{Name="DailyTemperatures"; Number=739; Difficulty="Medium"; Category="Stack"; Source="NeetCode 150"}
    @{Name="CarFleet"; Number=853; Difficulty="Medium"; Category="Stack"; Source="NeetCode 150"}
    @{Name="LargestRectangleInHistogram"; Number=84; Difficulty="Hard"; Category="Stack"; Source="NeetCode 150"}

    # === Binary Search ===
    @{Name="BinarySearch"; Number=704; Difficulty="Easy"; Category="Binary Search"; Source="NeetCode 150"}
    @{Name="SearchA2DMatrix"; Number=74; Difficulty="Medium"; Category="Binary Search"; Source="NeetCode 150"}
    @{Name="KokoEatingBananas"; Number=875; Difficulty="Medium"; Category="Binary Search"; Source="NeetCode 150"}
    @{Name="FindMinimumInRotatedSortedArray"; Number=153; Difficulty="Medium"; Category="Binary Search"; Source="NeetCode 150"}
    @{Name="SearchInRotatedSortedArray"; Number=33; Difficulty="Medium"; Category="Binary Search"; Source="NeetCode 150"}
    @{Name="TimeBasedKeyValueStore"; Number=981; Difficulty="Medium"; Category="Binary Search"; Source="NeetCode 150"}
    @{Name="MedianOfTwoSortedArrays"; Number=4; Difficulty="Hard"; Category="Binary Search"; Source="NeetCode 150"}

    # === Linked List ===
    @{Name="ReverseLinkedList"; Number=206; Difficulty="Easy"; Category="Linked List"; Source="NeetCode 150"}
    @{Name="MergeTwoSortedLists"; Number=21; Difficulty="Easy"; Category="Linked List"; Source="NeetCode 150"}
    @{Name="ReorderList"; Number=143; Difficulty="Medium"; Category="Linked List"; Source="NeetCode 150"}
    @{Name="RemoveNthNodeFromEndOfList"; Number=19; Difficulty="Medium"; Category="Linked List"; Source="NeetCode 150"}
    @{Name="CopyListWithRandomPointer"; Number=138; Difficulty="Medium"; Category="Linked List"; Source="NeetCode 150"}
    @{Name="AddTwoNumbers"; Number=2; Difficulty="Medium"; Category="Linked List"; Source="NeetCode 150"}
    @{Name="LinkedListCycle"; Number=141; Difficulty="Easy"; Category="Linked List"; Source="NeetCode 150"}
    @{Name="FindTheDuplicateNumber"; Number=287; Difficulty="Medium"; Category="Linked List"; Source="NeetCode 150"}
    @{Name="LRUCache"; Number=146; Difficulty="Medium"; Category="Linked List"; Source="NeetCode 150"}
    @{Name="MergeKSortedLists"; Number=23; Difficulty="Hard"; Category="Linked List"; Source="NeetCode 150"}
    @{Name="ReverseNodesInKGroup"; Number=25; Difficulty="Hard"; Category="Linked List"; Source="NeetCode 150"}

    # === Trees ===
    @{Name="InvertBinaryTree"; Number=226; Difficulty="Easy"; Category="Trees"; Source="NeetCode 150"}
    @{Name="MaximumDepthOfBinaryTree"; Number=104; Difficulty="Easy"; Category="Trees"; Source="NeetCode 150"}
    @{Name="DiameterOfBinaryTree"; Number=543; Difficulty="Easy"; Category="Trees"; Source="NeetCode 150"}
    @{Name="BalancedBinaryTree"; Number=110; Difficulty="Easy"; Category="Trees"; Source="NeetCode 150"}
    @{Name="SameTree"; Number=100; Difficulty="Easy"; Category="Trees"; Source="NeetCode 150"}
    @{Name="SubtreeOfAnotherTree"; Number=572; Difficulty="Easy"; Category="Trees"; Source="NeetCode 150"}
    @{Name="LowestCommonAncestorOfBST"; Number=235; Difficulty="Medium"; Category="Trees"; Source="NeetCode 150"}
    @{Name="BinaryTreeLevelOrderTraversal"; Number=102; Difficulty="Medium"; Category="Trees"; Source="NeetCode 150"}
    @{Name="BinaryTreeRightSideView"; Number=199; Difficulty="Medium"; Category="Trees"; Source="NeetCode 150"}
    @{Name="CountGoodNodesInBinaryTree"; Number=1448; Difficulty="Medium"; Category="Trees"; Source="NeetCode 150"}
    @{Name="ValidateBinarySearchTree"; Number=98; Difficulty="Medium"; Category="Trees"; Source="NeetCode 150"}
    @{Name="KthSmallestElementInBST"; Number=230; Difficulty="Medium"; Category="Trees"; Source="NeetCode 150"}
    @{Name="ConstructBinaryTreeFromPreorderAndInorder"; Number=105; Difficulty="Medium"; Category="Trees"; Source="NeetCode 150"}
    @{Name="BinaryTreeMaximumPathSum"; Number=124; Difficulty="Hard"; Category="Trees"; Source="NeetCode 150"}
    @{Name="SerializeAndDeserializeBinaryTree"; Number=297; Difficulty="Hard"; Category="Trees"; Source="NeetCode 150"}

    # === Tries ===
    @{Name="ImplementTrie"; Number=208; Difficulty="Medium"; Category="Tries"; Source="NeetCode 150"}
    @{Name="DesignAddAndSearchWordsDataStructure"; Number=211; Difficulty="Medium"; Category="Tries"; Source="NeetCode 150"}
    @{Name="WordSearchII"; Number=212; Difficulty="Hard"; Category="Tries"; Source="NeetCode 150"}

    # === Heap / Priority Queue ===
    @{Name="KthLargestElementInAStream"; Number=703; Difficulty="Easy"; Category="Heap / Priority Queue"; Source="NeetCode 150"}
    @{Name="LastStoneWeight"; Number=1046; Difficulty="Easy"; Category="Heap / Priority Queue"; Source="NeetCode 150"}
    @{Name="KClosestPointsToOrigin"; Number=973; Difficulty="Medium"; Category="Heap / Priority Queue"; Source="NeetCode 150"}
    @{Name="KthLargestElementInAnArray"; Number=215; Difficulty="Medium"; Category="Heap / Priority Queue"; Source="NeetCode 150"}
    @{Name="TaskScheduler"; Number=621; Difficulty="Medium"; Category="Heap / Priority Queue"; Source="NeetCode 150"}
    @{Name="DesignTwitter"; Number=355; Difficulty="Medium"; Category="Heap / Priority Queue"; Source="NeetCode 150"}
    @{Name="FindMedianFromDataStream"; Number=295; Difficulty="Hard"; Category="Heap / Priority Queue"; Source="NeetCode 150"}

    # === Backtracking ===
    @{Name="Subsets"; Number=78; Difficulty="Medium"; Category="Backtracking"; Source="NeetCode 150"}
    @{Name="CombinationSum"; Number=39; Difficulty="Medium"; Category="Backtracking"; Source="NeetCode 150"}
    @{Name="Permutations"; Number=46; Difficulty="Medium"; Category="Backtracking"; Source="NeetCode 150"}
    @{Name="SubsetsII"; Number=90; Difficulty="Medium"; Category="Backtracking"; Source="NeetCode 150"}
    @{Name="CombinationSumII"; Number=40; Difficulty="Medium"; Category="Backtracking"; Source="NeetCode 150"}
    @{Name="WordSearch"; Number=79; Difficulty="Medium"; Category="Backtracking"; Source="NeetCode 150"}
    @{Name="PalindromePartitioning"; Number=131; Difficulty="Medium"; Category="Backtracking"; Source="NeetCode 150"}
    @{Name="LetterCombinationsOfAPhoneNumber"; Number=17; Difficulty="Medium"; Category="Backtracking"; Source="NeetCode 150"}
    @{Name="NQueens"; Number=51; Difficulty="Hard"; Category="Backtracking"; Source="NeetCode 150"}

    # === Graphs ===
    @{Name="NumberOfIslands"; Number=200; Difficulty="Medium"; Category="Graphs"; Source="NeetCode 150"}
    @{Name="CloneGraph"; Number=133; Difficulty="Medium"; Category="Graphs"; Source="NeetCode 150"}
    @{Name="MaxAreaOfIsland"; Number=695; Difficulty="Medium"; Category="Graphs"; Source="NeetCode 150"}
    @{Name="PacificAtlanticWaterFlow"; Number=417; Difficulty="Medium"; Category="Graphs"; Source="NeetCode 150"}
    @{Name="SurroundedRegions"; Number=130; Difficulty="Medium"; Category="Graphs"; Source="NeetCode 150"}
    @{Name="RottingOranges"; Number=994; Difficulty="Medium"; Category="Graphs"; Source="NeetCode 150"}
    @{Name="CourseSchedule"; Number=207; Difficulty="Medium"; Category="Graphs"; Source="NeetCode 150"}
    @{Name="CourseScheduleII"; Number=210; Difficulty="Medium"; Category="Graphs"; Source="NeetCode 150"}
    @{Name="RedundantConnection"; Number=684; Difficulty="Medium"; Category="Graphs"; Source="NeetCode 150"}
    @{Name="WordLadder"; Number=127; Difficulty="Hard"; Category="Graphs"; Source="NeetCode 150"}

    # === Advanced Graphs ===
    @{Name="ReconstructItinerary"; Number=332; Difficulty="Hard"; Category="Advanced Graphs"; Source="NeetCode 150"}
    @{Name="MinCostToConnectAllPoints"; Number=1584; Difficulty="Medium"; Category="Advanced Graphs"; Source="NeetCode 150"}
    @{Name="NetworkDelayTime"; Number=743; Difficulty="Medium"; Category="Advanced Graphs"; Source="NeetCode 150"}
    @{Name="SwimInRisingWater"; Number=778; Difficulty="Hard"; Category="Advanced Graphs"; Source="NeetCode 150"}
    @{Name="CheapestFlightsWithinKStops"; Number=787; Difficulty="Medium"; Category="Advanced Graphs"; Source="NeetCode 150"}

    # === 1-D Dynamic Programming ===
    @{Name="ClimbingStairs"; Number=70; Difficulty="Easy"; Category="1-D Dynamic Programming"; Source="NeetCode 150"}
    @{Name="MinCostClimbingStairs"; Number=746; Difficulty="Easy"; Category="1-D Dynamic Programming"; Source="NeetCode 150"}
    @{Name="HouseRobber"; Number=198; Difficulty="Medium"; Category="1-D Dynamic Programming"; Source="NeetCode 150"}
    @{Name="HouseRobberII"; Number=213; Difficulty="Medium"; Category="1-D Dynamic Programming"; Source="NeetCode 150"}
    @{Name="LongestPalindromicSubstring"; Number=5; Difficulty="Medium"; Category="1-D Dynamic Programming"; Source="NeetCode 150"}
    @{Name="PalindromicSubstrings"; Number=647; Difficulty="Medium"; Category="1-D Dynamic Programming"; Source="NeetCode 150"}
    @{Name="DecodeWays"; Number=91; Difficulty="Medium"; Category="1-D Dynamic Programming"; Source="NeetCode 150"}
    @{Name="CoinChange"; Number=322; Difficulty="Medium"; Category="1-D Dynamic Programming"; Source="NeetCode 150"}
    @{Name="MaximumProductSubarray"; Number=152; Difficulty="Medium"; Category="1-D Dynamic Programming"; Source="NeetCode 150"}
    @{Name="WordBreak"; Number=139; Difficulty="Medium"; Category="1-D Dynamic Programming"; Source="NeetCode 150"}
    @{Name="LongestIncreasingSubsequence"; Number=300; Difficulty="Medium"; Category="1-D Dynamic Programming"; Source="NeetCode 150"}
    @{Name="PartitionEqualSubsetSum"; Number=416; Difficulty="Medium"; Category="1-D Dynamic Programming"; Source="NeetCode 150"}

    # === 2-D Dynamic Programming ===
    @{Name="UniquePaths"; Number=62; Difficulty="Medium"; Category="2-D Dynamic Programming"; Source="NeetCode 150"}
    @{Name="LongestCommonSubsequence"; Number=1143; Difficulty="Medium"; Category="2-D Dynamic Programming"; Source="NeetCode 150"}
    @{Name="BestTimeToBuyAndSellStockWithCooldown"; Number=309; Difficulty="Medium"; Category="2-D Dynamic Programming"; Source="NeetCode 150"}
    @{Name="CoinChangeII"; Number=518; Difficulty="Medium"; Category="2-D Dynamic Programming"; Source="NeetCode 150"}
    @{Name="TargetSum"; Number=494; Difficulty="Medium"; Category="2-D Dynamic Programming"; Source="NeetCode 150"}
    @{Name="InterleavingString"; Number=97; Difficulty="Medium"; Category="2-D Dynamic Programming"; Source="NeetCode 150"}
    @{Name="LongestIncreasingPathInAMatrix"; Number=329; Difficulty="Hard"; Category="2-D Dynamic Programming"; Source="NeetCode 150"}
    @{Name="DistinctSubsequences"; Number=115; Difficulty="Hard"; Category="2-D Dynamic Programming"; Source="NeetCode 150"}
    @{Name="EditDistance"; Number=72; Difficulty="Medium"; Category="2-D Dynamic Programming"; Source="NeetCode 150"}
    @{Name="BurstBalloons"; Number=312; Difficulty="Hard"; Category="2-D Dynamic Programming"; Source="NeetCode 150"}
    @{Name="RegularExpressionMatching"; Number=10; Difficulty="Hard"; Category="2-D Dynamic Programming"; Source="NeetCode 150"}

    # === Greedy ===
    @{Name="MaximumSubarray"; Number=53; Difficulty="Medium"; Category="Greedy"; Source="NeetCode 150"}
    @{Name="JumpGame"; Number=55; Difficulty="Medium"; Category="Greedy"; Source="NeetCode 150"}
    @{Name="JumpGameII"; Number=45; Difficulty="Medium"; Category="Greedy"; Source="NeetCode 150"}
    @{Name="GasStation"; Number=134; Difficulty="Medium"; Category="Greedy"; Source="NeetCode 150"}
    @{Name="HandOfStraights"; Number=846; Difficulty="Medium"; Category="Greedy"; Source="NeetCode 150"}
    @{Name="MergeTripletsToFormTargetTriplet"; Number=1899; Difficulty="Medium"; Category="Greedy"; Source="NeetCode 150"}
    @{Name="PartitionLabels"; Number=763; Difficulty="Medium"; Category="Greedy"; Source="NeetCode 150"}
    @{Name="ValidParenthesisString"; Number=678; Difficulty="Medium"; Category="Greedy"; Source="NeetCode 150"}

    # === Intervals ===
    @{Name="InsertInterval"; Number=57; Difficulty="Medium"; Category="Intervals"; Source="NeetCode 150"}
    @{Name="MergeIntervals"; Number=56; Difficulty="Medium"; Category="Intervals"; Source="NeetCode 150"}
    @{Name="NonOverlappingIntervals"; Number=435; Difficulty="Medium"; Category="Intervals"; Source="NeetCode 150"}
    @{Name="MeetingRooms"; Number=252; Difficulty="Easy"; Category="Intervals"; Source="NeetCode 150"}
    @{Name="MeetingRoomsII"; Number=253; Difficulty="Medium"; Category="Intervals"; Source="NeetCode 150"}
    @{Name="MinimumIntervalToIncludeEachQuery"; Number=1851; Difficulty="Hard"; Category="Intervals"; Source="NeetCode 150"}

    # === Math & Geometry ===
    @{Name="RotateImage"; Number=48; Difficulty="Medium"; Category="Math & Geometry"; Source="NeetCode 150"}
    @{Name="SpiralMatrix"; Number=54; Difficulty="Medium"; Category="Math & Geometry"; Source="NeetCode 150"}
    @{Name="SetMatrixZeroes"; Number=73; Difficulty="Medium"; Category="Math & Geometry"; Source="NeetCode 150"}
    @{Name="HappyNumber"; Number=202; Difficulty="Easy"; Category="Math & Geometry"; Source="NeetCode 150"}
    @{Name="PlusOne"; Number=66; Difficulty="Easy"; Category="Math & Geometry"; Source="NeetCode 150"}
    @{Name="PowXN"; Number=50; Difficulty="Medium"; Category="Math & Geometry"; Source="NeetCode 150"}
    @{Name="MultiplyStrings"; Number=43; Difficulty="Medium"; Category="Math & Geometry"; Source="NeetCode 150"}
    @{Name="DetectSquares"; Number=2013; Difficulty="Medium"; Category="Math & Geometry"; Source="NeetCode 150"}

    # === Bit Manipulation ===
    @{Name="SingleNumber"; Number=136; Difficulty="Easy"; Category="Bit Manipulation"; Source="NeetCode 150"}
    @{Name="NumberOf1Bits"; Number=191; Difficulty="Easy"; Category="Bit Manipulation"; Source="NeetCode 150"}
    @{Name="CountingBits"; Number=338; Difficulty="Easy"; Category="Bit Manipulation"; Source="NeetCode 150"}
    @{Name="ReverseBits"; Number=190; Difficulty="Easy"; Category="Bit Manipulation"; Source="NeetCode 150"}
    @{Name="MissingNumber"; Number=268; Difficulty="Easy"; Category="Bit Manipulation"; Source="NeetCode 150"}
    @{Name="SumOfTwoIntegers"; Number=371; Difficulty="Medium"; Category="Bit Manipulation"; Source="NeetCode 150"}
    @{Name="ReverseInteger"; Number=7; Difficulty="Medium"; Category="Bit Manipulation"; Source="NeetCode 150"}
)

Write-Host "===== 開始批次 Scaffold NeetCode 150 =====" -ForegroundColor Cyan

$total = $problems.Count
$created = 0
$skipped = 0

foreach ($p in $problems) {
    $name = $p.Name
    $number = $p.Number
    $difficulty = $p.Difficulty
    $category = $p.Category
    $source = $p.Source

    $problemFile = "$problemsDir\$name.cs"
    $testFile = "$testsDir\${name}Tests.cs"

    # 跳過已存在的檔案
    if ((Test-Path $problemFile) -or (Test-Path $testFile)) {
        Write-Host "⏭️  跳過 $name（檔案已存在）" -ForegroundColor Yellow
        $skipped++
        continue
    }

    # 產生問題檔案 - 使用 .NET Regex 正確轉換 CamelCase 為可讀名稱
    $readableName = [regex]::Replace($name, '([a-z])([A-Z])', '$1 $2')
    $readableName = [regex]::Replace($readableName, '([A-Z])([A-Z][a-z])', '$1 $2')

    $problemContent = @"
using System;

namespace LeetCodePractice.Problems;

/// <summary>
/// $readableName
/// 對應 LeetCode：LC $number
/// 來源：$source
/// 難度：$difficulty
/// 分類：$category
/// 
/// TODO: 加入題目描述與範例
/// </summary>
public class $name
{
    // TODO: 實作你的解法
    // public ReturnType Solve(Parameters)
    // {
    //     throw new NotImplementedException();
    // }
}
"@

    Set-Content -Path $problemFile -Value $problemContent

    # 產生測試檔案
    $testContent = @"
using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class ${name}Tests
{
    private readonly $name _solver = new();

    [Fact]
    public void Solve_Example1_ReturnsExpectedResult()
    {
        // TODO: 補上測試案例
        // var result = _solver.Solve(...);
        // Assert.NotNull(result);
    }

    [Fact]
    public void Solve_EmptyInput_HandlesGracefully()
    {
        // TODO: 補上邊界測試
    }

    [Fact]
    public void Solve_LargeInput_DoesNotThrow()
    {
        // TODO: 補上壓力測試
    }
}
"@

    Set-Content -Path $testFile -Value $testContent

    Write-Host "✅ 已建立 $name" -ForegroundColor Green
    $created++
}

Write-Host ""
Write-Host "===== 完成！=====" -ForegroundColor Cyan
Write-Host "新增：$created 題"
Write-Host "跳過（已存在）：$skipped 題"

# 更新問題清單
Write-Host ""
Write-Host "⚠️  請執行 'lc: list' 來重新產生 LeetCodeProblems.md 與更新題目清單" -ForegroundColor Yellow
