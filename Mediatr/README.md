# Mediatr

## Mediatr

Mediatr is registered with `.AddMediatR(AppDomain.CurrentDomain.GetAssemblies())`.  
Two services are added, `ErrorService` will throw an exception. This is handled in Mediatr pipeline with `ExceptionHandler`

`.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));` adds Pipeline behavior to Mediator. `<,>` Adds it to all types.

## FluentValidation

`services.AddValidatorsFromAssembly(typeof(Program).Assembly);`

```csharp
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
```
