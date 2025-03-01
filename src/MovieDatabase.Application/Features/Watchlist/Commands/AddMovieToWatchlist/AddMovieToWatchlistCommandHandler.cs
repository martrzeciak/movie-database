using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Abstractions.CQRS;
using MovieDatabase.Application.Abstractions.User;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Common.Errors;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Watchlist.Commands.AddMovieToWatchlist;

public class AddMovieToWatchlistCommandHandler(AppDbContext context, 
    ICurrentUserService currentUserService)
    : ICommandHandler<AddMovieToWatchlistCommand, Unit>
{
    public async Task<Result<Unit>> Handle(AddMovieToWatchlistCommand request, 
        CancellationToken cancellationToken)
    {
        var isUserLoggedIn = currentUserService.IsUserLoggedIn();

        if (!isUserLoggedIn) return Result.Failure<Unit>(UserErrors.NotLoggedIn);

        var currentUserId = currentUserService.GetUserId();

        var user = await context.Users
            .Include(w => w.MovieWatchlist)
            .FirstOrDefaultAsync(u => u.Id == currentUserId, cancellationToken);

        if (user is null) 
            return Result.Failure<Unit>(UserErrors.NotFound(currentUserId!));

        var movie = await context.Movies.FindAsync([request.MovieId], cancellationToken);

        if (movie is null) return Result.Failure<Unit>(MovieErrors.NotFound(request.MovieId));

        var isMovieAlreadyInWatchlist = user.MovieWatchlist
            .Any(m => m.Id == request.MovieId);

        if (isMovieAlreadyInWatchlist)
            return Result.Failure<Unit>(MovieErrors.AlreadyInWatchlist(request.MovieId));

        user.MovieWatchlist.Add(movie);

        var result = await context.SaveChangesAsync(cancellationToken) > 0;

        return result 
            ? Result.Success(Unit.Value)
            : Result.Failure<Unit>(MovieErrors.AddToWatchlistFailed);
    }
}
