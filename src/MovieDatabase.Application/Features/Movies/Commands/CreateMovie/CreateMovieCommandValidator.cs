using FluentValidation;
using MovieDatabase.Application.Features.Movies.DTOs;
using MovieDatabase.Application.Features.Movies.Shared.Validators;

namespace MovieDatabase.Application.Features.Movies.Commands.CreateMovie;

public class CreateMovieCommandValidator : BaseMovieValidator<CreateMovieCommand, CreateMovieDto>
{
    public CreateMovieCommandValidator() : base(x => x.CreateMovieDto)
    {
        RuleFor(x => x.CreateMovieDto.Genres)
            .NotEmpty().WithMessage("At least one genre is required.");

        RuleForEach(x => x.CreateMovieDto.Genres)
            .SetValidator(new GenreValidator());

        RuleFor(x => x.CreateMovieDto.OriginCountries)
            .NotEmpty().WithMessage("At least one origin country is required.");

        RuleForEach(x => x.CreateMovieDto.OriginCountries)
            .SetValidator(new CountryValidator());
    }
}
