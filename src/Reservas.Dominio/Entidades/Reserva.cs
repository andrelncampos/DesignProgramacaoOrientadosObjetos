using RrpReservas.Dominio.Enums;
using RrpReservas.Dominio.ObjetosValor;

namespace RrpReservas.Dominio.Entidades;

public class Reserva
{
    public Guid Id { get; set; }
    public Usuario Usuario { get; set; }
    public Recurso Recurso { get; set; }
    public PeriodoReserva Periodo { get; set; }
    public StatusReserva Status { get; set; }

    public bool BloqueiaAgenda => Status != StatusReserva.Cancelada;

    public Reserva(Guid id, Usuario usuario, Recurso recurso, PeriodoReserva periodo)
    {
        Id = id;
        Usuario = usuario;
        Recurso = recurso;
        Periodo = periodo;
        Status = StatusReserva.Solicitada;
    }

    public void Confirmar() => Status = StatusReserva.Confirmada;
    public void Cancelar() => Status = StatusReserva.Cancelada;
    public void Concluir() => Status = StatusReserva.Concluida;
}
