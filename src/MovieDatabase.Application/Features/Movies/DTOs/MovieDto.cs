namespace MovieDatabase.Application.Features.Movies.DTOs;

public class MovieDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public int DurationInMinutes { get; set; }
    public string ContentRating { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    // public List<string> Genres { get; set; } = [];
}
