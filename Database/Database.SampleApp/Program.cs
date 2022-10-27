using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Database.Application;
using Database.SampleRepository;

var host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

scope.ServiceProvider.GetRequiredService<App>()
    .Run();

static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddSampleRepository(hostContext.Configuration);
        services.AddScoped<App>();
    });
