﻿namespace MovieDatabase.Application.Abstractions.Caching;

public interface ICacheService
{
    Task<T> GetOrCreateAsync<T>(string key, Func<CancellationToken,
        Task<T>> factory, TimeSpan? expiration = null,
        CancellationToken cancellationToken = default);

    public void Remove(string key);
}