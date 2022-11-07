using Microsoft.Extensions.Options;

namespace DI.Worker;

public class Worker
{
    private readonly Settings _settings;
    private readonly ISampleService _sampleService;

    public Worker(IOptions<Settings> settings, ISampleService sampleService)
    {
        _settings = settings.Value;
        _sampleService = sampleService;
    }

    public void Run()
    {
        _sampleService.PrintLine(_settings.SomeValue);
    }
}