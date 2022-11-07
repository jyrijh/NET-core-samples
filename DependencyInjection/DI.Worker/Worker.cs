using Microsoft.Extensions.Options;

namespace DI.Worker;

public class Worker
{
    private readonly Settings _settings;

    public Worker(IOptions<Settings> settings)
    {
        _settings = settings.Value;
    }

    public void Run()
    {
        Console.WriteLine(_settings.SomeValue);
    }
}