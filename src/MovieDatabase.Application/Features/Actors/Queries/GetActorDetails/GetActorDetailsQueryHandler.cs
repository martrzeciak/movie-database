using Mapster;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Abstractions.CQRS;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Common.Errors;
using MovieDatabase.Application.Features.Actors.DTOs;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Actors.Queries.GetActorDetails;

public class GetActorDetailsQueryHandler(AppDbContext context)
    : IQueryHandler<GetActorDetailsQuery, ActorDto>
{
    public async Task<Result<ActorDto>> Handle(GetActorDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var actor = await context.Actors
            .Include(m => m.Movies)
            .FirstOrDefaultAsync(a => a.Id == request.Id);

        if (actor == null) 
            return Result.Failure<ActorDto>(ActorErrors.NotFound(request.Id));

        return Result.Success(actor.Adapt<ActorDto>());
    }
}
