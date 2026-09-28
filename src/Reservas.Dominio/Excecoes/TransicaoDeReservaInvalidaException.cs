namespace RrpReservas.Dominio.Excecoes;

public sealed class TransicaoDeReservaInvalidaException : RegraDeDominioException
{
    public TransicaoDeReservaInvalidaException(string message) : base(message) { }
}
