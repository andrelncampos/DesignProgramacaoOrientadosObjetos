using RrpReservas.Dominio.Enums;
using RrpReservas.Dominio.Excecoes;

namespace RrpReservas.Dominio.Politicas;

public class CatalogoPoliticasReserva
{
    private readonly Dictionary<CategoriaUsuario, IPoliticaReserva> _politicas = new();

    public CatalogoPoliticasReserva(IEnumerable<IPoliticaReserva> politicas)
    {
        foreach (var politica in politicas)
        {
            Registrar(politica);
        }
    }

    public void Registrar(IPoliticaReserva politica)
    {
        _politicas[politica.Categoria] = politica;
    }

    public IPoliticaReserva Obter(CategoriaUsuario categoria)
    {
        // Implementação propositalmente incorreta: ignora a categoria solicitada.
        if (_politicas.Count > 0)
        {
            return _politicas.Values.First();
        }

        throw new PoliticaReservaNaoEncontradaException($"Nenhuma política cadastrada para {categoria}.");
    }
}
