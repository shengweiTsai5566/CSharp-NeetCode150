# Course Schedule

## 解題思路
本題等價於判斷有向圖中是否存在環（Cycle Detection），可以使用 **拓撲排序（Topological Sort）** 來解決。

### 方法一：Kahn's Algorithm（BFS）
1. 建立鄰接表（adjacency list）和每個課程的入度（in-degree）陣列。
2. 將所有入度為 0 的課程加入佇列（表示這些課程沒有先修課程）。
3. 依序從佇列取出課程，將其加入已修課程計數，並將其後續課程的入度減一。如果後續課程的入度變為 0，則加入佇列。
4. 最後檢查已修課程計數是否等於 `numCourses`。如果相等，表示可以修完所有課程（無環）；否則表示有環。

### 方法二：DFS
使用 DFS 搭配三種狀態（未訪問、正在訪問、已訪問）來檢測環。

## 時間複雜度
- **時間**: O(V + E) — V 為課程數，E 為先修條件數
- **空間**: O(V + E) — 需要鄰接表儲存圖結構

## 程式碼

```csharp
public class CourseSchedule
{
    public bool Solve(int numCourses, int[][] prerequisites)
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

        int taken = 0;
        while (queue.Count > 0)
        {
            int curr = queue.Dequeue();
            taken++;

            foreach (int next in graph[curr])
            {
                if (--inDegree[next] == 0)
                    queue.Enqueue(next);
            }
        }

        return taken == numCourses;
    }
}
```
