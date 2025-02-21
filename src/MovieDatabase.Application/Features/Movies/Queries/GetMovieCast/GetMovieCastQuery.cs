using MediatR;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Movies.Shared.DTOs;

namespace MovieDatabase.Application.Features.Movies.Queries.GetMovieCast;

public class GetMovieCastQuery : IRequest<Result<IEnumerable<ActorQueryDto>>>
{
    public required Guid Id { get; set; }
}
