using Mapster;
using MediatR;
using MovieDatabase.Application.Common;
using MovieDatabase.Domain.Entities;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Movies.Commands.CreateMovie;

public class CreateMovieCommandHandler(AppDbContext context)
    : IRequestHandler<CreateMovieCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateMovieCommand request, 
        CancellationToken cancellationToken)
    {
        var movie = request.CreateMovieDto.Adapt<Movie>();

        context.Movies.Add(movie);

        var result = await context.SaveChangesAsync(cancellationToken) > 0;

        return result
            ? Result<string>.Success(movie.Id.ToString())
            : Result<string>.Failure("Failed to create movie.", 400);
    }
}