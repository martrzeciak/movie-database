using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Common;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Movies.Queries.GetMovieList;

public class GetMovieList
{
    public class Query : IRequest<Result<IList<MovieDto>>>
    {
    }

    public class Handler(AppDbContext dbContext) : IRequestHandler<Query, Result<IList<MovieDto>>>
    {
        public async Task<Result<IList<MovieDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var movies = await dbContext.Movies.ToListAsync(cancellationToken);
            return Result<IList<MovieDto>>.Success(movies.Adapt<IList<MovieDto>>());
        }
    }
}
