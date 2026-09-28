# RRP — Sistema de Reservas de Recursos Acadêmicos

Este repositório é o projeto-base do trabalho prático individual de recuperação em Design e Programação Orientada a Objetos.

O sistema já compila e possui uma implementação inicial. Essa implementação é deliberadamente incompleta: existem violações de encapsulamento, regras de negócio ausentes, uma verificação de conflito incorreta, decisões de responsabilidade inadequadas e uma estratégia de variação que ainda precisa ser transformada em uma solução polimórfica.

## O que deve ser feito

1. Leia `docs/ENUNCIADO.md` integralmente.
2. Leia `docs/REQUISITOS.md` e use os IDs R01–R25 como contrato de entrega.
3. Execute o build e os testes públicos antes de alterar o código.
4. Corrija e evolua o projeto sem substituir toda a base por outro sistema.
5. Implemente a evolução descrita em `docs/EVOLUCAO.md`.
6. Complete todos os artefatos da pasta `docs`.
7. Execute build e testes novamente.
8. Gere `docs/ALTERACAO-FINAL.diff`.
9. Siga exatamente `docs/ENTREGA.md`.

## Comandos principais

```bash
dotnet restore
dotnet build RrpReservas.sln
dotnet test tests/Reservas.Tests/Reservas.Tests.csproj
dotnet run --project src/Reservas.Console/Reservas.Console.csproj
```

## Importante

Os testes fornecidos ao estudante não representam todos os casos que serão verificados. A correção utilizará casos adicionais, incluindo fronteiras de período, transições de estado, substituição de políticas e inspeções estruturais.
