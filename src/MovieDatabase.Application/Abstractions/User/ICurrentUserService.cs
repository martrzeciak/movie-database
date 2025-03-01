namespace MovieDatabase.Application.Abstractions.User;

public interface ICurrentUserService
{
    bool IsUserLoggedIn();
}
