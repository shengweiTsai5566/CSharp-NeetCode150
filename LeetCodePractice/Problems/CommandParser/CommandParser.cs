using System;

namespace LeetCodePractice.Problems;

/// <summary>
/// Command Parser
/// 對應 LeetCode：LC 65 Valid Number / LC 8 String to Integer (atoi) 延伸變形
/// 
/// 面試情境：
/// 機台與上位機（MES）或下位機（PLC）透過 TCP/IP 傳輸自訂的控制指令。
/// 封包格式要求：
/// - 以 $ 開頭
/// - 接著 4 位指令碼（僅限大寫英文字母）
/// - 可選的參數區（由 , 分隔的數字）
/// - 最後以 ; 結尾
/// 任何非法格式都必須立刻觸發錯誤狀態。
/// 
/// 合法範例：
/// - "$INIT;"
/// - "$MOVE,100,-250;"
/// 
/// 非法範例：
/// - "MOVE,100;" （缺 $）
/// - "$INIT,ABC;" （參數非數字）
/// - "$STOP" （缺分號）
/// </summary>
public enum CommandState
{
    Idle,
    HeaderReceived,
    CommandParsing,
    ExpectValue,
    AccumulatingNumber,
    Completed,
    Error
}

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
    /// <summary>
    /// 判斷給定的字串命令是否為合法的設備控制封包。
    /// 使用狀態機（DFA）來驗證格式。
    /// 
    /// 不使用複雜的巢狀 if-else 或 Regex，而是用 enum 狀態與 switch-case 實作清晰的狀態轉移。
    /// 對於大量數據處理，使用 ReadOnlySpan<char> 以避免記憶體分配。
    /// </summary>
    public bool IsValidCommandV1(ReadOnlySpan<char> command)
    {
        // TODO: 實作狀態機邏輯
        // 1. 初始化 currentState = CommandState.Idle
        // 2. 逐字符遍歷 command
        // 3. 根據當前狀態與字符進行狀態轉移
        // 4. 在每個狀態下檢驗輸入的有效性
        // 5. 最後返回 currentState == CommandState.Completed
        // 6. 逗號前只能接受數字, 逗號後只能接受負號或數字
        // 7. 負號前只能接受逗號,負號後只能接受數字
        // 8. 分號前只能接受數字和無參數指令
        if(command.IsEmpty){
            return false;
        }
        if(command[command.Length-1]!=';'){
            return false;
        }

        CommandStateOrigin currentState = CommandStateOrigin.Idle;
        int alpha = 0;
        bool paramStart = false;
        bool inNumber = false;
        bool isSignPending = false;
        bool paramChangeStatus = false;
        for (int i = 0; i < command.Length; i++)
        {
            char c = command[i];

            
            switch (currentState)
            {
                case CommandStateOrigin.Idle:
                    if (c == '$')
                    {
                        currentState = CommandStateOrigin.HeaderReceived;
                    }
                    else
                    {
                        return false;
                    }

                    break;
                case CommandStateOrigin.HeaderReceived:
                case CommandStateOrigin.CommandParsing:

                    if (Char.IsUpper(c) && alpha <= 4)
                    {
                        currentState = CommandStateOrigin.CommandParsing;
                        alpha += 1;
                    }
                    else
                    {
                        return false;
                    }

                    if (alpha == 4)
                    {
                        currentState = CommandStateOrigin.ParamParsing;
                    }


                    break;
                case CommandStateOrigin.ParamParsing:

                 //judge status
                   if(c==',' && isSignPending && inNumber==false) {
                    currentState = CommandStateOrigin.Error;
                    return false;
                    }
                   if(c==',' && paramStart)
                    {
                        currentState = CommandStateOrigin.Error;
                        return false;

                    }
                   //process  state
                   if(c==',') {paramStart = true; paramChangeStatus = true;}
                   if(c=='-') {isSignPending = true; paramChangeStatus = true;}
                   if(char.IsDigit(c)) {inNumber = true; paramChangeStatus = true;}

                  // process control 
                    if(paramStart && isSignPending && inNumber==false)
                    {
                        paramStart = false;

                    } 
                    if(paramStart && inNumber) {
                        
                        paramStart = false;
                        isSignPending = false;
                    }
                    if(c==',' && inNumber) {
                        paramStart = true;
                        isSignPending = false;
                        inNumber = false;
                    }
                    if(c==';'&& inNumber) {
                        currentState = CommandStateOrigin.Completed;
                        return true;
                    }
                    else if(c==';' && paramChangeStatus==false)
                    {
                        currentState = CommandStateOrigin.Completed;
                        return true;
                    }


                    break;

                case CommandStateOrigin.Error:
                    Console.WriteLine("Command Error");
                    return false;
                case CommandStateOrigin.Completed:
                    Console.WriteLine("Completed");
                    return true;
                default:
                    break;


            }
        }


        return false;
    }

     public bool IsValidCommand(ReadOnlySpan<char> command)
    {
        if(command.IsEmpty){
            return false;
        }

        if(command[command.Length-1]!=';'){
            return false;
        }
        CommandState currentState = CommandState.Idle;
        int alphaCount = 0;

        bool valueUpdated = true;
        for (int i = 0; i < command.Length; i++)
        {
            char c = command[i];
            switch (currentState)
            {
                case CommandState.Idle:
                    if (c == '$')
                    {
                        currentState = CommandState.HeaderReceived;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case CommandState.HeaderReceived:
                case CommandState.CommandParsing:
                    if(char.IsUpper(c))
                    {
                        if(alphaCount>=4)
                        {
                            return false;
                        }
                        currentState = CommandState.CommandParsing;
                        alphaCount++;
                    }
                    else if(alphaCount == 4 && c == ',')
                    {
                        currentState = CommandState.ExpectValue;
                    }
                    else if(alphaCount == 4 && c == ';')
                    {
                        currentState = CommandState.Completed;
                        return true;
                    }
                    else 
                    {
                        return false;
                    }

                    break;
                case CommandState.ExpectValue:
                    if(c == '-' )
                    {
                        currentState = CommandState.AccumulatingNumber;
                        valueUpdated = false;
                    }else if(char.IsDigit(c)){
                        currentState = CommandState.AccumulatingNumber;
                        valueUpdated = true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case CommandState.AccumulatingNumber:
                   
                    if(char.IsDigit(c))
                    {
                        valueUpdated=true;
                    }
                    else if(c == ',')
                    {   if(valueUpdated==false)
                        {
                            currentState = CommandState.Error;
                            return false;
                        }
                        currentState = CommandState.ExpectValue;
                    }
                    else if(c == ';')
                    {
                        if(valueUpdated==false)
                        {
                            currentState = CommandState.Error;
                            return false;
                        }
                        currentState = CommandState.Completed;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case CommandState.Completed:
                    return true;
                    
                case CommandState.Error:
                    return false;
                    
                default:
                    break;
            }
           

        }

        return false;


    }
}

