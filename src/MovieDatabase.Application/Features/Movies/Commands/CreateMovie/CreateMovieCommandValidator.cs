using MovieDatabase.Application.Features.Movies.DTOs;
using MovieDatabase.Application.Features.Movies.Shared;

namespace MovieDatabase.Application.Features.Movies.Commands.CreateMovie;

public class CreateMovieCommandValidator : BaseMovieValidator<CreateMovieCommand, CreateMovieDto>
{
    public CreateMovieCommandValidator() : base(x => x.CreateMovieDto)
    {
        
    }
}
