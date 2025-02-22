using Mapster;
using MovieDatabase.Application.Abstractions.CQRS;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Actors.DTOs;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Actors.Queries.GetActorList;

public class GetActorListQueryHandler(AppDbContext context)
    : IQueryHandler<GetActorListQuery, PagedList<ActorDto>>
{
    public async Task<Result<PagedList<ActorDto>>> Handle(GetActorListQuery request,
        CancellationToken cancellationToken)
    {
        var query = context.Actors
            .ProjectToType<ActorDto>();

        return Result<PagedList<ActorDto>>.Success(await PagedList<ActorDto>
            .CreateAsync(query, request.Params.PageNumber, request.Params.PageSize));
    }
}
