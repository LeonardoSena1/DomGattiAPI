using Dev.Application.Agendamento;
using Dev.Application.Customer;
using Dev.SqlServer;
using Dev.SqlServer.Client;
using Serilog;

namespace Dev.Host.Infrastructure
{
    public class DependencyInjection
    {
        public class ConfigureService
        {
            public static void ConfigureDependencyService(IServiceCollection servicesCollection)
            {
                servicesCollection.AddSingleton<ISqlRepository, SqlRepository>();
                servicesCollection.AddSingleton<IServiceCustomer, ServiceCustomer>();
                servicesCollection.AddSingleton<IServiceAgendamento, ServiceAgendamento>();
            }

            public static void ConfigureLogging(IServiceCollection servicesCollection)
            {
                servicesCollection.AddLogging(loggingBuilder =>
                {
                    Log.Logger = new LoggerConfiguration()
                        .WriteTo.File("App_Data/Logs/Logs.txt", rollingInterval: RollingInterval.Infinite)
                        .CreateLogger();
                    loggingBuilder.AddSerilog();
                });
            }
        }
    }
}