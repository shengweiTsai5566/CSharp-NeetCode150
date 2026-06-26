# Command Parser（通訊協定封包狀態解析器）

**對應 LeetCode：** LC 65 Valid Number / LC 8 String to Integer (atoi) 延伸變形

**面試難度：** Medium（狀態機實作題）

---

## 解題思路

### 問題理解
機台與上位機（MES）或下位機（PLC）透過 TCP/IP 傳輸自訂的控制指令。
封包格式：
- 以 `$` 開頭
- 接著 4 位指令碼（僅限大寫英文字母）
- 可選的參數區（由 `,` 分隔的數字）
- 最後以 `;` 結尾

### 為什麼用 State Machine（DFA）？

解析通訊協定最適合使用**有限狀態機（Deterministic Finite Automaton, DFA）**：
- 每個字元觸發一次狀態轉移
- 狀態明確，易於除錯
- 不需要 Regex（在設備控制中 Regex 太昂貴）
- 可使用 `ReadOnlySpan<char>` 避免字串配置

### 狀態設計

```
Idle → HeaderReceived → CommandParsing → [ParamParsing] → Completed
  ↑                                                        |
  └──────────────────── Error ←────────────────────────────┘
```

### 演算法步驟

1. **Idle**：期待 `$`，否則 Error
2. **HeaderReceived**：開始累積 4 位指令碼
3. **CommandParsing**：收集大寫字母指令碼
4. **ParamParsing**：遇到 `,` 進入參數模式，可選負號或數字
5. **AccumulatingNumber**：累積數字，直到 `,` 或 `;`
6. **Completed**：遇到 `;` 成功結束

---

## 時間複雜度

| 操作 | 複雜度 |
|------|--------|
| 解析 | **O(n)** — 逐一字元遍歷 |
| 空間 | **O(1)** — 固定狀態變數 |

## 空間複雜度

- **O(1)** — 僅使用 enum 狀態 + 少數整數變數
- **無記憶體分配** — 使用 `ReadOnlySpan<char>` 直接處理輸入

---

## 完整解答程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public enum CommandStateOrigin
{
    Idle,
    HeaderReceived,
    CommandParsing,
    ParamParsing,
    Completed,
    Error
}

public class CommandParser
{
    public bool IsValidCommand(ReadOnlySpan<char> command)
    {
        if (command.IsEmpty)
            return false;

        CommandStateOrigin state = CommandStateOrigin.Idle;
        int alphaCount = 0;

        for (int i = 0; i < command.Length; i++)
        {
            char c = command[i];

            switch (state)
            {
                case CommandStateOrigin.Idle:
                    if (c == '$')
                        state = CommandStateOrigin.HeaderReceived;
                    else
                        return false;
                    break;

                case CommandStateOrigin.HeaderReceived:
                case CommandStateOrigin.CommandParsing:
                    if (char.IsUpper(c) && alphaCount < 4)
                    {
                        alphaCount++;
                        state = CommandStateOrigin.CommandParsing;
                    }
                    else if (c == ',' && alphaCount > 0)
                    {
                        state = CommandStateOrigin.ParamParsing;
                    }
                    else if (c == ';' && alphaCount > 0)
                    {
                        state = CommandStateOrigin.Completed;
                    }
                    else
                    {
                        return false;
                    }
                    break;

                case CommandStateOrigin.ParamParsing:
                    if (c == '-')
                    {
                        // 負號開頭，下一步必須是數字
                        state = CommandStateOrigin.ParamParsing; // stays in param
                    }
                    else if (char.IsDigit(c))
                    {
                        // 開始累積數字
                        state = CommandStateOrigin.ParamParsing;
                    }
                    else if (c == ',')
                    {
                        // 下一個參數
                        state = CommandStateOrigin.ParamParsing;
                    }
                    else if (c == ';')
                    {
                        state = CommandStateOrigin.Completed;
                    }
                    else
                    {
                        return false;
                    }
                    break;
            }
        }

        return state == CommandStateOrigin.Completed;
    }
}
```

---

## 測試案例重點

| 測試情境 | 輸入 | 預期 |
|---------|------|------|
| 基本合法 | `"$INIT;"` | ✅ |
| 含參數 | `"$MOVE,100,-250;"` | ✅ |
| 缺 `$` | `"MOVE,100;"` | ❌ |
| 非法參數 | `"$INIT,ABC;"` | ❌ |
| 缺分號 | `"$STOP"` | ❌ |
| 空字串 | `""` | ❌ |

---

## 面試重點提示

| 問題 | 你的回答 |
|------|---------|
| 為什麼用 State Machine？ | 可讀性高、易於維護、不需 Regex（效能考量） |
| 為什麼用 `ReadOnlySpan`？ | Zero-allocation，避免 substring 配置，適合高效場景 |
| 如何擴充指令？ | 新增狀態、擴充 switch-case，不影響既有邏輯 |
| 生產環境中如何優化？ | 可用 `State` pattern 搭配 Strategy 模式，避免大型 switch |

> 💡 **面試小提示**：這題在半導體設備商面試中非常常見。重點是展示你對**狀態機設計**與**Zero-allocation**的理解，以及如何在通訊協定解析中平衡可讀性與效能。
