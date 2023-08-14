using Dev.Application.Customer;
using Dev.Application.Shared;
using Dev.Application.Shared.Customer;
using Dev.Application.Shared.Validator.Customer;
using Dev.Host.Components;
using Dev.SqlServer;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dev.Host.Controllers.Client
{
    public class CustomerController : BaseController
    {
        public static IConfiguration _configuration { get; private set; }
        public static IServiceCustomer _serviceCustomer { get; private set; }
        public BaseRequest BaseRequest { get; set; }
        public CustomerController(IConfiguration configuration
            , IServiceCustomer serviceCustomer)
        {
            _configuration = configuration;
            _serviceCustomer = serviceCustomer;
            BaseRequest = new BaseRequest()
            {
                StoredProcedure = true,
                ConnectionString = _configuration.GetSection("ConnectionStrings:Default").Value,
            };
        }

        [HttpPost("create")]
        public IActionResult Create(CreateModel Model)
        {
            Stopwatch stopwatch = StopWatchStart.Start();
            var validator = new CustomerValidator();
            var result = validator.Validate(Model);
            int response = 0;

            if (result.IsValid)
            {
                BaseRequest.CmdText = SqlConsts.CreateCustomer;

                response = _serviceCustomer.Create(Model, BaseRequest);
            }

            return CreateResponse(
                new BaseResponse
                {
                    Success = response != 0 ? true : false,
                    Message = response != 0 ? "Salvo com sucesso" : "Ocorreu algum erro",
                    Runtime = StopWatchStart.Stop(stopwatch),
                    Data = response != 0 ? new List<object>() { response } : new List<object> { result.Errors }
                });
        }
    }
}
