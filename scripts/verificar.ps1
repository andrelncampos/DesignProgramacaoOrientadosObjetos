$ErrorActionPreference = "Stop"
Write-Host "== Build =="
dotnet build "$PSScriptRoot/../RrpReservas.sln"
Write-Host "`n== Testes públicos =="
dotnet test "$PSScriptRoot/../tests/Reservas.Tests/Reservas.Tests.csproj" --no-build
Write-Host "`n== Execução do console =="
dotnet run --project "$PSScriptRoot/../src/Reservas.Console/Reservas.Console.csproj" --no-build
