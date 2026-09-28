using RrpReservas.Dominio.Entidades;
using RrpReservas.Dominio.Enums;
using RrpReservas.Dominio.Excecoes;
using RrpReservas.Dominio.ObjetosValor;
using RrpReservas.Dominio.Politicas;
using RrpReservas.Dominio.Servicos;

namespace Reservas.Tests;

public class ServicoReservasTests
{
    [Fact]
    [Trait("Requisito", "R17")]
    public void PoliticaRegistradaPodeNegarReservaMesmoQuandoCategoriaSeriaAceitaPeloCodigoAntigo()
    {
        var agenda = new AgendaReservas();
        var catalogo = new CatalogoPoliticasReserva(new IPoliticaReserva[] { new PoliticaQueNegaAluno() });
        var servico = new ServicoReservas(agenda, catalogo);
        var usuario = new Usuario(Guid.NewGuid(), "Ana", CategoriaUsuario.Aluno);
        var recurso = new Recurso(Guid.NewGuid(), "Sala", TipoRecurso.Sala);
        var periodo = new PeriodoReserva(new DateTime(2026, 12, 2, 10, 0, 0), new DateTime(2026, 12, 2, 11, 0, 0));

        Assert.Throws<RegraDeDominioException>(() => servico.Solicitar(usuario, recurso, periodo));
    }

    private sealed class PoliticaQueNegaAluno : IPoliticaReserva
    {
        public CategoriaUsuario Categoria => CategoriaUsuario.Aluno;
        public bool PodeReservar(Usuario usuario, Recurso recurso, PeriodoReserva periodo) => false;
    }
}
