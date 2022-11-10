using FluentValidation;
using Mediatr.Sample.PipelineBehavior;
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

            await worker.SuccessAsync();

            try
            {
                await worker.ValidationFailsAsync1();
            }
            catch(Exception){ }

            try
            {
                await worker.ValidationFailsAsync2();
            }
            catch (Exception) { }

            try
            {
                await worker.ErrorAsync();
            }
            catch (Exception){ }
        }

        static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services
                    .AddScoped<Worker>()
                    .AddTransient<ISampleService, SampleService>()
                    .AddTransient<ISampleErrorService, ErrorService>();
                
                services
                    .AddMediatR(AppDomain.CurrentDomain.GetAssemblies())
                    .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

                services.AddValidatorsFromAssembly(typeof(Program).Assembly);
            });
    }
}