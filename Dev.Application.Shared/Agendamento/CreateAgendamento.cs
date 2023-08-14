namespace Dev.Application.Shared.Agendamento
{
    public class CreateAgendamento
    {
        public int CustomerId { get; set; }

        public string Data { get; set; }

        public string Hora { get; set; }

        public Decimal Valor { get; set; }
    }
}