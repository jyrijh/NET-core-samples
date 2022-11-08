using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Mediatr.Sample.Handler;

public class ExceptionHandler<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException>
    where TRequest : IRequest<TResponse>
    where TException : Exception
{
    ILogger<ExceptionHandler<TRequest, TResponse, TException>> _logger;

    public ExceptionHandler(ILogger<ExceptionHandler<TRequest, TResponse, TException>> logger)
    {
        _logger = logger;
    }

    public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken)
    {
        _logger.LogError(exception,"{request}", ExceptionHandler<TRequest, TResponse, TException>.GetRequestFields(request));

        state.SetHandled(default!);
        //return Task.CompletedTask;
        return Task.FromException(exception);
    }

    private static List<(string name, string value)> GetRequestFields(object request)
    {
        PropertyInfo[] properties = request.GetType().GetProperties();
        List<(string name, string value)> fields = new();

        foreach (var prop in properties)
            if (prop.GetIndexParameters().Length == 0)
                fields.Add((prop.Name, $"{prop.GetValue(request)}"));
            else
                fields.Add((prop.Name, prop.PropertyType.Name));
        
        return fields;
    }
}

