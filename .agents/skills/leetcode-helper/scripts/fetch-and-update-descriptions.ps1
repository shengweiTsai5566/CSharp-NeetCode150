# 批次從 LeetCode API 抓取題目描述並更新所有問題檔案
# 執行方式: .\.agents\skills\leetcode-helper\scripts\fetch-and-update-descriptions.ps1

$rootDir = Resolve-Path "$PSScriptRoot\..\..\..\.."
$problemsDir = "$rootDir\LeetCodePractice\Problems"

Write-Host "===== 取得所有 LeetCode 題目標題對應 =====" -ForegroundColor Cyan

# 步驟 1: 從 LeetCode API 取得所有題目的 stat 資料
$allStats = Invoke-RestMethod -Uri "https://leetcode.com/api/problems/all/" -Method Get
$statMap = @{}
foreach ($s in $allStats.stat_status_pairs) {
    $num = $s.stat.frontend_question_id
    $slug = $s.stat.question__title_slug
    $title = $s.stat.question__title
    $statMap[$num] = @{Slug = $slug; Title = $title}
}
Write-Host "✅ 已取得 $($statMap.Count) 題 metadata"

# 步驟 2: 掃描問題檔案，找出需要更新的
$files = Get-ChildItem $problemsDir/*.cs | Where-Object {
    $_.Name -notin @('CommandParser.cs','DeviceParameterCache.cs','ProblemTemplate.cs','TwoSum.cs','WaferScanOptimizer.cs','LcTaskScheduler.cs')
}

$updated = 0
$skipped = 0
$errors = @()

foreach ($f in $files) {
    $content = Get-Content $f.FullName -Raw
    $className = $f.BaseName

    # 從內容中提取 LC 編號
    if ($content -match 'LC (\d+)') {
        $lcNum = [int]$matches[1]
    } else {
        Write-Host "⏭️  跳過 $($f.Name)（無 LC 編號）" -ForegroundColor Yellow
        $skipped++
        continue
    }

    # 檢查是否已有完整描述（非 TODO）
    if ($content -notmatch 'TODO: 加入題目描述') {
        Write-Host "⏭️  跳過 $($f.Name)（已有描述）" -ForegroundColor Yellow
        $skipped++
        continue
    }

    # 從 statMap 取得 slug
    if (-not $statMap.ContainsKey($lcNum)) {
        Write-Host "⚠️  找不到 LC $lcNum 的 slug" -ForegroundColor Red
        $errors += "$($f.Name): LC $lcNum not found"
        $skipped++
        continue
    }

    $slug = $statMap[$lcNum].Slug
    $title = $statMap[$lcNum].Title

    Write-Host "📥 正在抓取 $title (LC $lcNum)..." -ForegroundColor Gray

    # 步驟 3: 透過 GraphQL API 取得題目詳細內容
    try {
        $gqlBody = @{
            query = "query questionData(`$titleSlug: String!) { question(titleSlug: `$titleSlug) { title difficulty content } }"
            variables = @{titleSlug = $slug} | ConvertTo-Json
        } | ConvertTo-Json -Depth 3

        $gqlResult = Invoke-RestMethod -Uri "https://leetcode.com/graphql" -Method Post -Body $gqlBody -ContentType "application/json"

        $q = $gqlResult.data.question
        $difficulty = $q.difficulty
        $htmlContent = $q.content

        # 步驟 4: 將 HTML 轉換為純文字註解格式
        $description = Convert-HtmlToComment -html $htmlContent -indent "/// "
        $difficultyTag = $difficulty -eq "Easy" ? "Easy" : ($difficulty -eq "Medium" ? "Medium" : "Hard")

        # 步驟 5: 更新檔案
        $newSummary = @"
/// <summary>
/// $title
/// 對應 LeetCode：LC $lcNum
/// 來源：NeetCode 150
/// 難度：$difficultyTag
/// 分類：$($(Get-Content $f.FullName | Select-String '分類：(.+)').Matches.Groups[1].Value.Trim())
/// 
$description/// </summary>
"@

        # 取代原本的 summary 區塊
        $newContent = $content -replace '(?s)/// <summary>.*?/// </summary>', $newSummary.TrimEnd()
        Set-Content $f.FullName $newContent
        Write-Host "✅ $title 更新完成" -ForegroundColor Green
        $updated++
    }
    catch {
        Write-Host "❌ 抓取 $title 失敗: $_" -ForegroundColor Red
        $errors += "$($f.Name): $_"
        $skipped++
    }

    # 避免 API 限流
    Start-Sleep -Milliseconds 300
}

function Convert-HtmlToComment {
    param([string]$html, [string]$indent)

    # 移除 HTML 標籤但保留結構
    $text = $html
    
    # 將 <p>、<br>、</li>、</ul> 等轉換為換行
    $text = $text -replace '</p>', "`n"
    $text = $text -replace '<br\s*/?>', "`n"
    $text = $text -replace '</li>', "`n"
    $text = $text -replace '</ul>', "`n"
    $text = $text -replace '</ol>', "`n"
    $text = $text -replace '</pre>', "`n"
    $text = $text -replace '</strong>', ''
    $text = $text -replace '<strong[^>]*>', ''
    $text = $text -replace '</code>', ''
    $text = $text -replace '<code[^>]*>', ''
    $text = $text -replace '</em>', ''
    $text = $text -replace '<em[^>]*>', ''
    $text = $text -replace '<img[^>]*>', ''
    $text = $text -replace '<a[^>]*>', ''
    $text = $text -replace '</a>', ''
    $text = $text -replace '<ul[^>]*>', ''
    $text = $text -replace '<ol[^>]*>', ''
    $text = $text -replace '<li[^>]*>', '  - '
    $text = $text -replace '<pre[^>]*>', ''
    $text = $text -replace '<p[^>]*>', ''
    $text = $text -replace '<[^>]+>', ''
    
    # 解碼 HTML entities
    $text = [System.Web.HttpUtility]::HtmlDecode($text)
    
    # 清理多餘空行
    $text = $text -replace "`n`n`n*", "`n`n"
    
    # 每行加上 indent
    $lines = $text -split "`n"
    $result = ($lines | ForEach-Object { if ($_.Trim() -ne '') { "$indent$_" } else { $indent } }) -join "`n"
    
    return $result + "`n"
}

Write-Host ""
Write-Host "===== 完成！=====" -ForegroundColor Cyan
Write-Host "✅ 更新：$updated 題"
Write-Host "⏭️  跳過：$skipped 題"
if ($errors.Count -gt 0) {
    Write-Host "❌ 錯誤：" -ForegroundColor Red
    $errors | ForEach-Object { Write-Host "  $_" -ForegroundColor Red }
}
