using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using MovieDatabase.Application.Behaviors;
using MovieDatabase.Application.Features.Movies.Commands.UpdateMovie;
using System.Reflection;

namespace MovieDatabase.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // MediatR
        services.AddMediatR(cfg =>
        {
            // Register the handlers from the executing assembly
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            // Register the validation behavior
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            cfg.AddOpenBehavior(typeof(QueryCachingBehavior<,>));
        });

        // FluentValidation
        services.AddValidatorsFromAssemblyContaining<UpdateMovieCommandValidator>();

        // Mapster
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}
