using MediatR;
using MovieDatabase.Application.Abstractions.CQRS;

namespace MovieDatabase.Application.Features.Movies.Commands.DeleteMovie;

public class DeleteMovieCommand : ICommand<Unit>
{
    public required Guid Id { get; set; }
}
