using MovieDatabase.Application.Abstractions.CQRS;
using MovieDatabase.Application.Features.Movies.Shared.DTOs;

namespace MovieDatabase.Application.Features.Movies.Queries.GetMovieCast;

public class GetMovieCastQuery : IQuery<IEnumerable<ActorQueryDto>>
{
    public required Guid Id { get; set; }
}
