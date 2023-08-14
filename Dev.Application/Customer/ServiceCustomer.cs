using Dev.Application.Shared;
using Dev.Application.Shared.Customer;
using Dev.SqlServer;

namespace Dev.Application.Customer
{
    public class ServiceCustomer : IServiceCustomer
    {
        private readonly ISqlRepository _ISqlRepository;

        public ServiceCustomer(ISqlRepository iSqlRepository)
        {
            _ISqlRepository = iSqlRepository;
        }

        public int Create(CreateModel Model, BaseRequest baseRequest)
        {
            try
            {
                var response = _ISqlRepository.RunLoad(
                      baseRequest.ConnectionString
                    , baseRequest.CmdText
                    , baseRequest.StoredProcedure,
                    new Dictionary<string, object>
                    {
                        { "Nome", Model.Nome },
                        { "Telefone", Model.Telefone }
                    }
                    , true);

                return response;
            }
            catch
            {
                return 0;
            }
        }
    }
}
