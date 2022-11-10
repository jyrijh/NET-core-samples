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
        if(exception is FluentValidation.ValidationException validationexception)
            _logger.LogError(validationexception, "Validation error");
        else
            _logger.LogError(exception, "{request}", GetRequestFields(request));

        state.SetHandled(default!);
        return Task.FromException(exception);
    }

    private static List<(string name, string value)> GetRequestFields(object request)
    {
        PropertyInfo[] properties = request.GetType().GetProperties();
        List<(string name, string value)> result = new();

        foreach (var property in properties)
            if (property.GetIndexParameters().Length == 0)
                result.Add((property.Name, $"{property.GetValue(request)}"));
            else
                result.Add((property.Name, property.PropertyType.Name));
        
        return result;
    }
}

