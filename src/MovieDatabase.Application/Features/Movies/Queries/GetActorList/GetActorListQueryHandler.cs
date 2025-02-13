using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.DTOs;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Movies.Queries.GetActorList;

public class GetActorListQueryHandler(AppDbContext context) 
    : IRequestHandler<GetActorListQuery, Result<IList<ActorDto>>>
{
    public async Task<Result<IList<ActorDto>>> Handle(GetActorListQuery request, 
        CancellationToken cancellationToken)
    {
        var actors = await context.Actors.ToListAsync(cancellationToken);
        return Result<IList<ActorDto>>.Success(actors.Adapt<IList<ActorDto>>());
    }
}
