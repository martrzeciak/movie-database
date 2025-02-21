using MovieDatabase.Application.Abstractions.Caching;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Movies.Shared.DTOs;

namespace MovieDatabase.Application.Features.Movies.Queries.GetMovieList;

public class GetMovieListQuery : ICachedQuery<PagedList<MovieQueryDto>>
{
    public required PagingParams Params { get; set; }
    public string Key => $"GetMovieListQuery_{Params.PageNumber}_{Params.PageSize}";
    public TimeSpan? Expiration => null;
}
