using RrpReservas.Dominio.Entidades;
using RrpReservas.Dominio.ObjetosValor;

namespace RrpReservas.Dominio.Servicos;

public class AgendaReservas
{
    private readonly List<Reserva> _reservas = new();

    // Problema proposital: a coleção interna está exposta e pode ser alterada externamente.
    public List<Reserva> Reservas => _reservas;

    public bool TemConflito(Recurso recurso, PeriodoReserva periodo, Guid? ignorarReservaId = null)
    {
        return _reservas.Any(r =>
            r.Recurso.Id == recurso.Id &&
            r.Id != ignorarReservaId &&
            r.BloqueiaAgenda &&
            r.Periodo.ConflitaCom(periodo));
    }

    public void Adicionar(Reserva reserva)
    {
        // Problema proposital: nenhuma regra é verificada aqui.
        _reservas.Add(reserva);
    }
}
