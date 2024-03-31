using System.Diagnostics;
using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Logging;
using AvitoService.Core.Common.Models;

namespace AvitoService.Core.Common.Behaviors;

public class GlobalLoggingBehavior<TRequest, TResponse>(ILogger<GlobalLoggingBehavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : BaseRequest
    where TResponse : BaseResponse
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var sw = Stopwatch.StartNew();

        logger.LogInformation("SyncId = {requestId}. Started operation. RequestType: {type}. Request Payload: {jsonRequest}", request.RequestId, request.GetType(), JsonSerializer.Serialize(request));

        var response = await next();

        sw.Stop();

        logger.LogInformation(
            "SyncId = {requestId}. Finished operation in {seconds}s/{elapsedMilliseconds}ms. ResponseType: {type}. " +
            "Response: {jsonRequest}", request.RequestId, sw.ElapsedMilliseconds / 1000, sw.ElapsedMilliseconds, response.GetType(), JsonSerializer.Serialize(response));

        return response;
    }
}