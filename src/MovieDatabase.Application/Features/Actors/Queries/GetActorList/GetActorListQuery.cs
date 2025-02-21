using MovieDatabase.Application.Abstractions.Caching;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Actors.DTOs;

namespace MovieDatabase.Application.Features.Actors.Queries.GetActorList;

public class GetActorListQuery : ICachedQuery<Result<PagedList<ActorDto>>>
{
    public required PagingParams Params { get; set; }
    public string Key => $"GetActorListQuery_{Params.PageNumber}_{Params.PageSize}";
    public TimeSpan? Expiration => null;
}
