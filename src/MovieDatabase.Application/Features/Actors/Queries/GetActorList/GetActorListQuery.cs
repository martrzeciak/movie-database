using MediatR;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Actors.DTOs;

namespace MovieDatabase.Application.Features.Actors.Queries.GetActorList;

public class GetActorListQuery : IRequest<Result<PagedList<ActorDto>>>
{
    public required PagingParams Params { get; set; }
}
