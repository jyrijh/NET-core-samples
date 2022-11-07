# Dependency Injection 

## DI.App

Entry point for Application and Dependency Injection root

Register worker and service for it.

`Microsoft.Extensions.Hosting`  
`Microsoft.Extensions.Hosting.Abstractions`  

```csharp
return Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddWorker(hostContext.Configuration);
        services.AddTransient<ISampleService, SampleService>();
    });
```

## DI.Worker

Worker registration and configuration

`Microsoft.Extensions.Options.ConfigurationExtensions`  

```csharp
public static IServiceCollection AddWorker(this IServiceCollection services, IConfiguration configuration)
{
    services.Configure<Settings>(configuration.GetSection(Settings.SectionName));
    services.AddTransient<Worker>();

    return services;
}
```
