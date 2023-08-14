using Dev.Application.Shared.Agendamento;
using FluentValidation;

namespace Dev.Application.Shared.Validator.Agendamento
{
    public class AgendamentoValidator : AbstractValidator<CreateAgendamento>
    {
        public AgendamentoValidator()
        {
            RuleFor(c => c.Data)
               .Matches(@"\b\d{1,2}/\d{1,2}/\d{4}\b")
               .WithMessage("O campo data deve estar no formato DD/MM/YYYY");

            RuleFor(x => x.Hora)
                .Matches(@"\b\d{2}:\d{2}:\d{2}\b")
                .WithMessage("O campo hora deve estar no formato HH:MM:SS");
        }
    }
}
