using MediatR;
using Microsoft.Extensions.Logging;
using MovieDatabase.Application.Common;

namespace MovieDatabase.Application.Behaviors;

public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Processing request: {@RequestName} - {@DateTimeUtc}",
            typeof(TRequest).Name, DateTime.UtcNow);

        var result = await next();

        if (!result.IsSuccess)
        {
            logger.LogError("Request failed: {@RequestName} - {@Error} - {@DateTimeUtc} ",
                typeof(TRequest).Name, result.Error, DateTime.UtcNow);
        }

        logger.LogInformation("Request processed: {@RequestName} - {@DateTimeUtc}",
        typeof(TRequest).Name, DateTime.UtcNow);

        return result;
    }
}
