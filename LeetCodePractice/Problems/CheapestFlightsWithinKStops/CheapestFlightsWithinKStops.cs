namespace LeetCodePractice.Problems;

/// <summary>
/// Cheapest Flights Within K Stops
/// 對應 LeetCode：LC 787
/// 來源：NeetCode 150
/// 難度：Medium
///
/// There are `n` cities connected by some number of flights. You are given an array `flights` where `flights[i] = [fromi, toi, pricei]` indicates that there is a flight from city `fromi` to city `toi` with cost `pricei`.
/// 
/// You are also given three integers `src`, `dst`, and `k`, return the cheapest price from `src` to `dst` with at most `k` stops. If there is no such route, return `-1`.
/// 
///  
/// 
/// Example 1:
/// 
/// Input: n = 4, flights = [[0,1,100],[1,2,100],[2,0,100],[1,3,600],[2,3,200]], src = 0, dst = 3, k = 1
/// Output: 700
/// Explanation:
/// The graph is shown above.
/// The optimal path with at most 1 stop from city 0 to 3 is marked in red and has cost 100 + 600 = 700.
/// Note that the path through cities [0,1,2,3] is cheaper but is invalid because it uses 2 stops.
/// 
/// Example 2:
/// 
/// Input: n = 3, flights = [[0,1,100],[1,2,100],[0,2,500]], src = 0, dst = 2, k = 1
/// Output: 200
/// Explanation:
/// The graph is shown above.
/// The optimal path with at most 1 stop from city 0 to 2 is marked in red and has cost 100 + 100 = 200.
/// 
/// Example 3:
/// 
/// Input: n = 3, flights = [[0,1,100],[1,2,100],[0,2,500]], src = 0, dst = 2, k = 0
/// Output: 500
/// Explanation:
/// The graph is shown above.
/// The optimal path with no stops from city 0 to 2 is marked in red and has cost 500.
/// 
///  
/// 
/// Constraints:
/// 
/// 	  - `2 <= n <= 100`
/// 
/// 	  - `0 <= flights.length <= (n * (n - 1) / 2)`
/// 
/// 	  - `flights[i].length == 3`
/// 
/// 	  - `0 <= fromi, toi < n`
/// 
/// 	  - `fromi != toi`
/// 
/// 	  - `1 <= pricei <= 104`
/// 
/// 	  - There will not be any multiple flights between two cities.
/// 
/// 	  - `0 <= src, dst, k < n`
/// 
/// 	  - `src != dst`
/// </summary>
public class CheapestFlightsWithinKStops
{

    Queue<FlightPlan> flightPlans = new();

    //src 起點城市
    //dst 目的城市
    //k   中轉次數
    //flisghts 航班資訊[起點, 終點, 價格]
    //n 城市總數

    //回傳: 在符合轉站的次數下, 回傳最便宜的方案
    public int Solve(int n, int[][] flights, int src, int dst, int k)
    {
        Dictionary<int, List<(int to, int price)>> graph = new();
        List<(int cost, List<int> path)> results = new();

        for (int i = 0; i < flights.Length; i++)
        {
            int startPoint = flights[i][0];
            int endPoint = flights[i][1];
            int cost = flights[i][2];


            graph.TryAdd(startPoint, new List<(int to, int price)>());
            graph[startPoint].Add((endPoint, cost));


        }
        //var a = graph[0];

        flightPlans.Enqueue(new FlightPlan(src, 0, 0, new List<int> { src }));


        while (flightPlans.Count > 0)
        {
            FlightPlan fp = flightPlans.Dequeue();

            if (fp.city == dst && fp.stops <= k)
                results.Add((fp.cost, fp.path));
            if (fp.stops > k) continue;

            if (!graph.ContainsKey(fp.city)) continue;

            foreach (var nf in graph[fp.city])
            {
                var newPath = new List<int>(fp.path);
                newPath.Add(nf.to);

                if (nf.to != dst && fp.stops < k)
                {
                    flightPlans.Enqueue(new FlightPlan(nf.to, fp.stops + 1, fp.cost + nf.price, newPath));
                }
                else if (nf.to == dst)
                {
                    flightPlans.Enqueue(new FlightPlan(nf.to, fp.stops, fp.cost + nf.price, newPath));
                }
            }

        }

        if (results.Count > 0)
        {
            var cheapest = results.OrderBy(r => r.cost).First();
            return cheapest.cost;
        }

        return -1;

    }




    class FlightPlan
    {
        public int city { get; set; }
        public int stops { get; set; }
        public int cost { get; set; }
        public List<int> path { get; set; }

        public FlightPlan(int city, int stops, int cost, List<int> path)
        {
            this.city = city;
            this.stops = stops;
            this.cost = cost;
            this.path = path;
        }
    }


    public int Bellman_Ford_Solve(int n, int[][] flights, int src, int dst, int k)
    {
        int[] prices = new int[n];
        Array.Fill(prices, int.MaxValue);
        prices[src] = 0;

        for (int i = 0; i <= k; i++)
        {
            int[] temp = (int[])prices.Clone();

            foreach (var flight in flights)
            {
                int from = flight[0], to = flight[1], price = flight[2];

                if (prices[from] != int.MaxValue)
                {
                    int newCost = prices[from] + price;
                    if (newCost < temp[to])
                        temp[to] = newCost;
                }
            }

            prices = temp;
        }

        return prices[dst] == int.MaxValue ? -1 : prices[dst];
    }
}





