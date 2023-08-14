using Dev.Application.Shared;
using Dev.Application.Shared.Agendamento;

namespace Dev.Application.Agendamento
{
    public interface IServiceAgendamento
    {
        bool Create(CreateAgendamento Model, BaseRequest baseRequest);
    }
}
