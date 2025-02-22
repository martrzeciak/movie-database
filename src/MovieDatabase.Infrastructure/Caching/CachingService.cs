using Microsoft.Extensions.Caching.Memory;
using MovieDatabase.Application.Abstractions.Caching;

namespace MovieDatabase.Infrastructure.Caching;

public class CachingService(IMemoryCache memoryCache) : ICacheService
{
    private static readonly TimeSpan DefaultExpiration = TimeSpan.FromMinutes(5);

    public async Task<T> GetOrCreateAsync<T>(string key, Func<CancellationToken, 
        Task<T>> factory, TimeSpan? expiration = null, 
        CancellationToken cancellationToken = default)
    {
        T? result = await memoryCache.GetOrCreateAsync(
            key,
            entry =>
            {
                entry.SetAbsoluteExpiration(expiration ?? DefaultExpiration);

                return factory(cancellationToken);
            });

        if (result == null)
            throw new InvalidOperationException("Cache service error.");

        return result;
    }

    public void Remove(string key)
    {
        memoryCache.Remove(key);
    }
}
