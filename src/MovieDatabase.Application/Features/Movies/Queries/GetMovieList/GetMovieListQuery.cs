using MovieDatabase.Application.Abstractions.CQRS;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Movies.Shared.DTOs;

namespace MovieDatabase.Application.Features.Movies.Queries.GetMovieList;

public class GetMovieListQuery : IQuery<PagedList<MovieQueryDto>>
{
    public required PagingParams Params { get; set; }
    //public string Key => $"GetMovieListQuery_{Params.PageNumber}_{Params.PageSize}";
    //public TimeSpan? Expiration => null;
}
