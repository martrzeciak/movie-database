using MediatR;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Movies.Shared;

namespace MovieDatabase.Application.Features.Movies.Queries.GetMovieDetails;

public class GetMovieDetailsQuery : IRequest<Result<BaseMovieDto>>
{
    public required Guid Id { get; set; }
}
