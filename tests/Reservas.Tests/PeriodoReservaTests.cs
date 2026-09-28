using RrpReservas.Dominio.Excecoes;
using RrpReservas.Dominio.ObjetosValor;

namespace Reservas.Tests;

public class PeriodoReservaTests
{
    [Fact]
    [Trait("Requisito", "R04")]
    public void PeriodoValido_MantemInicioEFim()
    {
        var inicio = new DateTime(2026, 12, 2, 10, 0, 0);
        var fim = inicio.AddHours(1);
        var periodo = new PeriodoReserva(inicio, fim);
        Assert.Equal(inicio, periodo.Inicio);
        Assert.Equal(fim, periodo.Fim);
    }

    [Fact]
    [Trait("Requisito", "R04")]
    public void InicioIgualAoFim_DeveFalhar()
    {
        var instante = new DateTime(2026, 12, 2, 10, 0, 0);
        Assert.Throws<RegraDeDominioException>(() => new PeriodoReserva(instante, instante));
    }

    [Fact]
    [Trait("Requisito", "R04")]
    public void InicioDepoisDoFim_DeveFalhar()
    {
        var fim = new DateTime(2026, 12, 2, 10, 0, 0);
        Assert.Throws<RegraDeDominioException>(() => new PeriodoReserva(fim.AddMinutes(1), fim));
    }

    [Fact]
    [Trait("Requisito", "R05")]
    public void SobreposicaoPelaDireita_DeveConflitar()
    {
        var a = P(10, 12);
        var b = P(11, 13);
        Assert.True(a.ConflitaCom(b));
    }

    [Fact]
    [Trait("Requisito", "R05")]
    public void SobreposicaoPelaEsquerda_DeveConflitar()
    {
        var a = P(10, 12);
        var b = P(9, 11);
        Assert.True(a.ConflitaCom(b));
    }

    [Fact]
    [Trait("Requisito", "R11")]
    public void PeriodosAdjacentes_NaoDevemConflitar()
    {
        var a = P(10, 12);
        var b = P(12, 13);
        Assert.False(a.ConflitaCom(b));
    }

    private static PeriodoReserva P(int h1, int h2) =>
        new(new DateTime(2026, 12, 2, h1, 0, 0), new DateTime(2026, 12, 2, h2, 0, 0));
}
