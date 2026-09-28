# Instruções de entrega

## Estrutura obrigatória

Entregue um único arquivo ZIP contendo a raiz do projeto, com esta estrutura mínima:

```text
RrpReservas.sln
README.md
docs/
src/
tests/Reservas.Tests/
```

Não inclua `bin`, `obj`, `.vs` ou `TestResults`.

## Antes de compactar

Execute:

```bash
dotnet build RrpReservas.sln
dotnet test tests/Reservas.Tests/Reservas.Tests.csproj
```

Gere o diff final a partir da tag inicial:

```bash
git diff BASELINE-RRP..HEAD > docs/ALTERACAO-FINAL.diff
```

Se você não tiver criado commits durante o trabalho, faça ao menos um commit final antes do comando acima.

## Nome do arquivo

Use o padrão definido pelo professor no Plano de Estudos/RRP.
