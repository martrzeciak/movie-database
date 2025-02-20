using MediatR;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Movies.Shared;

namespace MovieDatabase.Application.Features.Movies.Queries.GetMovieList;

public class GetMovieListQuery : IRequest<Result<PagedList<BaseMovieDto>>>
{
    public required PagingParams Params { get; set; }
}
