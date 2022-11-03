using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Samples.Logging;
using Serilog;
using System.Diagnostics;

internal class Program
{
    private static string Application => AppDomain.CurrentDomain.FriendlyName;
    private static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        try
        {
            using var scope = host.Services.CreateScope();
            Run(args[0], scope);
        }
        catch (Exception e)
        {
            Log.Logger.Error(e, "{Application} error", Application);
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services
                    .Configure<WorkerSettings>(hostContext.Configuration.GetSection(WorkerSettings.SectionName))
                    .AddScoped<Worker>();
            })
            .UseSerilog((hostContext, configuration) =>
            {
                configuration
                    .ReadFrom.Configuration(hostContext.Configuration);
            });

    private static void Run(string file, IServiceScope scope) =>
        scope.ServiceProvider
            .GetRequiredService<Worker>()
            .Run(file);
}