# Evolução obrigatória — EV-01: reservas de visitantes

Depois de corrigir os requisitos básicos, implemente a seguinte evolução sem substituir o mecanismo de políticas por condicionais de categoria.

## Regra

Usuários da categoria `Visitante` poderão reservar recursos sob as seguintes condições:

1. duração máxima de 1 hora;
2. somente recursos do tipo `Sala` ou `Projetor`;
3. o recurso precisa estar ativo;
4. todas as regras gerais de conflito e ciclo de vida continuam válidas.

## Restrição de design

A evolução deve ser realizada pela criação de uma implementação de `IPoliticaReserva` denominada `PoliticaReservaVisitante`. O algoritmo de `ServicoReservas.Solicitar` não deve receber `if`, `switch` ou comparação de categoria específica para tratar visitantes.

`CatalogoPoliticasReserva` deve ser capaz de receber e devolver a nova política sem alteração estrutural do serviço.

## Artefatos

Antes de considerar EV-01 concluída, preencha `ESPECIFICACAO-EVOLUCAO.md`, atualize `MODELO-FINAL.md`, `RASTREABILIDADE.csv` e gere `ALTERACAO-FINAL.diff` ao final do trabalho.
