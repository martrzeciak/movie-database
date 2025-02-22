using MovieDatabase.Application.Abstractions.CQRS;
using MovieDatabase.Application.Features.Actors.DTOs;

namespace MovieDatabase.Application.Features.Actors.Queries.GetActorDetails;

public class GetActorDetailsQuery : IQuery<ActorDto>
{
    public required Guid Id { get; set; }
    //public string Key => $"GetActorDetailsQuery_{Id}";
    //public TimeSpan? Expiration => null;
}
