using Dev.Application.Agendamento;
using Dev.Application.Shared;
using Dev.Application.Shared.Agendamento;
using Dev.Application.Shared.Validator.Agendamento;
using Dev.Host.Components;
using Dev.SqlServer;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dev.Host.Controllers.Agendamento
{
    public class AgendamentoController : BaseController
    {
        public static IConfiguration _configuration { get; private set; }
        public static IServiceAgendamento _agendamento { get; private set; }
        public BaseRequest BaseRequest { get; set; }
        public AgendamentoController(IConfiguration configuration
            , IServiceAgendamento agendamento)
        {
            _configuration = configuration;
            _agendamento = agendamento;
            BaseRequest = new BaseRequest()
            {
                StoredProcedure = true,
                ConnectionString = _configuration.GetSection("ConnectionStrings:Default").Value,
            };
        }

        [HttpPost("create")]
        public IActionResult Create(CreateAgendamento Model)
        {
            Stopwatch stopwatch = StopWatchStart.Start();
            var validator = new AgendamentoValidator();
            var result = validator.Validate(Model);
            bool response = false;

            if (result.IsValid)
            {
                BaseRequest.CmdText = SqlConsts.CreateAgendamento;

                response = _agendamento.Create(Model, BaseRequest);
            }

            return CreateResponse(
                new BaseResponse
                {
                    Success = response,
                    Message = response ? "Salvo com sucesso" : "Ocorreu algum erro",
                    Runtime = StopWatchStart.Stop(stopwatch),
                    Data = response ? new List<object>() : new List<object> { result.Errors }
                });
        }
    }
}
