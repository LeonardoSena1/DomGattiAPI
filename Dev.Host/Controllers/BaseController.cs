using Dev.Application.Shared;
using Dev.Host.Attribute;
using Dev.Host.Components;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace Dev.Host.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class BaseController : ControllerBase
    {
        protected IActionResult CreateResponse<T>(T response)
        {
            if (response is BaseResponse baseResponse && !baseResponse.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        public class CustomExceptionMiddleware
        {
            private readonly RequestDelegate _next;
            private readonly ILogger<BaseController> _logger;
            public static IConfiguration _configuration { get; private set; }


            public CustomExceptionMiddleware(RequestDelegate next
                , ILogger<BaseController> logger
                , IConfiguration configuration)
            {
                _configuration = configuration;
                _next = next;
                _logger = logger;
            }

            public async Task InvokeAsync(HttpContext context)
            {
                var stopwatch = StopWatchStart.Start();
                try
                {
                    _logger.LogInformation($"Remote IpAddress: {context.Connection.RemoteIpAddress.ToString()}");
                    await _next(context);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);

                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(
                        JsonConvert.SerializeObject(new BaseResponse
                        {
                            Success = false,
                            Message = ex.Message,
                            Runtime = StopWatchStart.Stop(stopwatch)
                        }));
                }
            }
        }
    }
}