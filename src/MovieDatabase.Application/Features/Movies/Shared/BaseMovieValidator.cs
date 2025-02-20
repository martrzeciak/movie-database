using FluentValidation;

namespace MovieDatabase.Application.Features.Movies.Shared;

public class BaseMovieValidator<T, TResult> : AbstractValidator<T>
    where TResult : BaseMovieDto
{
    public BaseMovieValidator(Func<T, TResult> selector)
    {
        RuleFor(movie => selector(movie).Title)
           .NotEmpty().WithMessage("Title is required.")
           .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

        RuleFor(movie => selector(movie).Director)
            .NotEmpty().WithMessage("Director is required.")
            .MaximumLength(50).WithMessage("Director name cannot exceed 50 characters.");

        RuleFor(movie => selector(movie).ReleaseDate)
            .NotEmpty().WithMessage("Release date is required.");
        //.LessThanOrEqualTo(DateTime.Today).WithMessage("Release date cannot be in the future.");

        RuleFor(movie => selector(movie).DurationInMinutes)
            .NotEmpty().WithMessage("Duration is required.")
            .GreaterThan(0).WithMessage("Duration must be a positive number.");

        RuleFor(movie => selector(movie).ContentRating)
            .NotEmpty().WithMessage("Content rating is required.")
            .IsInEnum().WithMessage("Invalid content rating.");

        RuleFor(movie => selector(movie).Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
    }
}
