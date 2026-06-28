namespace LeetCodePractice.Problems;

/// <summary>
/// Min Cost to Connect All Points
/// 對應 LeetCode：LC 1584
/// 來源：NeetCode 150
/// 難度：Medium
///
/// You are given an array `points` representing integer coordinates of some points on a 2D-plane, where `points[i] = [xi, yi]`.
/// 
/// The cost of connecting two points `[xi, yi]` and `[xj, yj]` is the manhattan distance between them: `|xi - xj| + |yi - yj|`, where `|val|` denotes the absolute value of `val`.
/// 
/// Return the minimum cost to make all points connected. All points are connected if there is exactly one simple path between any two points.
/// 
///  
/// 
/// Example 1:
/// 
/// Input: points = [[0,0],[2,2],[3,10],[5,2],[7,0]]
/// Output: 20
/// Explanation: 
/// 
/// We can connect the points as shown above to get the minimum cost of 20.
/// Notice that there is a unique path between every pair of points.
/// 
/// Example 2:
/// 
/// Input: points = [[3,12],[-2,5],[-4,1]]
/// Output: 18
/// 
///  
/// 
/// Constraints:
/// 
/// 	  - `1 <= points.length <= 1000`
/// 
/// 	  - `-106 <= xi, yi <= 106`
/// 
/// 	  - All pairs `(xi, yi)` are distinct.
/// 這題在問點和點間連接要怎麼連, 最小成本是多少, 沒有要回答全部的點要怎麼連
/// </summary>
public class MinCostToConnectAllPoints
{

    public static int Solve(int[][] points)
    {
        int n = points.Length;
        if (n <= 1) return 0;

        bool[] boolary = new bool[n];
        boolary[0] = true;

        var pq = new PriorityQueue<(int cost, int point), int>();

        for (int i = 1; i < n; i++)
        {
            var cost = Manhattan(points[0], points[i]);
            pq.Enqueue((cost, i), cost);

        }
        int totalCost = 0;
        while (pq.Count > 0)
        {
            var (cost, point) = pq.Dequeue();
            if (boolary[point]) continue;
            boolary[point] = true;
            totalCost += cost;
            for (int i = 0; i < n; i++)
            {//while裡的迴圈是目前的點, 與所有未跑通的點計算新增到queue中
                if (!boolary[i])
                {
                    int newCost = Manhattan(points[point], points[i]);
                    pq.Enqueue((newCost, i), newCost);
                }
            }
        }

        return totalCost;
    }

    public static int Manhattan(int[] start, int[] end)
    {
        int cost = Math.Abs(start[0] - end[0]) + Math.Abs(start[1] - end[1]);


        return cost;
    }
}



