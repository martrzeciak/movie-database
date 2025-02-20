using FluentValidation;
using MovieDatabase.Application.Features.Movies.Shared.DTOs;

namespace MovieDatabase.Application.Features.Movies.Shared.Validators;

public class GenreValidator : AbstractValidator<GenreDto>
{
    public GenreValidator()
    {
        RuleFor(x => x.Id).
            NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");
    }
}
