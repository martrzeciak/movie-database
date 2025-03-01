using MediatR;
using MovieDatabase.Application.Abstractions.CQRS;

namespace MovieDatabase.Application.Features.Watchlist.Commands.RemoveMovieFromWatchlist;

public class RemoveMovieFromWatchlistCommand : ICommand<Unit>
{
    public required Guid MovieId { get; set; }
}
