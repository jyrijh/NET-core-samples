using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Parameter
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Testing garbage collection, works
            using var host = CreateHostBuilderFactory(args).Build();

            try
            {
                for (int i = 0; i < 10000; i++)
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

            await Task.Delay(1);
        }

        static IHostBuilder CreateHostBuilderFactory(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddScoped<Worker>();
                services.AddParameterFactory();
            });
    }
}