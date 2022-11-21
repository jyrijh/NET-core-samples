using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FactoryPattern.Samples;
using System.Security.Cryptography.X509Certificates;
using FactoryPattern.Factories;

namespace FactoryPattern;

internal class Program
{
    static async Task Main(string[] args)
    {
        //using var host = CreateHostBuilderDirect(args).Build();
        using var host = CreateHostBuilderFactory(args).Build();

        try
        {
            for (int i = 0; i < 2; i++)
                await RunWorkerAsync(host);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static async Task RunWorkerAsync(IHost host)
    {
        using var scope = host.Services.CreateScope();
        await scope.ServiceProvider
            .GetRequiredService<Worker>()
            .RunAsync();

        await Task.Delay(1000);
    }

    static IHostBuilder CreateHostBuilderDirect(string[] args) => Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddScoped<Worker>();
            services.AddTransient<ISample1, Sample1>();
            services.AddSingleton<Func<ISample1>>(x => () => x.GetRequiredService<ISample1>());
        });

    static IHostBuilder CreateHostBuilderFactory(string[] args) => Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddScoped<Worker>();
            services.AddAbstractFactory<ISample1, Sample1>();
            services.AddAbstractFactory<ISample2, Sample2>();
            services.AddGenericClassWithDataFactory();
            services.AddVehicleFactory();
        });
}