# Defeitos conhecidos que devem ser corrigidos

Os sintomas abaixo fazem parte deliberadamente do projeto-base. O enunciado informa o comportamento observável, não a causa.

## BUG-01 — sobreposição parcial não detectada

Com uma reserva existente de 10:00 a 12:00, uma nova reserva do mesmo recurso de 09:00 a 11:00 pode não ser reconhecida como conflito.

## BUG-02 — reserva concluída continua bloqueando a agenda

Uma reserva em estado `Concluida` não deve impedir uma nova reserva do mesmo recurso para o mesmo período em um cenário de teste controlado, mas a implementação inicial pode tratá-la como bloqueadora.

## BUG-03 — transição inválida aceita

Uma reserva `Cancelada` pode voltar a `Confirmada`, embora essa transição seja proibida.

## BUG-04 — coleção interna da agenda exposta

Código externo consegue obter a coleção real usada pela agenda e modificá-la sem passar pelas regras do domínio.

Registre a correção em `REGISTRO-DEFEITOS.csv`.
