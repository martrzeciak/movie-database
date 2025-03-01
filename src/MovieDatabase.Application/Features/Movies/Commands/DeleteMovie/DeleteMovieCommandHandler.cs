using MediatR;
using MovieDatabase.Application.Abstractions.CQRS;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Common.Errors;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Movies.Commands.DeleteMovie;

public class DeleteMovieCommandHandler(AppDbContext context)
    : ICommandHandler<DeleteMovieCommand, Unit>
{
    public async Task<Result<Unit>> Handle(DeleteMovieCommand request,
        CancellationToken cancellationToken)
    {
        var movie = await context.Movies.FindAsync([request.Id], cancellationToken);

        if (movie == null) return Result.Failure<Unit>(MovieErrors.NotFound(request.Id));

        context.Movies.Remove(movie);

        var result = await context.SaveChangesAsync(cancellationToken) > 0;

        return result
            ? Result.Success(Unit.Value)
            : Result.Failure<Unit>(MovieErrors.DeletionFailed);

    }
}
