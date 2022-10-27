using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Database.SampleRepository.Models;
using Database.Application;

namespace Database.SampleRepository;

public static class DependencyInjection
{
    public static IServiceCollection AddSampleRepository(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SchoolContext>(optionsBuilder =>
        {
            optionsBuilder.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            //optionsBuilder.UseSqlServer(
            //    configuration.GetConnectionString("DefaultConnection"),
            //    options =>
            //    {
            //        options.EnableRetryOnFailure();
            //        options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            //    });
        });

        services.AddScoped<ISampleRepository, Repository>();

        return services;
    }
}
