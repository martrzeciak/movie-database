namespace MovieDatabase.Application.Features.Movies.DTOs;

public class CreateMovieDto
{
    public string Title { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public int DurationInMinutes { get; set; }
    public ContentRating ContentRating { get; set; }
    public string Description { get; set; } = string.Empty;
}
