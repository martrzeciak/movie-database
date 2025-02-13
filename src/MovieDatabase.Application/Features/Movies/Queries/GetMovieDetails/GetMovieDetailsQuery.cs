using MediatR;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.DTOs;

namespace MovieDatabase.Application.Features.Movies.Queries.GetMovieDetails;

public class GetMovieDetailsQuery : IRequest<Result<MovieDto>>
{
    public required Guid Id { get; set; }
}
