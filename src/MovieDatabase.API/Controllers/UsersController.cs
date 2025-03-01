using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Users.DTOs;
using MovieDatabase.Application.Features.Users.Queries.GetUserDetails;
using MovieDatabase.Application.Features.Users.Queries.GetUserList;

namespace MovieDatabase.API.Controllers;

public class UsersController : BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<PagedList<UserQueryDto>>> GetUserList([FromQuery] PagingParams pagingParams)
    {
        return HandlePagedResult(await Mediator.Send(new GetUserListQuery { Params = pagingParams }));
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<UserQueryDto>> GetUser(string id)
    {
        return HandleResult(await Mediator.Send(new GetUserDetailsQuery { Id = id }));
    }
}
