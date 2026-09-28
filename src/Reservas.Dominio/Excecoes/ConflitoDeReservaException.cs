namespace RrpReservas.Dominio.Excecoes;

public sealed class ConflitoDeReservaException : RegraDeDominioException
{
    public ConflitoDeReservaException(string message) : base(message) { }
}
