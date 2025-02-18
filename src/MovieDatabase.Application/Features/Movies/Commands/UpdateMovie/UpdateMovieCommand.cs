using MediatR;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Movies.DTOs;

namespace MovieDatabase.Application.Features.Movies.Commands.UpdateMovie;

public class UpdateMovieCommand : IRequest<Result<Unit>>
{
    public required Guid Id { get; set; }
    public required MovieDto MovieDto { get; set; }
}
