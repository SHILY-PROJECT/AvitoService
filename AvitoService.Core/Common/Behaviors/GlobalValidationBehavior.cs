using FluentValidation;
using FluentValidation.Results;
using AvitoService.Core.Common.Models;
using MediatR;

namespace AvitoService.Core.Common.Behaviors;

public sealed class GlobalValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : BaseResponse
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!validators.Any())
            return await next();
        
        var context = new ValidationContext<TRequest>(request);

        var validationFailures = validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .Select(x => new ValidationFailure(x.PropertyName, x.ErrorMessage))
            .ToList();
        
        if (validationFailures.Any())
            throw new ValidationException(validationFailures);
  
        return await next();
    }
}