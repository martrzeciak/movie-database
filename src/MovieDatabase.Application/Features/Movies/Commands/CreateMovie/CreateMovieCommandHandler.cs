using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Common;
using MovieDatabase.Domain.Entities;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Movies.Commands.CreateMovie;

public class CreateMovieCommandHandler(AppDbContext context)
    : IRequestHandler<CreateMovieCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateMovieCommand request, 
        CancellationToken cancellationToken)
    {
        // Adapt the CreateMovieDto to a Movie entity
        var movie = request.CreateMovieDto.Adapt<Movie>();

        // Check if genres exist
        var movieDtoGenres = request.CreateMovieDto.Genres
            .Select(g => g.Id)
            .ToHashSet();

        var genres = await context.Genres
            .Where(g => movieDtoGenres.Contains(g.Id))
            .ToListAsync(cancellationToken);

        if (genres.Count != movieDtoGenres.Count)
            return Result<string>.Failure("One or more genres not found.", 404);

        // Add genres to the movie
        movie.Genres = genres;
        // Add the movie to the context
        context.Movies.Add(movie);

        var result = await context.SaveChangesAsync(cancellationToken) > 0;

        return result
            ? Result<string>.Success(movie.Id.ToString())
            : Result<string>.Failure("Failed to create movie.", 400);
    }
}