using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Movies.Shared;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Movies.Queries.GetMovieDetails;

public class GetMovieDetailsQueryHandler(AppDbContext context)
    : IRequestHandler<GetMovieDetailsQuery, Result<BaseMovieDto>>
{
    public async Task<Result<BaseMovieDto>> Handle(GetMovieDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var movie = await context.Movies
            .Include(g => g.Genres)
            .Include(c => c.OriginCountries)
            .FirstOrDefaultAsync(m => m.Id == request.Id);

        if (movie == null) return Result<BaseMovieDto>.Failure("Movie not found.", 404);

        return Result<BaseMovieDto>.Success(movie.Adapt<BaseMovieDto>());
    }
}
