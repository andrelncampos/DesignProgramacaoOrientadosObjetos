namespace RrpReservas.Dominio.ObjetosValor;

public class PeriodoReserva
{
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
    public TimeSpan Duracao => Fim - Inicio;

    public PeriodoReserva(DateTime inicio, DateTime fim)
    {
        Inicio = inicio;
        Fim = fim;
    }

    public bool ConflitaCom(PeriodoReserva outro)
    {
        // Implementação propositalmente incompleta: detecta apenas um dos casos de sobreposição.
        return outro.Inicio >= Inicio && outro.Inicio < Fim;
    }
}
