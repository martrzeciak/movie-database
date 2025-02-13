using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Application.DTOs;
using MovieDatabase.Application.Features.Actors.Queries.GetActorList;

namespace MovieDatabase.API.Controllers;

public class ActorController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IList<ActorDto>>> GetActors()
    {
        return HandleResult(await Mediator.Send(new GetActorListQuery()));
    }
}
