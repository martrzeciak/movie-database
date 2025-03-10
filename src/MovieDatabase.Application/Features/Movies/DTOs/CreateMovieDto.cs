﻿using Mapster;
using MovieDatabase.Application.Features.Movies.Shared.DTOs;

namespace MovieDatabase.Application.Features.Movies.DTOs;

public class CreateMovieDto : BaseMovieDto
{
    [AdaptIgnore]
    public List<GenreDto> Genres { get; set; } = [];
    
    [AdaptIgnore]
    public List<CountryDto> OriginCountries { get; set; } = [];
}
