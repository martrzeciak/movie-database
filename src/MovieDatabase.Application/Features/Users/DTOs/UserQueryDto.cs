using MovieDatabase.Application.Features.Movies.Shared.DTOs;

namespace MovieDatabase.Application.Features.Users.DTOs;

public class UserQueryDto
{
    public string Id { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public ICollection<MovieQueryDto> MovieWatchlist { get; set; } = new List<MovieQueryDto>();
}
