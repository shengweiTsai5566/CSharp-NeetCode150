# Path Planner（電子束掃描路徑生成）

**對應 LeetCode：** LC 59 Spiral Matrix II (Medium)

**實務情境：** E-beam 或微步進馬達的螺旋路徑規劃

---

## 解題思路

### 問題理解
生成一個 $n \times n$ 矩陣，從左上角開始以順時針螺旋填入 $1$ 到 $n^2$。

### 演算法：四邊界法

1. 定義 `top`, `bottom`, `left`, `right` 四個邊界指標
2. 按照 **右 → 下 → 左 → 上** 的順序遍歷
3. 每次走完一條邊後縮減對應邊界
4. 當 `top > bottom` 或 `left > right` 時結束

```
n = 3:
→→→  (top)    [1,2,3]
↓ ↗ ↑  →  [8,9,4]
←←←  (bottom) [7,6,5]
```

---

## 時間複雜度
- **時間**: **O(n²)** — 需要填入 $n^2$ 個元素
- **空間**: **O(1)** — 除回傳矩陣外無額外空間

---

## 完整解答程式碼

```csharp
public class PathPlanner
{
    public int[,] GenerateSpiralPath(int n)
    {
        int[,] path = new int[n, n];
        int top = 0, bottom = n - 1;
        int left = 0, right = n - 1;
        int num = 1;

        while (top <= bottom && left <= right)
        {
            // 向右
            for (int i = left; i <= right; i++)
                path[top, i] = num++;
            top++;

            // 向下
            for (int i = top; i <= bottom; i++)
                path[i, right] = num++;
            right--;

            // 向左
            if (top <= bottom)
            {
                for (int i = right; i >= left; i--)
                    path[bottom, i] = num++;
                bottom--;
            }

            // 向上
            if (left <= right)
            {
                for (int i = bottom; i >= top; i--)
                    path[i, left] = num++;
                left++;
            }
        }

        return path;
    }
}
```

---

## 擴充思考（面試加分）

### OCP 原則 — 加入方向參數

```csharp
public enum SpiralDirection { Clockwise, CounterClockwise, CenterOut }

public int[,] GenerateSpiralPath(int n, SpiralDirection dir = SpiralDirection.Clockwise)
{
    // 根據 dir 參數調整遍歷順序
    // Clockwise: 右→下→左→上
    // CounterClockwise: 下→右→上→左
    // CenterOut: 從中心開始向外螺旋
}
```

> 💡 **面試小提示**：這題的核心是**邊界控制**。展示你能寫出整潔的邊界條件，並主動提出 OCP 擴充方案，會讓面試官印象深刻。
