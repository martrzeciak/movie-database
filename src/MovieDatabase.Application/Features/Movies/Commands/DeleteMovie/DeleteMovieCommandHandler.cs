using MediatR;
using MovieDatabase.Application.Common;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Movies.Commands.DeleteMovie;

public class DeleteMovieCommandHandler(AppDbContext context)
    : IRequestHandler<DeleteMovieCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteMovieCommand request,
        CancellationToken cancellationToken)
    {
        var movie = await context.Movies.FindAsync(request.Id, cancellationToken);

        if (movie == null) return Result<Unit>.Failure("Movie not found.", 404);

        context.Movies.Remove(movie);

        var result = await context.SaveChangesAsync(cancellationToken) > 0;

        return result
            ? Result<Unit>.Success(Unit.Value)
            : Result<Unit>.Failure("Failed to delete movie.", 400);

    }
}
