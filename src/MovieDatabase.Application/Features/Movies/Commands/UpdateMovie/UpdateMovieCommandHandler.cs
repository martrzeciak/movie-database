using Mapster;
using MediatR;
using MovieDatabase.Application.Common;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Movies.Commands.UpdateMovie;

public class UpdateMovieCommandHandler(AppDbContext context)
    : IRequestHandler<UpdateMovieCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateMovieCommand request,
        CancellationToken cancellationToken)
    {
        var movie = await context.Movies.FindAsync([request.Id], cancellationToken);

        if (movie == null) return Result<Unit>
                .Failure($"Movie with id = {request.Id} not found.", 404);

        request.Id = movie.Id;

        request.MovieDto.Adapt(movie);

        var result = await context.SaveChangesAsync(cancellationToken) > 0;

        return result
            ? Result<Unit>.Success(Unit.Value)
            : Result<Unit>.Failure("Failed to update movie.", 400);
    }
}
