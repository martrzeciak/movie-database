﻿using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Movies.Commands.CreateMovie;
using MovieDatabase.Application.Features.Movies.Commands.DeleteMovie;
using MovieDatabase.Application.Features.Movies.Commands.UpdateMovie;
using MovieDatabase.Application.Features.Movies.DTOs;
using MovieDatabase.Application.Features.Movies.Queries.GetMovieDetails;
using MovieDatabase.Application.Features.Movies.Queries.GetMovieList;
using MovieDatabase.Application.Features.Movies.Shared;

namespace MovieDatabase.API.Controllers;

public class MoviesController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<PagedList<MovieQueryDto>>> GetMovies([FromQuery] PagingParams pagingParams)
    {
        return HandlePagedResult(await Mediator.Send(new GetMovieListQuery { Params = pagingParams }));
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<MovieQueryDto>> GetMovie(Guid id)
    {
        return HandleResult(await Mediator.Send(new GetMovieDetailsQuery { Id = id }));
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateMovie(CreateMovieDto movie)
    {
        return HandleResult(await Mediator.Send(new CreateMovieCommand { CreateMovieDto = movie }));
    }

    [HttpPut("{id:Guid}")]
    public async Task<ActionResult> UpdateMovie(Guid id, UpdateMovieDto movie)
    {
        return HandleResult(await Mediator.Send(new UpdateMovieCommand { Id = id, UpdateMovieDto = movie }));
    }

    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> DeleteMovie(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteMovieCommand { Id = id }));
    }
}
    