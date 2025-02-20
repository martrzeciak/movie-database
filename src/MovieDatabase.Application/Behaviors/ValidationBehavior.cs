using FluentValidation;
using MediatR;

namespace MovieDatabase.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse>
    (IValidator<TRequest> validator)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : notnull
{
    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (validator == null) return await next();

        var context = new ValidationContext<TRequest>(request);

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        return await next();
    }
}

public class ValidationError
{
    public string PropertyName { get; set; }
    public string ErrorMessage { get; set; }

    public ValidationError(string propertyName, string errorMessage)
    {
        PropertyName = propertyName;
        ErrorMessage = errorMessage;
    }
}