using Microsoft.AspNetCore.Http;
using MovieDatabase.Application.Abstractions.User;
using System.Security.Claims;

namespace MovieDatabase.Infrastructure.User;

public class CurrentUserService(IHttpContextAccessor contextAccessor) : ICurrentUserService
{
    public bool IsUserLoggedIn()
    {
        var userId = contextAccessor.HttpContext?.User
            .FindFirstValue(ClaimTypes.NameIdentifier);

        return !string.IsNullOrEmpty(userId);
    }
}
