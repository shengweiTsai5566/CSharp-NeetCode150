# 將每個 LeetCode 問題移到對應的資料夾，並建立 ANSWER.md
# 執行: .\.agents\skills\leetcode-helper\scripts\reorganize-to-folders.ps1

$rootDir = Resolve-Path "$PSScriptRoot\..\..\..\.."
$problemsDir = "$rootDir\LeetCodePractice\Problems"
$testsDir = "$rootDir\LeetCodePractice.Tests"

# 要排除的通用檔案（不屬於特定題目）
$excludeFiles = @('ProblemTemplate.cs', 'ListNode.cs', 'TreeNode.cs', 'Node.cs')

# 問題檔案清單（不包含通用檔案）
$problemFiles = Get-ChildItem "$problemsDir\*.cs" | Where-Object { $_.Name -notin $excludeFiles }

$count = 0
foreach ($f in $problemFiles) {
    $name = $f.BaseName  # e.g., "AddTwoNumbers"
    $targetDir = "$problemsDir\$name"
    
    # 建立題目資料夾
    if (-not (Test-Path $targetDir)) {
        New-Item -ItemType Directory -Path $targetDir -Force | Out-Null
    }
    
    # 移動 .cs 檔案
    $destFile = "$targetDir\$($f.Name)"
    if (-not (Test-Path $destFile)) {
        Move-Item -Path $f.FullName -Destination $destFile -Force
    }
    
    # 移動對應的測試檔案
    $testFile = "$testsDir\${name}Tests.cs"
    $testDir = "$testsDir\$name"
    if (Test-Path $testFile) {
        if (-not (Test-Path $testDir)) {
            New-Item -ItemType Directory -Path $testDir -Force | Out-Null
        }
        $destTest = "$testDir\${name}Tests.cs"
        if (-not (Test-Path $destTest)) {
            Move-Item -Path $testFile -Destination $destTest -Force
        }
    }
    
    $count++
    Write-Host "📦 $name" -ForegroundColor Gray
}

Write-Host ""
Write-Host "===== 已完成 =====" -ForegroundColor Cyan
Write-Host "已移動 $count 個問題到各別資料夾"
Write-Host ""
Write-Host "⚠️  通用檔案保留在原目錄：" -ForegroundColor Yellow
$excludeFiles | ForEach-Object { Write-Host "   - $problemsDir\$_" }
