using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Movies.Queries.GetMovieCast;
using MovieDatabase.Application.Features.Movies.Shared.DTOs;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Movies.Queries.GetMovieCastl;

public class GetMovieCastQueryHandler(AppDbContext context)
    : IRequestHandler<GetMovieCastQuery, Result<IEnumerable<ActorQueryDto>>>
{
    public async Task<Result<IEnumerable<ActorQueryDto>>> Handle(GetMovieCastQuery request,
        CancellationToken cancellationToken)
    {
        var movieCast = await context.Actors
            .Where(a => a.Movies.Any(m => m.Id == request.Id))
            .AsNoTracking()
            .ProjectToType<ActorQueryDto>()
            .ToListAsync(cancellationToken);

        return Result<IEnumerable<ActorQueryDto>>
            .Success(movieCast.Adapt<IEnumerable<ActorQueryDto>>());
    }
}
