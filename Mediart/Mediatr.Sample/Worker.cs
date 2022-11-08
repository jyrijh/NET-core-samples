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

    public Task RunAsync()
    {
        return RunCommandAsync("Hello World from Mediatr");
    }

    private async Task RunCommandAsync(string message)
    {
        await _sender.Send(new TestCommand() { Value = message });
    }

    public Task RunErrorAsync()
    {
        return RunErrorCommandAsync("This will throw");
    }

    private async Task RunErrorCommandAsync(string message)
    {
        await _sender.Send(new TestErrorCommand() { Value = message });
    }
}