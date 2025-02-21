using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Movies.Shared.DTOs;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Movies.Queries.GetMovieDetails;

public class GetMovieDetailsQueryHandler(AppDbContext context)
    : IRequestHandler<GetMovieDetailsQuery, Result<MovieQueryDto>>
{
    public async Task<Result<MovieQueryDto>> Handle(GetMovieDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var movie = await context.Movies
            .AsNoTracking()
            .ProjectToType<MovieQueryDto>()
            .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

        if (movie == null) return Result<MovieQueryDto>
                .Failure($"Movie with id = {request.Id} not found.", 404);

        return Result<MovieQueryDto>.Success(movie);
    }
}
