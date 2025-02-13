using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.DTOs;
using MovieDatabase.Application.Features.Actors.Queries.GetActorDetails;
using MovieDatabase.Application.Features.Actors.Queries.GetActorList;

namespace MovieDatabase.API.Controllers;

public class ActorController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<PagedList<ActorDto>>> GetActors(
        [FromQuery] PagingParams pagingParams)
    {
        return HandlePagedResult(await Mediator.Send(new GetActorListQuery { Params = pagingParams }));
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<ActorDto>> GetActor(Guid id)
    {
        return HandleResult(await Mediator.Send(new GetActorDetailsQuery { Id = id }));
    }
}
