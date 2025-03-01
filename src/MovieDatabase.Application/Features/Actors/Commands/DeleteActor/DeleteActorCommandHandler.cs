using MediatR;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Common.Errors;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Actors.Commands.DeleteActor;

public class DeleteActorCommandHandler(AppDbContext context)
    : IRequestHandler<DeleteActorCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteActorCommand request, 
        CancellationToken cancellationToken)
    {
        var actor = await context.Actors.FindAsync([request.Id], cancellationToken);

        if (actor == null) return Result.Failure<Unit>(ActorErrors.NotFound(request.Id));

        context.Actors.Remove(actor);

        var result = await context.SaveChangesAsync(cancellationToken) > 0;

        return result
            ? Result.Success(Unit.Value)
            : Result.Failure<Unit>(ActorErrors.DeletionFailed);

    }
}
