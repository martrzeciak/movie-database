using FluentValidation;
using MovieDatabase.Application.Features.Movies.DTOs;
using MovieDatabase.Application.Features.Movies.Shared.Validators;

namespace MovieDatabase.Application.Features.Movies.Commands.UpdateMovie;

public class UpdateMovieCommandValidator : BaseMovieValidator<UpdateMovieCommand, UpdateMovieDto>
{
    public UpdateMovieCommandValidator() : base(movie => movie.UpdateMovieDto)
    {
        RuleFor(x => x.UpdateMovieDto.Id)
            .NotEmpty().WithMessage("Id is required.");
    }
}
