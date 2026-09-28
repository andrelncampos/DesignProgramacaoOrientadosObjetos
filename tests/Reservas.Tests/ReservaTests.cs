using RrpReservas.Dominio.Entidades;
using RrpReservas.Dominio.Enums;
using RrpReservas.Dominio.Excecoes;
using RrpReservas.Dominio.ObjetosValor;

namespace Reservas.Tests;

public class ReservaTests
{
    [Fact]
    [Trait("Requisito", "R06")]
    public void NovaReserva_DeveComecarSolicitada()
    {
        Assert.Equal(StatusReserva.Solicitada, Criar().Status);
    }

    [Fact]
    [Trait("Requisito", "R07")]
    public void ReservaSolicitada_PodeSerConfirmada()
    {
        var reserva = Criar();
        reserva.Confirmar();
        Assert.Equal(StatusReserva.Confirmada, reserva.Status);
    }

    [Fact]
    [Trait("Requisito", "R08")]
    public void ReservaCancelada_NaoPodeSerConfirmada()
    {
        var reserva = Criar();
        reserva.Cancelar();
        Assert.Throws<TransicaoDeReservaInvalidaException>(() => reserva.Confirmar());
    }

    [Fact]
    [Trait("Requisito", "R07")]
    public void ReservaConfirmada_PodeSerConcluida()
    {
        var reserva = Criar();
        reserva.Confirmar();
        reserva.Concluir();
        Assert.Equal(StatusReserva.Concluida, reserva.Status);
    }

    [Fact]
    [Trait("Requisito", "R08")]
    public void ReservaConcluida_NaoPodeSerCancelada()
    {
        var reserva = Criar();
        reserva.Confirmar();
        reserva.Concluir();
        Assert.Throws<TransicaoDeReservaInvalidaException>(() => reserva.Cancelar());
    }

    private static Reserva Criar()
    {
        var usuario = new Usuario(Guid.NewGuid(), "Ana", CategoriaUsuario.Aluno);
        var recurso = new Recurso(Guid.NewGuid(), "Sala", TipoRecurso.Sala);
        var periodo = new PeriodoReserva(new DateTime(2026, 12, 2, 10, 0, 0), new DateTime(2026, 12, 2, 11, 0, 0));
        return new Reserva(Guid.NewGuid(), usuario, recurso, periodo);
    }
}
