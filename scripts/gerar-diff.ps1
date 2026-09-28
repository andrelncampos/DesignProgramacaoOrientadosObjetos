$ErrorActionPreference = "Stop"
$raiz = Resolve-Path "$PSScriptRoot/.."
Push-Location $raiz
try {
    git diff BASELINE-RRP..HEAD | Out-File -Encoding utf8 "docs/ALTERACAO-FINAL.diff"
    Write-Host "Gerado: docs/ALTERACAO-FINAL.diff"
}
finally {
    Pop-Location
}
