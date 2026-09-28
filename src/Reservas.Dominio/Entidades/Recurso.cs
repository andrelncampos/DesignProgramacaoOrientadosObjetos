using RrpReservas.Dominio.Enums;

namespace RrpReservas.Dominio.Entidades;

public class Recurso
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public TipoRecurso Tipo { get; set; }
    public bool EstaAtivo { get; set; }

    public Recurso(Guid id, string nome, TipoRecurso tipo, bool estaAtivo = true)
    {
        Id = id;
        Nome = nome;
        Tipo = tipo;
        EstaAtivo = estaAtivo;
    }

    public void Ativar() => EstaAtivo = true;
    public void Desativar() => EstaAtivo = false;
}
