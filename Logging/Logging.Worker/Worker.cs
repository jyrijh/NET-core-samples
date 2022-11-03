using Microsoft.Extensions.Logging;

namespace Samples.Logging;

public class Worker
{
    ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    public void Run(string file)
    {
         _logger.LogInformation("running {file}", file);

        _logger.LogWarning("This is warning");
        _logger.LogError("This is error");
    }
}