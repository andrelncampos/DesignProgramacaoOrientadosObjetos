namespace RrpReservas.Dominio.Excecoes;

public sealed class PoliticaReservaNaoEncontradaException : RegraDeDominioException
{
    public PoliticaReservaNaoEncontradaException(string message) : base(message) { }
}
