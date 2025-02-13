using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Application.DTOs;
using MovieDatabase.Application.Features.Movies.Queries.GetMovieList;

namespace MovieDatabase.API.Controllers;

public class MovieController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IList<MovieDto>>> GetMovies()
    {
        return HandleResult(await Mediator.Send(new GetMovieListQuery()));
    }
}
