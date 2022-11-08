using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Diagnostics;
using Samples.Logging;


internal class Program
{
    private static readonly DateTime start = DateTime.Now;
    private static string workfolder = default!;

    private static string Application => AppDomain.CurrentDomain.FriendlyName;
    private static string LogFile => Path.Combine(workfolder, $"{Application}_{start:yyyyMMdd_HHmmss}.log");
    private static string TempFolder => Environment.GetEnvironmentVariable("temp") ?? AppDomain.CurrentDomain.BaseDirectory;

    private static void Main(string[] args)
    {
        workfolder = Path.GetDirectoryName(args[0]) ?? TempFolder;
        using var host = CreateHostBuilder(args, LogFile).Build();

        try
        {
            using var scope = host.Services.CreateScope();
            Run(args[0], LogFile, scope);
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


    static IHostBuilder CreateHostBuilder(string[] args, string logfile) => Host.CreateDefaultBuilder(args)
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
                //.WriteTo.File(
                //    logfile,
                //    Serilog.Events.LogEventLevel.Information,
                //    GetFileOutputTemplate(hostContext));
            });

    static string GetFileOutputTemplate(HostBuilderContext hostContext)
    {
        var writeto = hostContext.Configuration.GetSection("Serilog:WriteTo");
        foreach (var item in writeto.GetChildren())
        {
            if (item["Name"] == "File")
            {
                return item.GetSection("Args:outputTemplate").Value;
            }
        }

        return "{Timestamp:yyyy-MM-dd HH:mm:ss}";
    }

    private static void Run(string file, string logfile, IServiceScope scope) =>
        scope.ServiceProvider
            .GetRequiredService<Worker>()
            .Run(file/*, logfile*/);
}