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
        if (!result.IsSuccess && result.Code == 404) return NotFound(result.Error);

        if (result.IsSuccess && result.Value != null) return Ok(result.Value);

        return BadRequest(result.Error);
    }

    protected ActionResult HandlePagedResult<T>(Result<PagedList<T>> result)
    {
        if (!result.IsSuccess && result.Code == 404) return NotFound(result.Error);

        if (result.IsSuccess && result.Value != null)
        {
            Response.AddPaginationHeader(result.Value.CurrentPage,
                result.Value.PageSize, result.Value.TotalCount, result.Value.TotalPages);

            return Ok(result.Value);
        }

        return BadRequest(result.Error);
    }
}
