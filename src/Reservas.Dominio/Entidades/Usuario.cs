using RrpReservas.Dominio.Enums;

namespace RrpReservas.Dominio.Entidades;

public class Usuario
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public CategoriaUsuario Categoria { get; set; }

    public Usuario(Guid id, string nome, CategoriaUsuario categoria)
    {
        Id = id;
        Nome = nome;
        Categoria = categoria;
    }
}
