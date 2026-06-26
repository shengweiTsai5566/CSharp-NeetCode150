# Course Schedule II

## 解題思路
與 Course Schedule（LC 207）類似，使用 **拓撲排序（Kahn's Algorithm）**，但除了判斷是否有環之外，還需要回傳具體的修課順序。

1. 建立鄰接表（adjacency list）和每個課程的入度（in-degree）陣列。
2. 將所有入度為 0 的課程加入佇列。
3. 依序從佇列取出課程，加入結果陣列，並將其後續課程的入度減一；若後續課程入度變為 0，則加入佇列。
4. 最後檢查結果陣列的長度是否等於 `numCourses`。如果相等，回傳結果陣列（即拓撲排序順序）；否則回傳空陣列（表示有環，無法完成所有課程）。

## 時間複雜度
- **時間**: O(V + E) — V 為課程數，E 為先修條件數
- **空間**: O(V + E) — 需要鄰接表儲存圖結構

## 程式碼

```csharp
public class CourseScheduleII
{
    public int[] Solve(int numCourses, int[][] prerequisites)
    {
        var graph = new List<int>[numCourses];
        var inDegree = new int[numCourses];

        for (int i = 0; i < numCourses; i++)
            graph[i] = new List<int>();

        foreach (var pre in prerequisites)
        {
            int course = pre[0], prereq = pre[1];
            graph[prereq].Add(course);
            inDegree[course]++;
        }

        var queue = new Queue<int>();
        for (int i = 0; i < numCourses; i++)
        {
            if (inDegree[i] == 0)
                queue.Enqueue(i);
        }

        var result = new List<int>();
        while (queue.Count > 0)
        {
            int curr = queue.Dequeue();
            result.Add(curr);

            foreach (int next in graph[curr])
            {
                if (--inDegree[next] == 0)
                    queue.Enqueue(next);
            }
        }

        return result.Count == numCourses ? result.ToArray() : Array.Empty<int>();
    }
}
```
