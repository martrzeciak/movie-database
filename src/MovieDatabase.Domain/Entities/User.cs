using Microsoft.AspNetCore.Identity;

namespace MovieDatabase.Domain.Entities;

public class User : IdentityUser
{
    public ICollection<Movie> MovieWatchlist { get; set; } = new List<Movie>();
}
