using RrpReservas.Dominio.Entidades;
using RrpReservas.Dominio.Enums;
using RrpReservas.Dominio.ObjetosValor;
using RrpReservas.Dominio.Politicas;
using RrpReservas.Dominio.Servicos;

var agenda = new AgendaReservas();
var catalogo = new CatalogoPoliticasReserva(new IPoliticaReserva[]
{
    new PoliticaReservaAluno(),
    new PoliticaReservaProfessor()
});
var servico = new ServicoReservas(agenda, catalogo);

var ana = new Usuario(Guid.NewGuid(), "Ana", CategoriaUsuario.Aluno);
var sala = new Recurso(Guid.NewGuid(), "Sala 101", TipoRecurso.Sala);
var periodo = new PeriodoReserva(
    new DateTime(2026, 12, 2, 10, 0, 0),
    new DateTime(2026, 12, 2, 11, 30, 0));

var reserva = servico.Solicitar(ana, sala, periodo);
Console.WriteLine($"Reserva criada: {reserva.Id}");
Console.WriteLine($"Status inicial: {reserva.Status}");

servico.Confirmar(reserva);
Console.WriteLine($"Status após confirmação: {reserva.Status}");
Console.WriteLine($"Reservas na agenda: {agenda.Reservas.Count}");
