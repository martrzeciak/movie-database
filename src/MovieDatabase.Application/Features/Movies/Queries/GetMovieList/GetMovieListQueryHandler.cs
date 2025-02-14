using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Movies.DTOs;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Movies.Queries.GetMovieList;

public class GetMovieListQueryHandler(AppDbContext context)
    : IRequestHandler<GetMovieListQuery, Result<PagedList<MovieDto>>>
{
    public async Task<Result<PagedList<MovieDto>>> Handle(GetMovieListQuery request,
        CancellationToken cancellationToken)
    {
        var query = context.Movies
            .Include(g => g.Genres)
            .Include(c => c.OriginCountries)
            .ProjectToType<MovieDto>();

        return Result<PagedList<MovieDto>>.Success(await PagedList<MovieDto>
            .CreateAsync(query, request.Params.PageNumber, request.Params.PageSize));
    }
}
