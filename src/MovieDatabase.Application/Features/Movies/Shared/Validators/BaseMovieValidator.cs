using FluentValidation;
using MovieDatabase.Application.Features.Movies.Shared.DTOs;

namespace MovieDatabase.Application.Features.Movies.Shared.Validators;

public class BaseMovieValidator<T, TResult> : AbstractValidator<T>
    where TResult : BaseMovieDto
{
    public BaseMovieValidator(Func<T, TResult> selector)
    {
        RuleFor(x => selector(x).Title)
           .NotEmpty().WithMessage("Title is required.")
           .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

        RuleFor(x => selector(x).Director)
            .NotEmpty().WithMessage("Director is required.")
            .MaximumLength(50).WithMessage("Director name cannot exceed 50 characters.");

        RuleFor(x => selector(x).ReleaseDate)
            .NotEmpty().WithMessage("Release date is required.");
        //.LessThanOrEqualTo(DateTime.Today).WithMessage("Release date cannot be in the future.");

        RuleFor(x => selector(x).DurationInMinutes)
            .NotEmpty().WithMessage("Duration is required.")
            .GreaterThan(0).WithMessage("Duration must be a positive number.");

        RuleFor(x => selector(x).ContentRating)
            .NotEmpty().WithMessage("Content rating is required.")
            .IsInEnum().WithMessage("Invalid content rating.");

        RuleFor(x => selector(x).Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

        RuleFor(x => selector(x).Genres)
            .NotEmpty().WithMessage("At least one genre is required.");

        RuleForEach(x => selector(x).Genres)
            .SetValidator(new GenreValidator());
    }
}
