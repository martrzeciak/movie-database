using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Movies.DTOs;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Movies.Queries.GetMovieDetails;

public class GetMovieDetailsQueryHandler(AppDbContext context)
    : IRequestHandler<GetMovieDetailsQuery, Result<MovieDto>>
{
    public async Task<Result<MovieDto>> Handle(GetMovieDetailsQuery request, 
        CancellationToken cancellationToken)
    {
        var movie = await context.Movies
            .Include(g => g.Genres)
            .Include(c => c.OriginCountries)
            .FirstOrDefaultAsync(m => m.Id == request.Id);

        if (movie == null) return Result<MovieDto>.Failure("Movie not found.", 404);

        return Result<MovieDto>.Success(movie.Adapt<MovieDto>());
    }
}
