namespace Mediatr.Sample.Service;

public class ErrorService : ISampleErrorService
{
    public bool PrintLine(string message)
    {
        throw new Exception("Oops, something went wrong");
    }
}