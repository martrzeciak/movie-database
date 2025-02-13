using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.DTOs;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Actors.Queries.GetActorDetails;

public class GetActorDetailsQueryHandler(AppDbContext context)
    : IRequestHandler<GetActorDetailsQuery, Result<ActorDto>>
{
    public async Task<Result<ActorDto>> Handle(GetActorDetailsQuery request, 
        CancellationToken cancellationToken)
    {
        var actor = await context.Actors
            .Include(m => m.Movies)
            .FirstOrDefaultAsync(a => a.Id == request.Id);

        if (actor == null) return Result<ActorDto>.Failure("Actor not found.", 404);

        return Result<ActorDto>.Success(actor.Adapt<ActorDto>());
    }
}
