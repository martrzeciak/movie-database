using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.API.Models;
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
        if (!result.IsSuccess)
        {
            switch (result.Code)
            {
                case 404:
                    return NotFound();
                case 400:
                    return BadRequest(new ErrorDetail 
                    { 
                        Code = result.Code, 
                        Message = result.Error ?? "An unknown error occurred" 
                    });
                case 401:
                    return Unauthorized();
                case 403:
                    return Forbid();
                default:
                    return StatusCode(result.Code, new ErrorDetail 
                    { 
                        Code = result.Code, 
                        Message = result.Error ?? "An unknown error occurred" 
                    });
            }
        }

        if (result.IsSuccess && result.Value != null) 
            return Ok(result.Value);

        return NoContent();
    }
}
