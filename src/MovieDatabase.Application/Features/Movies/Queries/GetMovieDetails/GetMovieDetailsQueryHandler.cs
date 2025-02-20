using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Movies.Shared.DTOs;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Movies.Queries.GetMovieDetails;

public class GetMovieDetailsQueryHandler(AppDbContext context)
    : IRequestHandler<GetMovieDetailsQuery, Result<MovieQueryDto>>
{
    public async Task<Result<MovieQueryDto>> Handle(GetMovieDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var movie = await context.Movies
            .Include(g => g.Genres)
            .Include(c => c.OriginCountries)
            .FirstOrDefaultAsync(m => m.Id == request.Id);

        if (movie == null) return Result<MovieQueryDto>.Failure("Movie not found.", 404);

        return Result<MovieQueryDto>.Success(movie.Adapt<MovieQueryDto>());
    }
}
