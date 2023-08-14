using static Dev.Host.Controllers.BaseController;
using static Dev.Host.Infrastructure.AddSwaggerGen;
using static Dev.Host.Infrastructure.CustomizationCultureInfo;
using static Dev.Host.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

SwaggerGen.ConfigureSwaggerGenService(builder.Services);

ConfigureService.ConfigureDependencyService(builder.Services);

ConfigureService.ConfigureLogging(builder.Services);

if (builder.Configuration.GetSection("Environment").Value.Equals("P"))
    builder.Configuration.AddJsonFile("appsettings.Production.json", optional: false, reloadOnChange: true);
else if (builder.Configuration.GetSection("Environment").Value.Equals("H"))
    builder.Configuration.AddJsonFile("appsettings.Homologation.json", optional: false, reloadOnChange: true);


var app = builder.Build();

app.UseMiddleware<CustomExceptionMiddleware>();

CustomizationCulture.ConfigureCultureInfo(app);

SwaggerGen.ConfigureSwaggerUse(app);

app.MapControllers();

app.Run();