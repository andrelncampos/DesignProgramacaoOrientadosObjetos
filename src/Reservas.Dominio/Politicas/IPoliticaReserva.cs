using RrpReservas.Dominio.Entidades;
using RrpReservas.Dominio.Enums;
using RrpReservas.Dominio.ObjetosValor;

namespace RrpReservas.Dominio.Politicas;

public interface IPoliticaReserva
{
    CategoriaUsuario Categoria { get; }
    bool PodeReservar(Usuario usuario, Recurso recurso, PeriodoReserva periodo);
}
