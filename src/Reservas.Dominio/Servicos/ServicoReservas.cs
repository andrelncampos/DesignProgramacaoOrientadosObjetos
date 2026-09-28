using RrpReservas.Dominio.Entidades;
using RrpReservas.Dominio.Enums;
using RrpReservas.Dominio.Excecoes;
using RrpReservas.Dominio.ObjetosValor;
using RrpReservas.Dominio.Politicas;

namespace RrpReservas.Dominio.Servicos;

public class ServicoReservas
{
    private readonly AgendaReservas _agenda;
    private readonly CatalogoPoliticasReserva _catalogo;

    public ServicoReservas(AgendaReservas agenda, CatalogoPoliticasReserva catalogo)
    {
        _agenda = agenda;
        _catalogo = catalogo;
    }

    public Reserva Solicitar(Usuario usuario, Recurso recurso, PeriodoReserva periodo)
    {
        // Problema proposital: regras por categoria estão codificadas diretamente no serviço.
        bool permitido;

        if (usuario.Categoria == CategoriaUsuario.Aluno)
        {
            permitido = periodo.Duracao <= TimeSpan.FromHours(2);
        }
        else if (usuario.Categoria == CategoriaUsuario.Professor)
        {
            permitido = periodo.Duracao <= TimeSpan.FromHours(4);
        }
        else
        {
            permitido = false;
        }

        if (!permitido)
        {
            throw new RegraDeDominioException("A política atual não permite esta reserva.");
        }

        var reserva = new Reserva(Guid.NewGuid(), usuario, recurso, periodo);
        _agenda.Adicionar(reserva);
        return reserva;
    }

    public void Confirmar(Reserva reserva)
    {
        reserva.Confirmar();
    }
}
