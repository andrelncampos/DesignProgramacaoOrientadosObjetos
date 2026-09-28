using RrpReservas.Dominio.Entidades;
using RrpReservas.Dominio.Enums;
using RrpReservas.Dominio.ObjetosValor;

namespace RrpReservas.Dominio.Politicas;

public sealed class PoliticaReservaProfessor : IPoliticaReserva
{
    public CategoriaUsuario Categoria => CategoriaUsuario.Professor;

    public bool PodeReservar(Usuario usuario, Recurso recurso, PeriodoReserva periodo)
    {
        // Implementação propositalmente incompleta.
        return usuario.Categoria == CategoriaUsuario.Professor;
    }
}
