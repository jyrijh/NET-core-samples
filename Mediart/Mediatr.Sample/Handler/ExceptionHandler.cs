using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

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
        _logger.LogError(exception,"From ExceptionHandler");

        state.SetHandled(default!);
        //return Task.CompletedTask;
        return Task.FromException(exception);
    }
}

