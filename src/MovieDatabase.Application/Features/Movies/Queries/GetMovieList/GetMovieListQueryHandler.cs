using Mapster;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Abstractions.CQRS;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Movies.Shared.DTOs;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Movies.Queries.GetMovieList;

public class GetMovieListQueryHandler(AppDbContext context)
    : IQueryHandler<GetMovieListQuery, PagedList<MovieQueryDto>>
{
    public async Task<Result<PagedList<MovieQueryDto>>> Handle(GetMovieListQuery request,
        CancellationToken cancellationToken)
    {
        var query = context.Movies
            .AsNoTracking()
            .ProjectToType<MovieQueryDto>();

        return Result<PagedList<MovieQueryDto>>.Success(await PagedList<MovieQueryDto>
            .CreateAsync(query, request.Params.PageNumber, request.Params.PageSize));
    }
}
