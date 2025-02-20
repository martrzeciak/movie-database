using Mapster;
using MovieDatabase.Application.Features.Movies.DTOs;
using MovieDatabase.Application.Features.Movies.Shared;
using MovieDatabase.Domain.Entities;

namespace MovieDatabase.Application.MappingConfigurations;

public class MovieMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Movie, BaseMovieDto>()
            .Map(dest => dest.ContentRating, src => src.ContentRating);
            // .Map(dest => dest.Genres, src => src.Genres.Select(g => g.Name));
    }
}
