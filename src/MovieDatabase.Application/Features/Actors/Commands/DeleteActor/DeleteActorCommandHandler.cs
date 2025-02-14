using MediatR;
using MovieDatabase.Application.Common;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Actors.Commands.DeleteActor;

public class DeleteActorCommandHandler(AppDbContext context)
    : IRequestHandler<DeleteActorCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteActorCommand request, 
        CancellationToken cancellationToken)
    {
        var actor = await context.Actors.FindAsync(request.Id, cancellationToken);

        if (actor == null) return Result<Unit>
                .Failure($"Actor with id = {request.Id} not found.", 404);

        context.Actors.Remove(actor);

        var result = await context.SaveChangesAsync(cancellationToken) > 0;

        return result
            ? Result<Unit>.Success(Unit.Value)
            : Result<Unit>.Failure("Failed to delete actor.", 400);

    }
}
