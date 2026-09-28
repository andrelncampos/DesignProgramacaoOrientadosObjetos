using RrpReservas.Dominio.Entidades;
using RrpReservas.Dominio.Enums;
using RrpReservas.Dominio.ObjetosValor;
using RrpReservas.Dominio.Politicas;

namespace Reservas.Tests;

public class PoliticasTests
{
    [Fact]
    [Trait("Requisito", "R16")]
    public void Aluno_PodeReservarAteDuasHoras()
    {
        var politica = new PoliticaReservaAluno();
        Assert.True(politica.PodeReservar(U(CategoriaUsuario.Aluno), R(TipoRecurso.Sala), P(10, 12)));
    }

    [Fact]
    [Trait("Requisito", "R16")]
    public void Aluno_NaoPodeReservarMaisDeDuasHoras()
    {
        var politica = new PoliticaReservaAluno();
        Assert.False(politica.PodeReservar(U(CategoriaUsuario.Aluno), R(TipoRecurso.Sala), P(10, 13)));
    }

    [Fact]
    [Trait("Requisito", "R16")]
    public void Professor_NaoPodeReservarMaisDeQuatroHoras()
    {
        var politica = new PoliticaReservaProfessor();
        Assert.False(politica.PodeReservar(U(CategoriaUsuario.Professor), R(TipoRecurso.Sala), P(8, 13)));
    }

    private static Usuario U(CategoriaUsuario c) => new(Guid.NewGuid(), "Pessoa", c);
    private static Recurso R(TipoRecurso t) => new(Guid.NewGuid(), "Recurso", t);
    private static PeriodoReserva P(int a, int b) => new(new DateTime(2026, 12, 2, a, 0, 0), new DateTime(2026, 12, 2, b, 0, 0));
}
