using AvitoService.Core.Common.Models;
using FluentValidation;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace AvitoService.Core.Common.Handlers;

public class GlobalRequestExceptionHandler<TRequest, TResponse, TException>(ILogger<GlobalRequestExceptionHandler<TRequest, TResponse, TException>> logger) : IRequestExceptionHandler<TRequest, TResponse, TException>
    where TRequest : BaseRequest, new()
    where TResponse : BaseResponse, new()
    where TException : Exception
{
    public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Something went wrong while handling request of type {@requestType}", typeof(TRequest));
        
        var response = new TResponse
        {
            RequestId = request.RequestId,
            IsSuccess = false,
            Message = NormalizeOfException(exception)
        };
        state.SetHandled(response);
        
        return Task.CompletedTask;
    }

    private string NormalizeOfException(Exception exception) => exception switch
    {
        ValidationException ex => string.Join($"{Environment.NewLine}", ex.Errors.Select(v => $"{v.PropertyName}: {v.ErrorMessage}")),
        _ => exception.Message
    };
}