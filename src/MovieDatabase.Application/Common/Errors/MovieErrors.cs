namespace MovieDatabase.Application.Common.Errors;

public static class MovieErrors
{
    public static Error NotFound(Guid movieId) => new(
        "404",
        $"Movie with ID {movieId} not found.");

    public static readonly Error GenreNotProvided = new(
        "400",
        "Movie genre must be provided.");

    public static readonly Error CountryNotProvided = new(
        "400",
        "Movie country must be provided.");

    public static readonly Error GenresNotFound = new(
        "404",
        "One or more specified genres were not found.");

    public static readonly Error CountriesNotFound = new(
        "404",
        "One or more specified countries were not found.");

    public static readonly Error CreationFailed = new(
        "400",
        "An error occurred while creating the movie.");

    public static readonly Error DeletionFailed = new(
        "400",
        "An error occurred while deleting the movie.");

    public static readonly Error UpdateFailed = new(
        "400",
        "An error occurred while updating the movie.");
}
