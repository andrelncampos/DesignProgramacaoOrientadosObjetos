using RrpReservas.Dominio.Entidades;
using RrpReservas.Dominio.Enums;
using RrpReservas.Dominio.Excecoes;
using RrpReservas.Dominio.ObjetosValor;
using RrpReservas.Dominio.Servicos;

namespace Reservas.Tests;

public class AgendaReservasTests
{
    [Fact]
    [Trait("Requisito", "R09")]
    public void ColecaoExposta_NaoPodeSerUmaListMutavel()
    {
        var agenda = new AgendaReservas();
        Assert.False(agenda.Reservas is List<Reserva>);
    }

    [Fact]
    [Trait("Requisito", "R10")]
    public void MesmoRecursoEmPeriodoConflitante_DeveSerRejeitado()
    {
        var agenda = new AgendaReservas();
        var recurso = NovoRecurso();
        agenda.Adicionar(NovaReserva(recurso, 10, 12));
        Assert.Throws<ConflitoDeReservaException>(() => agenda.Adicionar(NovaReserva(recurso, 11, 13)));
    }

    [Fact]
    [Trait("Requisito", "R11")]
    public void ReservaCancelada_NaoBloqueiaAgenda()
    {
        var agenda = new AgendaReservas();
        var recurso = NovoRecurso();
        var antiga = NovaReserva(recurso, 10, 12);
        antiga.Cancelar();
        agenda.Adicionar(antiga);
        agenda.Adicionar(NovaReserva(recurso, 11, 13));
        Assert.Equal(2, agenda.Reservas.Count);
    }

    [Fact]
    [Trait("Requisito", "R12")]
    public void RecursoInativo_NaoPodeReceberNovaReserva()
    {
        var agenda = new AgendaReservas();
        var recurso = NovoRecurso();
        recurso.Desativar();
        Assert.Throws<RegraDeDominioException>(() => agenda.Adicionar(NovaReserva(recurso, 10, 11)));
    }

    private static Recurso NovoRecurso() => new(Guid.NewGuid(), "Sala 101", TipoRecurso.Sala);

    private static Reserva NovaReserva(Recurso recurso, int inicio, int fim)
    {
        var usuario = new Usuario(Guid.NewGuid(), "Ana", CategoriaUsuario.Aluno);
        var periodo = new PeriodoReserva(new DateTime(2026, 12, 2, inicio, 0, 0), new DateTime(2026, 12, 2, fim, 0, 0));
        return new Reserva(Guid.NewGuid(), usuario, recurso, periodo);
    }
}
