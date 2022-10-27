# Database

Nämä pitää ajaa ensin  
`Add-Migration Initial`  
`Update-Database`  
Database.SampleApp kansioon tulee school.db, laita tälle ominaisuudet copy always, jolloin kopioi aina tyhjän kannan bin\debug kansioon

## Database.SampleApp

Configuration root
`CreateHostBuilder` initializes DI by calling static class in Database.SampleRepository AddSampleRepository which handle database configuration and then adding Database.Application.App class.

`host.Services.CreateScope()` creates scope wich is required for `DbContext`

```csharp
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
```

## Database.Application

Logic for application  
`ISampleRepository` interface  

## Database.SampleRepository

Repository implementation, with EF Core Models.
Implements the `ISampleRepository` interface
