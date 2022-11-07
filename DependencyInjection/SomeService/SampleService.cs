using DI.Worker;

namespace SomeService;

public class SampleService : ISampleService
{
    public void PrintLine(string message)
    {
        Console.WriteLine(message);
    }
}