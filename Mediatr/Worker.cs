using Mediatr.Sample.Command;
using MediatR;

namespace Mediatr.Sample;

public class Worker
{
    private readonly ISender _sender;

    public Worker(ISender sender)
    {
        _sender = sender;
    }

    private Task RunCommandAsync(string message)
    {
        return _sender.Send(new TestCommand() { Value = message });
    }

    private Task RunErrorCommandAsync(string message)
    {
        return _sender.Send(new TestErrorCommand() { Value = message });
    }

    public Task SuccessAsync() => RunCommandAsync("Hello World from Mediatr");

    public Task ValidationFailsAsync1() => RunCommandAsync("");

    public Task ValidationFailsAsync2() => RunCommandAsync(null);

    public Task ErrorAsync() => RunErrorCommandAsync("This will throw");
}