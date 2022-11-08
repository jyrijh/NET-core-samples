using Mediatr.Sample.Service;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Mediatr.Sample
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            await RunWorkerAsync(host);
        }

        private static async Task RunWorkerAsync(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var worker = scope.ServiceProvider.GetRequiredService<Worker>();

            try
            {
                await worker.RunAsync();
                await worker.RunErrorAsync();
            }
            catch(Exception)
            { }
        }

        static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services
                    .AddScoped<Worker>()
                    .AddTransient<ISampleService, SampleService>()
                    .AddTransient<ISampleErrorService, ErrorService>()
                    .AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            });
    }
}