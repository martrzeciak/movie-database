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

    public static Error AlreadyInWatchlist(Guid id) => new(
        "400",
        $"Movie with ID {id} is already in the watchlist.");

    public static readonly Error AddToWatchlistFailed = new(
        "400",
        "An error occurred while adding the movie to the watchlist.");

    public static readonly Error RemoveFromWatchlistFailed = new(
        "400",
        "An error occurred while removing the movie from the watchlist.");

    public static Error NotInWatchlist(Guid id) => new(
        "400",
        $"Movie with ID {id} is not in the watchlist.");
}
