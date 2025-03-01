using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.API.Extensions;
using MovieDatabase.Application.Common;

namespace MovieDatabase.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator Mediator =>
        _mediator ??= HttpContext.RequestServices.GetService<IMediator>()
            ?? throw new InvalidOperationException("IMediator service is unavailable");

    protected ActionResult HandleResult<T>(Result<T> result)
    {
        if (result.IsFailure)
        {
            return result.Error.Code switch
            {
                "404" => NotFound(result.Error),
                "400" => BadRequest(result.Error),
                "401" => Unauthorized(result.Error),
                _ => StatusCode(500, result.Error)
            };
        }

        return Ok(result.Value);
    }

    protected ActionResult HandlePagedResult<T>(Result<PagedList<T>> result)
    {
        if (result.IsFailure)
        {
            return result.Error.Code switch
            {
                "404" => NotFound(result.Error),
                "400" => BadRequest(result.Error),
                "401" => Unauthorized(result.Error),
                _ => StatusCode(500, result.Error)
            };
        }

        Response.AddPaginationHeader(result.Value.CurrentPage,
            result.Value.PageSize, result.Value.TotalCount, result.Value.TotalPages);

        return Ok(result.Value);
    }
}
