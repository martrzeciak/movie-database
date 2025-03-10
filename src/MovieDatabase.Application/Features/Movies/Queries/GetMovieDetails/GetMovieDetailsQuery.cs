﻿using MovieDatabase.Application.Abstractions.Caching;
using MovieDatabase.Application.Abstractions.CQRS;
using MovieDatabase.Application.Features.Movies.Shared.DTOs;

namespace MovieDatabase.Application.Features.Movies.Queries.GetMovieDetails;

public class GetMovieDetailsQuery : IQuery<MovieQueryDto>
{
    public required Guid Id { get; set; }
    //public string Key => $"GetMovieDetailsQuery_{Id}";
    //public TimeSpan? Expiration => null;
}
