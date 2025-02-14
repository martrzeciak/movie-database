using MediatR;
using MovieDatabase.Application.Common;

namespace MovieDatabase.Application.Features.Movies.Commands.DeleteMovie;

public class DeleteMovieCommand : IRequest<Result<Unit>>
{
    public required Guid Id { get; set; }
}
