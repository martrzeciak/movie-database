namespace MovieDatabase.Application.Common.Errors;

public class UserErrors
{
    public static readonly Error NotLoggedIn = new(
        "401",
        "User is not logged in.");

    public static Error NotFound(string userId) => new(
        "404",
        $"User with ID {userId} not found.");
}
