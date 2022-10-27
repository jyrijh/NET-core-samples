using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Database.Application;
using Database.SampleRepository;

var host = CreateHostBuilder(args).Build();

using var scope = host.Services.CreateScope();
var app = scope.ServiceProvider.GetRequiredService<App>();
app.Run();

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddSampleRepository(hostContext.Configuration);

            services
                .AddScoped<App>();
        });
}
