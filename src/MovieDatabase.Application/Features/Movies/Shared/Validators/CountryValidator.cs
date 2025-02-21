using FluentValidation;
using MovieDatabase.Application.Features.Movies.Shared.DTOs;

namespace MovieDatabase.Application.Features.Movies.Shared.Validators;

public class CountryValidator : AbstractValidator<CountryDto>
{
    public CountryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters.")
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Code is required.");
            // .Length(6).WithMessage("Code must be 6 characters.");

        RuleFor(x => x.Continent)
            .NotEmpty().WithMessage("Continent is required.")
            .MinimumLength(3).WithMessage("Continent must be at least 3 characters.")
            .MaximumLength(50).WithMessage("Continent must not exceed 50 characters.");
    }
}
