# Mediatr

Mediatr is registered with `.AddMediatR(AppDomain.CurrentDomain.GetAssemblies())`.  
Two services are added, `ErrorService` will throw an exception. This is handled in Mediatr pipeline with `ExceptionHandler`

```csharp
static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services
            .AddScoped<Worker>()
            .AddTransient<ISampleService, SampleService>()
            .AddTransient<ISampleErrorService, ErrorService>()
            .AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
    });
```
