using MediatR;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.DTOs;

namespace MovieDatabase.Application.Features.Actors.Queries.GetActorList;

public class GetActorListQuery : IRequest<Result<IList<ActorDto>>>
{
}
