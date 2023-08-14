using Dev.Application.Shared;
using Dev.Application.Shared.Agendamento;
using Dev.SqlServer;

namespace Dev.Application.Agendamento
{
    public class ServiceAgendamento : IServiceAgendamento
    {
        private readonly ISqlRepository _ISqlRepository;

        public ServiceAgendamento(ISqlRepository iSqlRepository)
        {
            _ISqlRepository = iSqlRepository;
        }

        public bool Create(CreateAgendamento Model, BaseRequest baseRequest)
        {
            try
            {
                _ISqlRepository.RunLoad(
                      baseRequest.ConnectionString
                    , baseRequest.CmdText
                    , baseRequest.StoredProcedure,
                    new Dictionary<string, object>
                    {
                        { "CustomerId", Model.CustomerId },
                        { "Data", Model.Data },
                        { "Hora", Model.Hora },
                        { "Valor", Model.Valor }
                    });

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
