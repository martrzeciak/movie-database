using MovieDatabase.Application.Abstractions.Caching;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Actors.DTOs;

namespace MovieDatabase.Application.Features.Actors.Queries.GetActorDetails;

public class GetActorDetailsQuery : ICachedQuery<Result<ActorDto>>
{
    public required Guid Id { get; set; }
    public string Key => $"GetActorDetailsQuery_{Id}";
    public TimeSpan? Expiration => null;
}
