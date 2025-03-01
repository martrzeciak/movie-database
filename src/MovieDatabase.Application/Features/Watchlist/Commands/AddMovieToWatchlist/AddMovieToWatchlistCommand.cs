using MediatR;
using MovieDatabase.Application.Abstractions.CQRS;

namespace MovieDatabase.Application.Features.Watchlist.Commands.AddMovieToWatchlist;

public class AddMovieToWatchlistCommand : ICommand<Unit>
{
    public required Guid MovieId { get; set; }
}
