# 修復巢狀 summary 並從 LeetCode API 抓取完整題目描述
# 執行方式: .\.agents\skills\leetcode-helper\scripts\fix-nested-summary.ps1

$rootDir = Resolve-Path "$PSScriptRoot\..\..\..\.."
$problemsDir = "$rootDir\LeetCodePractice\Problems"

# 先取得所有題目的 stat 對應表
Write-Host "取得 LeetCode 題目 metadata..." -ForegroundColor Cyan
$allStats = Invoke-RestMethod -Uri "https://leetcode.com/api/problems/all/" -Method Get
$statMap = @{}
foreach ($s in $allStats.stat_status_pairs) {
    $statMap[$s.stat.frontend_question_id.ToString()] = @{
        Slug = $s.stat.question__title_slug
        Title = $s.stat.question__title
    }
}
Write-Host "已取得 $($statMap.Count) 題 metadata"

# 掃描所有批次檔案
$files = Get-ChildItem "$problemsDir\*.cs" | Where-Object {
    $_.Name -notin @('CommandParser.cs','DeviceParameterCache.cs','ProblemTemplate.cs','TwoSum.cs','WaferScanOptimizer.cs','LcTaskScheduler.cs')
}

$updated = 0
$skipped = 0
$errors = @()

foreach ($f in $files) {
    $content = Get-Content $f.FullName -Raw
    $className = $f.BaseName

    # 提取 LC 編號
    if ($content -match 'LC (\d+)') {
        $lcNum = [int]$matches[1]
    } else {
        $skipped++; continue
    }

    $key = $lcNum.ToString()
    if (-not $statMap.ContainsKey($key)) {
        $errors += "$($f.Name): LC $lcNum not found"
        $skipped++; continue
    }

    $slug = $statMap[$key].Slug
    $title = $statMap[$key].Title

    Write-Host "正在抓取 $title (LC $lcNum)..." -ForegroundColor Gray

    try {
        # 抓取完整題目描述
        $gqlBody = @{
            query = "query questionData(`$titleSlug: String!) { question(titleSlug: `$titleSlug) { title difficulty content } }"
            variables = @{titleSlug = $slug} | ConvertTo-Json
        } | ConvertTo-Json -Depth 3

        $gqlResult = Invoke-RestMethod -Uri "https://leetcode.com/graphql" -Method Post -Body $gqlBody -ContentType "application/json"
        $q = $gqlResult.data.question

        # 將 HTML 內容轉換為純文字註解
        $desc = $q.content
        $desc = $desc -replace '</?p[^>]*>', "`n"
        $desc = $desc -replace '</?ul[^>]*>', "`n"
        $desc = $desc -replace '<li[^>]*>', "  - "
        $desc = $desc -replace '</li>', "`n"
        $desc = $desc -replace '</?pre[^>]*>', "`n"
        $desc = $desc -replace '</?strong[^>]*>', ''
        $desc = $desc -replace '</?code[^>]*>', '`'
        $desc = $desc -replace '<img[^>]*>', ''
        $desc = $desc -replace '</?a[^>]*>', ''
        $desc = $desc -replace '<br\s*/?>', "`n"
        $desc = $desc -replace '<[^>]+>', ''
        $desc = [System.Web.HttpUtility]::HtmlDecode($desc)
        $desc = $desc -replace "`n`n`n*", "`n`n"
        $desc = $desc.Trim()

        # 將描述每行加上 ///
        $indentedDesc = ($desc -split "`n" | ForEach-Object { "/// $_" }) -join "`n"

        # 建構新的 summary 區塊
        $difficulty = $q.difficulty
        $newSummary = @"
/// <summary>
/// $title
/// 對應 LeetCode：LC $lcNum
/// 來源：NeetCode 150
/// 難度：$difficulty
///
$indentedDesc
/// </summary>
"@

        # 用類別/結構/列舉宣告之前的所有內容替換為新的 summary
        # 先清理可能殘留的 HTML 字元
        $cleanContent = $content -replace '[pP]public\s+(class|struct|enum)\s', 'public $1 '
        if ($cleanContent -match '(?s)(public\s+(class|struct|enum)\s)') {
            $afterClassStart = $cleanContent -replace '(?s).*?(?=public\s+(class|struct|enum)\s)', ''
            $newContent = $newSummary + "`n" + $afterClassStart
            Set-Content $f.FullName $newContent
            Write-Host "  $title 更新完成" -ForegroundColor Green
            $updated++
        } else {
            $errors += "$($f.Name): cannot find class declaration"
            $skipped++
        }
    }
    catch {
        $errors += "$($f.Name): $_"
        $skipped++
    }

    Start-Sleep -Milliseconds 300
}

Write-Host ""
Write-Host "===== 完成！=====" -ForegroundColor Cyan
Write-Host "更新：$updated 題"
Write-Host "跳過：$skipped 題"
if ($errors.Count -gt 0) {
    Write-Host "錯誤：" -ForegroundColor Red
    $errors | ForEach-Object { Write-Host "  $_" }
}
foreach ($f in $files) {
    $text = Get-Content $f.FullName -Raw
    
    # Match the nested summary pattern
    $pattern = '(?s)(/// <summary>\r?\n)((?:/// .*\r?\n)*)(/// \r?\n)(/// <summary>\r?\n(?:/// .*\r?\n)*/// </summary>\r?\n)(/// </summary>)'
    
    if ($text -match $pattern) {
        $firstLines = $matches[1] + $matches[2]   # "/// <summary>\n/// Title\n/// LC\n/// Source\n/// Difficulty\n/// Category\n"
        $innerBlock = $matches[4]                   # "/// <summary>\n...description...\n/// </summary>\n"
        
        # Remove the inner /// <summary> and /// </summary> tags, keep only the content
        $innerContent = $innerBlock -replace '/// <summary>\r?\n', '' -replace '/// </summary>\r?\n?$', ''
        
        # Combine: first lines (with opening summary tag) + inner content + closing summary tag
        $fixedBlock = $firstLines + $innerContent + "/// </summary>"
        
        $text = $text -replace [regex]::Escape($matches[0]), $fixedBlock
        Set-Content $f.FullName -Value $text -NoNewline -Encoding UTF8
        $count++
        Write-Host "  FIXED: $($f.BaseName)"
    }
}

Write-Host "`nFixed $count files."
