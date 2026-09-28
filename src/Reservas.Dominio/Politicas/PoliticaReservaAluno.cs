using RrpReservas.Dominio.Entidades;
using RrpReservas.Dominio.Enums;
using RrpReservas.Dominio.ObjetosValor;

namespace RrpReservas.Dominio.Politicas;

public sealed class PoliticaReservaAluno : IPoliticaReserva
{
    public CategoriaUsuario Categoria => CategoriaUsuario.Aluno;

    public bool PodeReservar(Usuario usuario, Recurso recurso, PeriodoReserva periodo)
    {
        // Implementação propositalmente incompleta.
        return usuario.Categoria == CategoriaUsuario.Aluno;
    }
}
