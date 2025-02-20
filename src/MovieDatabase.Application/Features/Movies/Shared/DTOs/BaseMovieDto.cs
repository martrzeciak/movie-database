using Mapster;

namespace MovieDatabase.Application.Features.Movies.Shared.DTOs;

public class BaseMovieDto
{
    public string Title { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public int DurationInMinutes { get; set; }
    public ContentRating ContentRating { get; set; }
    public string Description { get; set; } = string.Empty;
}
