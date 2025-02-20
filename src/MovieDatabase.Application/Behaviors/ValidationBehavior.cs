using FluentValidation;
using MediatR;

namespace MovieDatabase.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse>
    (IValidator<TRequest>? validator = null)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    // where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        // If the request does not implement IValidatable, then skip validation
        if (validator == null) return await next();

        // Validate the request
        var context = new ValidationContext<TRequest>(request);

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        // If the request is invalid, throw a ValidationException
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await next();
    }
}
