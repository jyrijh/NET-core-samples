namespace Mediatr.Sample.Service;

public class SampleService : ISampleService
{
    public bool PrintLine(string message)
    {
        Console.WriteLine(message);
        return true;
    }
}