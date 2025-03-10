﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Movies.Commands.CreateMovie;
using MovieDatabase.Application.Features.Movies.Commands.DeleteMovie;
using MovieDatabase.Application.Features.Movies.Commands.UpdateMovie;
using MovieDatabase.Application.Features.Movies.DTOs;
using MovieDatabase.Application.Features.Movies.Queries.GetMovieCast;
using MovieDatabase.Application.Features.Movies.Queries.GetMovieDetails;
using MovieDatabase.Application.Features.Movies.Queries.GetMovieList;
using MovieDatabase.Application.Features.Movies.Shared.DTOs;

namespace MovieDatabase.API.Controllers;

public class MoviesController : BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<PagedList<MovieQueryDto>>> GetMovies([FromQuery] PagingParams pagingParams)
    {
        return HandlePagedResult(await Mediator.Send(new GetMovieListQuery { Params = pagingParams }));
    }

    [AllowAnonymous]
    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<MovieQueryDto>> GetMovie(Guid id)
    {
        return HandleResult(await Mediator.Send(new GetMovieDetailsQuery { Id = id }));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateMovie(CreateMovieDto movie)
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

    [AllowAnonymous]
    [HttpGet("{id:Guid}/cast")]
    public async Task<ActionResult> AddCastMember(Guid id)
    {
        return HandleResult(await Mediator.Send(new GetMovieCastQuery { Id = id }));
    }
}

