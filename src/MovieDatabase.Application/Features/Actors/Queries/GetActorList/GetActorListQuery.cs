using MovieDatabase.Application.Abstractions.CQRS;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Actors.DTOs;

namespace MovieDatabase.Application.Features.Actors.Queries.GetActorList;

public class GetActorListQuery : IQuery<PagedList<ActorDto>>
{
    public required PagingParams Params { get; set; }
    //public string Key => $"GetActorListQuery_{Params.PageNumber}_{Params.PageSize}";
    //public TimeSpan? Expiration => null;
}
