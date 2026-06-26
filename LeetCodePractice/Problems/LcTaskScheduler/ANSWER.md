# Task Scheduler

**LeetCode：** [621. Task Scheduler](https://leetcode.com/problems/task-scheduler/) (Medium)

**NeetCode 150：** 第 63 題

---

## 解題思路

給定一個任務陣列和冷卻時間 `n`，相同任務必須間隔至少 `n` 個時間單位才能再次執行。求完成所有任務所需的最短時間。

### 核心概念

#### 數學推導法（最優解）

關鍵在於出現次數最多的任務（設為 `maxFreq`，且該頻率的任務有 `maxCount` 個）。

想像將這些任務作為框架，在它們之間插入其他任務或空閒時間：

```
框架結構（以 maxFreq = 3, n = 2, maxCount = 2 為例）：
A B _   A B _   A B
```

- 每個區塊長度為 `n + 1`（任務 + 冷卻時間）。
- 總共需要 `(maxFreq - 1)` 個完整區塊。
- 最後加上 `maxCount` 個最高頻率的任務。

**公式：** `total = (maxFreq - 1) * (n + 1) + maxCount`

最後與 `tasks.Length` 取最大值（如果沒有閒置時間，則直接回傳任務總數）。

#### 另一種理解

- 將 `maxFreq` 的任務作為分隔點，在它們之間有 `(maxFreq - 1)` 個間隔。
- 每個間隔長度為 `n`，可用來安排其他任務。
- 如果其他任務數量不足，就需要補上閒置時間。

### 時間/空間複雜度

- **時間複雜度：** O(N)，只需遍歷任務一次計算頻率。
- **空間複雜度：** O(1)，固定大小 26 的陣列。

---

## 完整 C# 解答（數學推導法）

```csharp
using System;
using System.Linq;

public class LcTaskScheduler
{
    public int Solve(char[] tasks, int n)
    {
        // 1. 計算每個任務的出現次數
        int[] freq = new int[26];
        foreach (char task in tasks)
        {
            freq[task - 'A']++;
        }

        // 2. 找出最高頻率與其數量
        int maxFreq = freq.Max();
        int maxCount = freq.Count(f => f == maxFreq);

        // 3. 計算最短所需時間
        int result = (maxFreq - 1) * (n + 1) + maxCount;

        // 4. 若無閒置則直接回傳任務總數
        return Math.Max(result, tasks.Length);
    }
}
```

---

## 完整 C# 解答（Max-Heap 模擬法）

```csharp
using System.Collections.Generic;

public class LcTaskSchedulerHeap
{
    public int Solve(char[] tasks, int n)
    {
        // 1. 計算頻率
        int[] freq = new int[26];
        foreach (char task in tasks)
        {
            freq[task - 'A']++;
        }

        // 2. 建立 Max-Heap
        var maxHeap = new PriorityQueue<int, int>();
        foreach (int f in freq)
        {
            if (f > 0)
                maxHeap.Enqueue(f, -f);
        }

        int time = 0;

        // 3. 模擬任務排程
        while (maxHeap.Count > 0)
        {
            int cycle = n + 1;
            var temp = new List<int>();

            for (int i = 0; i < cycle; i++)
            {
                if (maxHeap.Count > 0)
                {
                    int count = maxHeap.Dequeue();
                    if (count > 1)
                    {
                        temp.Add(count - 1);
                    }
                }
                time++;

                if (maxHeap.Count == 0 && temp.Count == 0)
                    break;
            }

            foreach (int count in temp)
            {
                maxHeap.Enqueue(count, -count);
            }
        }

        return time;
    }
}
```

---

## 重點提醒

- **數學推導法**是 O(N) 最優解，面試中建議優先使用。
- **Heap 模擬法**更直觀但時間複雜度較高（O(N × n)），適合用來理解過程。
- 題目中的 `n` 是**冷卻間隔**，即相同任務之間至少要有 `n` 個不同任務或閒置時間。
