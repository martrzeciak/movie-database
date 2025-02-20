using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Common;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Movies.Commands.UpdateMovie;

public class UpdateMovieCommandHandler(AppDbContext context)
    : IRequestHandler<UpdateMovieCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateMovieCommand request,
        CancellationToken cancellationToken)
    {
        // Get the movie from the database
        var movie = await context.Movies
            .Include(m => m.Genres)
            .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

        // Check if movie exists
        if (movie == null) return Result<Unit>
                .Failure($"Movie with id = {request.Id} not found.", 404);

        // Adapt the UpdateMovieDto to the Movie entity
        request.Id = movie.Id;
        request.UpdateMovieDto.Adapt(movie);

        // Check if the genres from the DTO match the genres in the database
        var dtoGenreIds = request.UpdateMovieDto.Genres.Select(g => g.Id).ToHashSet();
        var dbGenreIds = movie.Genres.Select(g => g.Id).ToHashSet();

        if (!dtoGenreIds.SetEquals(dbGenreIds))
        {
            // Check if genres exist
            var genres = await context.Genres
                .Where(g => dtoGenreIds.Contains(g.Id))
                .ToListAsync(cancellationToken);

            // Check if all genres were found
            if (genres.Count != dtoGenreIds.Count)
                return Result<Unit>.Failure("One or more genres not found.", 404);

            // Update the genres
            var genresToRemove = movie.Genres.Where(g => !dtoGenreIds.Contains(g.Id)).ToList();
            foreach (var genre in genresToRemove)
                movie.Genres.Remove(genre);

            var genresToAdd = genres.Where(g => !dbGenreIds.Contains(g.Id)).ToList();
            foreach (var genre in genresToAdd)
                movie.Genres.Add(genre);
        }

        var result = await context.SaveChangesAsync(cancellationToken) > 0;

        return result
            ? Result<Unit>.Success(Unit.Value)
            : Result<Unit>.Failure("Failed to update movie.", 400);
    }
}
