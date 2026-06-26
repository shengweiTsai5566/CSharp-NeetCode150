using LeetCodePractice.Problems;

Console.WriteLine("LeetCodePractice Program 主程式 - CommandParser 直接測試入口");
Console.WriteLine("輸入命令後按 Enter，空行則結束。");
Console.WriteLine();

var parser = new CommandParser();

while (true)
{
    Console.Write("請輸入指令: ");
    string? input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input))
    {
        break;
    }

    bool valid = parser.IsValidCommand(input.AsSpan());
    Console.WriteLine(valid ? "合法命令" : "非法命令");
    Console.WriteLine();
}

Console.WriteLine("已結束。" );
