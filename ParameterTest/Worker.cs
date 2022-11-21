namespace Parameter;

public class Worker
{
    readonly IParameterFactory _factory;

    private static int number = 1;

    public Worker(IParameterFactory factory)
    {
        _factory = factory;
    }

    public Task RunAsync()
    {
        ISomeService service = null!;
        service = _factory.Create("1", $"{number++}");
        service = _factory.Create("2", $"{number++}");
        service = _factory.Create("1", $"{number++}");
        service = _factory.Create("2", $"{number++}");
        service = _factory.Create("1", $"{number++}");
        service = _factory.Create("2", $"{number++}");

        return Task.CompletedTask;
    }
}