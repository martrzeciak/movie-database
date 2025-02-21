using Microsoft.Extensions.DependencyInjection;
using MovieDatabase.Application.Abstractions.Caching;
using MovieDatabase.Infrastructure.Caching;

namespace MovieDatabase.Infrastructure;

public static class ApplicationServiceInfrastructure
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        // Add caching service
        services.AddMemoryCache();
        services.AddSingleton<ICacheService, CachingService>();

        return services;
    }
}
