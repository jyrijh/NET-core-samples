using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DI.Worker;

public static class DependencyInjection
{
    public static IServiceCollection AddWorker(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<Settings>(configuration.GetSection(Settings.SectionName));
        services.AddTransient<Worker>();

        return services;
    }
}
