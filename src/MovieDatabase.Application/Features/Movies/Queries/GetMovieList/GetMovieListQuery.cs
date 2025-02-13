using MediatR;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.DTOs;

namespace MovieDatabase.Application.Features.Movies.Queries.GetMovieList;

public class GetMovieListQuery : IRequest<Result<PagedList<MovieDto>>>
{
    public required PagingParams Params { get; set; }
}
