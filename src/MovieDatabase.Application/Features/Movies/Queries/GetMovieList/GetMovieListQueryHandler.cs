using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.DTOs;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Movies.Queries.GetMovieList;

public class GetMovieListQueryHandler(AppDbContext context) 
    : IRequestHandler<GetMovieListQuery, Result<IList<MovieDto>>>
{
    public async Task<Result<IList<MovieDto>>> Handle(GetMovieListQuery request, 
        CancellationToken cancellationToken)
    {
        var movies = await context.Movies
            .Include(g => g.Genres)
            .Include(c => c.OriginCountries)
            .ToListAsync(cancellationToken);

        return Result<IList<MovieDto>>.Success(movies.Adapt<IList<MovieDto>>());
    }
}
