using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.DTOs;
using MovieDatabase.Application.Features.Movies.Queries.GetMovieList;

namespace MovieDatabase.API.Controllers;

public class MovieController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<PagedList<MovieDto>>> GetMovies(
        [FromQuery] PagingParams pagingParams)
    {
        return HandlePagedResult(await Mediator.Send(
            new GetMovieListQuery { Params = pagingParams }));
    }
}
