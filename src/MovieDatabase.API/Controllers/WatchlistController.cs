using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Application.Features.Watchlist.Commands.AddMovieToWatchlist;
using MovieDatabase.Application.Features.Watchlist.Commands.RemoveMovieFromWatchlist;

namespace MovieDatabase.API.Controllers;

public class WatchlistController : BaseApiController
{
    [HttpPost("movie/{movieId:Guid}")]
    public async Task<ActionResult> AddMovieToWatchlist(Guid movieId)
    {
        return HandleResult(await Mediator.Send(new AddMovieToWatchlistCommand { MovieId = movieId }));
    }

    [HttpDelete("movie/{movieId:Guid}")]
    public async Task<ActionResult> RemoveMovieFromWatchlist(Guid movieId)
    {
        return HandleResult(await Mediator.Send(new RemoveMovieFromWatchlistCommand { MovieId = movieId }));
    }
}
