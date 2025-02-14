using MediatR;
using MovieDatabase.Application.Common;

namespace MovieDatabase.Application.Features.Actors.Commands.DeleteActor;

public class DeleteActorCommand : IRequest<Result<Unit>>
{
    public required Guid Id { get; set; }
}
