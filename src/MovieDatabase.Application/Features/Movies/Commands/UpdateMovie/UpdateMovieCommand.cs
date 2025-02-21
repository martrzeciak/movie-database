using MediatR;
using MovieDatabase.Application.Abstractions.CQRS;
using MovieDatabase.Application.Features.Movies.DTOs;

namespace MovieDatabase.Application.Features.Movies.Commands.UpdateMovie;

public class UpdateMovieCommand : ICommand<Unit>
{
    public required Guid Id { get; set; }
    public required UpdateMovieDto UpdateMovieDto { get; set; }
}
