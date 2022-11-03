#  Logging

By using two WriteTo File outputs you can send specific logmessages to separate file.  
All logmessages are written to Logging.App.log, but LogError messages are written also to App.Errors.log with `"restrictedToMinimumLevel": "Error"`.

```csharp
static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services
                    .Configure<WorkerSettings>(hostContext.Configuration.GetSection(WorkerSettings.SectionName))
                    .AddScoped<Worker>();
            })
            .UseSerilog((hostContext, configuration) =>
            {
                configuration
                    .ReadFrom.Configuration(hostContext.Configuration);
            });
```

```json
"Serilog": {
    "Using": [
      "Serilog.Sinks.Console",
      "Serilog.Sinks.File"
    ],
    "WriteTo": [
      {
        "Name": "Console"
      },
      {
        "Name": "File",
        "Args": {
          "path": "c:/temp/Logging.App.log",
          "outputTemplate": "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message}{NewLine}{Exception}"
        }
      },
      {
        "Name": "File",
        "Args": {
          "path": "c:/temp/Logging.App.Errors.log",
          "restrictedToMinimumLevel": "Error",
          "outputTemplate": "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message}{NewLine}{Exception}"
        }
      }
    ]
  }
  ```
