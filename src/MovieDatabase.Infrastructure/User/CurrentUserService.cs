using Microsoft.AspNetCore.Http;
using MovieDatabase.Application.Abstractions.User;
using System.Security.Claims;

namespace MovieDatabase.Infrastructure.User;

public class CurrentUserService(IHttpContextAccessor contextAccessor) : ICurrentUserService
{
    public bool IsUserLoggedIn()
    {
        var userId = GetUserId();

        return !string.IsNullOrEmpty(userId);
    }

    public string? GetUserId()
    {
        var userId = contextAccessor.HttpContext?.User
            .FindFirstValue(ClaimTypes.NameIdentifier);

        return userId;
    }
}
