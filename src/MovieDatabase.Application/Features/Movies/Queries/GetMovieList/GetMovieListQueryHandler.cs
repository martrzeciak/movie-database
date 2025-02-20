using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Movies.Shared;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Movies.Queries.GetMovieList;

public class GetMovieListQueryHandler(AppDbContext context)
    : IRequestHandler<GetMovieListQuery, Result<PagedList<BaseMovieDto>>>
{
    public async Task<Result<PagedList<BaseMovieDto>>> Handle(GetMovieListQuery request,
        CancellationToken cancellationToken)
    {
        var query = context.Movies
            .Include(g => g.Genres)
            .Include(c => c.OriginCountries)
            .ProjectToType<BaseMovieDto>();

        return Result<PagedList<BaseMovieDto>>.Success(await PagedList<BaseMovieDto>
            .CreateAsync(query, request.Params.PageNumber, request.Params.PageSize));
    }
}
