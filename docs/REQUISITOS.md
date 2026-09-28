# Requisitos do Trabalho Prático — RRP POO

## Regra de correção

Cada requisito possui um identificador fixo e uma pontuação. A solução será avaliada por build, testes públicos, testes adicionais mantidos pelo professor, inspeções estruturais objetivas e conferência dos artefatos obrigatórios. Não há pontuação por estética, quantidade de classes ou extensão de texto.

| ID | Requisito verificável | Pontos | Verificação principal |
|---|---|---:|---|
| R01 | A solução completa deve compilar sem erros em .NET 10. | 2 | `dotnet build RrpReservas.sln` |
| R02 | `Usuario` deve rejeitar `Guid.Empty` e nome vazio; `Id` e `Nome` não podem possuir setter público. | 2 | testes + reflexão |
| R03 | `Recurso` deve rejeitar dados básicos inválidos; `Id` não pode possuir setter público e `EstaAtivo` só pode mudar por `Ativar()`/`Desativar()`. | 2 | testes + reflexão |
| R04 | `PeriodoReserva` deve exigir `Inicio < Fim`; as propriedades devem ser somente leitura externa. | 3 | testes públicos/ocultos |
| R05 | `ConflitaCom` deve detectar todas as formas de sobreposição e considerar períodos apenas adjacentes como não conflitantes. | 3 | testes de fronteira |
| R06 | `Reserva` deve exigir os objetos necessários na construção, começar em `Solicitada` e não expor setters públicos para `Usuario`, `Recurso`, `Periodo` e `Status`. | 2 | testes + reflexão |
| R07 | Devem funcionar as transições válidas: `Solicitada -> Confirmada`, `Solicitada -> Cancelada`, `Confirmada -> Cancelada` e `Confirmada -> Concluida`. | 3 | testes |
| R08 | Qualquer transição não prevista em R07 deve lançar `TransicaoDeReservaInvalidaException`. | 3 | testes |
| R09 | A coleção interna da agenda não pode ser modificada externamente. | 2 | teste estrutural/comportamental |
| R10 | Uma nova reserva deve ser rejeitada com `ConflitoDeReservaException` quando houver sobreposição com reserva `Solicitada` ou `Confirmada` do mesmo recurso. | 4 | testes públicos/ocultos |
| R11 | Reservas `Cancelada` ou `Concluida` não devem bloquear a agenda; períodos adjacentes são permitidos. | 2 | testes de fronteira |
| R12 | Recurso inativo não pode receber nova reserva. | 2 | testes |
| R13 | A alteração do estado da reserva deve ocorrer nos comportamentos da própria `Reserva`, e o serviço não deve atribuir `Status` diretamente. | 2 | inspeção estrutural |
| R14 | `Reserva` deve possuir um `PeriodoReserva` como parte obrigatória e não substituível externamente. | 2 | reflexão + modelo final |
| R15 | `docs/MODELO-FINAL.md` deve representar as classes centrais, multiplicidades indicadas no enunciado, composição `Reserva`–`PeriodoReserva` e o contrato de políticas. | 3 | checklist objetivo |
| R16 | Deve existir `IPoliticaReserva`; aluno permite até 2h e professor até 4h. | 3 | testes |
| R17 | `ServicoReservas` deve consultar `CatalogoPoliticasReserva` e executar a política obtida, sem codificar regras por categoria em `if`/`switch`. | 3 | testes com política substituta + inspeção |
| R18 | A evolução de visitante deve ser implementada por `PoliticaReservaVisitante`: até 1h, somente `Sala` ou `Projetor`, sem modificar o algoritmo de `ServicoReservas`. | 3 | testes ocultos |
| R19 | `docs/ESPECIFICACAO-EVOLUCAO.md` deve conter os campos obrigatórios e critérios de aceitação definidos no template. | 2 | conferência do artefato |
| R20 | `docs/ALTERACAO-FINAL.diff` deve existir e representar alterações em relação à tag `BASELINE-RRP`. | 1 | conferência do arquivo |
| R21 | Conflitos de agenda devem usar `ConflitoDeReservaException`; transições inválidas devem usar `TransicaoDeReservaInvalidaException`; violações gerais de regra podem usar `RegraDeDominioException`. | 2 | testes |
| R22 | `docs/RASTREABILIDADE.csv` deve relacionar cada requisito R01–R25 ao arquivo/elemento e à verificação correspondente. | 2 | conferência do CSV |
| R23 | Os quatro defeitos descritos em `docs/DEFEITOS.md` devem estar corrigidos e registrados em `docs/REGISTRO-DEFEITOS.csv`. | 3 | testes + CSV |
| R24 | Ao final, todos os testes públicos devem passar e a solução não pode apresentar regressões detectadas pelos testes adicionais do professor. | 3 | `dotnet test` + testes ocultos |
| R25 | A estrutura final de entrega e `docs/AUDITORIA-FINAL.md` devem estar completas conforme `docs/ENTREGA.md`. | 1 | checklist |

**Total: 60 pontos.**
