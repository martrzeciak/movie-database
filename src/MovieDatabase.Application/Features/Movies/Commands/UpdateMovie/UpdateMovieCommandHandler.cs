using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Abstractions.CQRS;
using MovieDatabase.Application.Common;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Movies.Commands.UpdateMovie;

public class UpdateMovieCommandHandler(AppDbContext context)
    : ICommandHandler<UpdateMovieCommand, Unit>
{
    public async Task<Result<Unit>> Handle(UpdateMovieCommand request,
        CancellationToken cancellationToken)
    {
        // Get the movie from the database
        var movie = await context.Movies
            .Include(m => m.Genres)
            .Include(c => c.OriginCountries)
            .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

        // Check if movie exists
        if (movie == null) return Result<Unit>
                .Failure($"Movie with id = {request.Id} not found.", 404);

        // Adapt the UpdateMovieDto to the Movie entity
        request.Id = movie.Id;
        request.UpdateMovieDto.Adapt(movie);


        // Check if genres were provided
        if (request.UpdateMovieDto.Genres.Count != 0)
        {
            // Check if the genres from the DTO match the genres in the database
            var dtoGenreIds = request.UpdateMovieDto.Genres
                .Select(g => g.Id)
                .ToHashSet();

            // Get the genres from the database
            var existingGenres = context.Genres
                .Where(g => dtoGenreIds.Contains(g.Id))
                .ToList();

            // Check if all genres were found
            var existingGenreIds = existingGenres
                .Select(g => g.Id)
                .ToHashSet();

            if (!dtoGenreIds.SetEquals(existingGenreIds))
                return Result<Unit>.Failure("One or more genres not found.", 404);

            // Remove genres that are not in the DTO
            var genresToRemove = movie.Genres
                .Where(g => !dtoGenreIds.Contains(g.Id))
                .ToList();

            foreach (var genre in genresToRemove)
                movie.Genres.Remove(genre);

            // Add genres that are in the DTO but not in the movie
            var genresToAdd = existingGenres
                .Where(g => !movie.Genres.Any(x => x.Id == g.Id))
                .ToList();

            foreach (var genre in genresToAdd)
                movie.Genres.Add(genre);
        }


        // Check if countries were provided
        if (request.UpdateMovieDto.OriginCountries.Count != 0)
        {
            // Check if the countries from the DTO match the countries in the database
            var dtoCountryIds = request.UpdateMovieDto.OriginCountries
                .Select(c => c.Id)
                .ToHashSet();

            // Get the countries from the database
            var existingCountries = context.Countries
                .Where(c => dtoCountryIds.Contains(c.Id))
                .ToList();

            // Check if all countries were found
            var existingCountryIds = existingCountries
                .Select(c => c.Id)
                .ToHashSet();

            if (!dtoCountryIds.SetEquals(existingCountryIds))
                return Result<Unit>.Failure("One or more countries not found.", 404);

            // Remove countries that are not in the DTO
            var countriesToRemove = movie.OriginCountries
                .Where(c => !dtoCountryIds.Contains(c.Id))
                .ToList();

            foreach (var country in countriesToRemove)
                movie.OriginCountries.Remove(country);

            // Add countries that are in the DTO but not in the movie
            var countriesToAdd = existingCountries
                .Where(c => !movie.OriginCountries.Any(x => x.Id == c.Id))
                .ToList();

            foreach (var country in countriesToAdd)
                movie.OriginCountries.Add(country);
        }

        var result = await context.SaveChangesAsync(cancellationToken) > 0;

        return result
            ? Result<Unit>.Success(Unit.Value)
            : Result<Unit>.Failure("Failed to update movie.", 400);
    }
}
