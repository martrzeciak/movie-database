using MovieDatabase.Application.Abstractions.CQRS;
using MovieDatabase.Application.Features.Movies.DTOs;

namespace MovieDatabase.Application.Features.Movies.Commands.CreateMovie;

public class CreateMovieCommand : ICommand<Guid>
{
    public required CreateMovieDto CreateMovieDto { get; set; }
}
