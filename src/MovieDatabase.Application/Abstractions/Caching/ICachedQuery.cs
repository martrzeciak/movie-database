using MovieDatabase.Application.Abstractions.CQRS;

namespace MovieDatabase.Application.Abstractions.Caching;

public interface ICachedQuery<TResponse> : IQuery<TResponse>, ICachedQuery;

public interface ICachedQuery
{
    string Key { get; }
    TimeSpan? Expiration { get; }
}
