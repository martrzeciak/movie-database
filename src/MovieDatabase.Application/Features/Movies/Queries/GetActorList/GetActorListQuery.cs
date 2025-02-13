using MediatR;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.DTOs;

namespace MovieDatabase.Application.Features.Movies.Queries.GetActorList;

public class GetActorListQuery : IRequest<Result<IList<ActorDto>>>
{
}
