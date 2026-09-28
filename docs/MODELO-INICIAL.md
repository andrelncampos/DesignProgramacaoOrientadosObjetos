# Modelo inicial

O modelo abaixo representa apenas a estrutura inicial recebida. Ele contém simplificações e não deve ser tratado como gabarito.

```mermaid
classDiagram
    class Usuario {
      +Guid Id
      +string Nome
      +CategoriaUsuario Categoria
    }
    class Recurso {
      +Guid Id
      +string Nome
      +TipoRecurso Tipo
      +bool EstaAtivo
    }
    class PeriodoReserva {
      +DateTime Inicio
      +DateTime Fim
    }
    class Reserva {
      +Guid Id
      +StatusReserva Status
    }
    class AgendaReservas
    class ServicoReservas

    Reserva --> Usuario
    Reserva --> Recurso
    Reserva --> PeriodoReserva
    AgendaReservas --> Reserva
    ServicoReservas --> AgendaReservas
```

Crie `MODELO-FINAL.md` com o modelo correspondente à solução entregue.
