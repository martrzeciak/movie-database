﻿using MediatR;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Movies.DTOs;

namespace MovieDatabase.Application.Features.Movies.Commands.CreateMovie;

public class CreateMovieCommand : IRequest<Result<string>>
{
    public required CreateMovieDto CreateMovieDto { get; set; }
}
