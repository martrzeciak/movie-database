using MediatR;
using MovieDatabase.Application.Abstractions.Caching;

namespace MovieDatabase.Application.Behaviors;

public class QueryCachingBehavior<TRequest, TResponse>(ICacheService cacheService)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICachedQuery
{
    public async Task<TResponse> Handle(TRequest request, 
        RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        return await cacheService.GetOrCreateAsync(
            request.Key, 
            _ => next(), 
            request.Expiration, 
            cancellationToken);
    }
}
