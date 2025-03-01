using Mapster;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Abstractions.CQRS;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Common.Errors;
using MovieDatabase.Application.Features.Movies.Shared.DTOs;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Movies.Queries.GetMovieDetails;

public class GetMovieDetailsQueryHandler(AppDbContext context)
    : IQueryHandler<GetMovieDetailsQuery, MovieQueryDto>
{
    public async Task<Result<MovieQueryDto>> Handle(GetMovieDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var movie = await context.Movies
            .AsNoTracking()
            .ProjectToType<MovieQueryDto>()
            .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

        if (movie is null)
            return Result.Failure<MovieQueryDto>(MovieErrors.NotFound(request.Id));

        return Result.Success(movie);
    }
}
