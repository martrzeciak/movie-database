﻿using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Common;
using MovieDatabase.Domain.Entities;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Movies.Commands.CreateMovie;

public class CreateMovieCommandHandler(AppDbContext context)
    : IRequestHandler<CreateMovieCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateMovieCommand request, 
        CancellationToken cancellationToken)
    {
        // Validation
        if (request.CreateMovieDto.Genres.Count == 0)
            return Result<Guid>.Failure("Genres not provided.", 400);

        if (request.CreateMovieDto.OriginCountries.Count == 0)
            return Result<Guid>.Failure("Origin countries not provided.", 400);


        // Adapt the CreateMovieDto to a Movie entity
        var movie = request.CreateMovieDto.Adapt<Movie>();

        // Get the genre ids from the dto
        var dtoGenreIds = request.CreateMovieDto.Genres
            .Select(g => g.Id)
            .ToHashSet();

        // Get the genres from the database
        var dbGenreList = await context.Genres
            .Where(g => dtoGenreIds.Contains(g.Id))
            .ToListAsync(cancellationToken);

        var dbGenreIds = dbGenreList
            .Select(g => g.Id)
            .ToHashSet();

        // Check if all genres were found
        if (!dtoGenreIds.SetEquals(dbGenreIds))
            return Result<Guid>.Failure("One or more genres not found.", 404);

        // Add genres to the movie
        movie.Genres = dbGenreList;


        // Get the country ids from the dto
        var dtoCountryIds = request.CreateMovieDto.OriginCountries
            .Select(c => c.Id)
            .ToHashSet();

        // Get the countries from the database
        var dbCountryList = await context.Countries
            .Where(c => dtoCountryIds.Contains(c.Id))
            .ToListAsync(cancellationToken);

       var dbCountryIds = dbCountryList
            .Select(c => c.Id)
            .ToHashSet();

        // Check if all countries were found
        if (!dtoCountryIds.SetEquals(dbCountryIds))
            return Result<Guid>.Failure("One or more countries not found.", 404);

        // Add countries to the movie
        movie.OriginCountries = dbCountryList;


        // Add the movie to the context
        context.Movies.Add(movie);

        var result = await context.SaveChangesAsync(cancellationToken) > 0;

        return result
            ? Result<Guid>.Success(movie.Id)
            : Result<Guid>.Failure("Failed to create movie.", 400);
    }
}