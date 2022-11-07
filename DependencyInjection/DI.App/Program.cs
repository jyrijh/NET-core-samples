using DI.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SomeService;

namespace DI.App;

internal class Program
{
    static void Main(string[] args)
    {
        using var host = CreateHostBuilder(args).Build();
        using var scope = host.Services.CreateScope();
        scope.ServiceProvider
            .GetRequiredService<Worker.Worker>()
            .Run();
    }

    static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddWorker(hostContext.Configuration);
                services.AddTransient<ISampleService, SampleService>();
            });
    }
}