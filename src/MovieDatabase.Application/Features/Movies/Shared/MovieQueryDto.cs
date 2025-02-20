namespace MovieDatabase.Application.Features.Movies.Shared;

public class MovieQueryDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public int DurationInMinutes { get; set; }
    public ContentRating ContentRating { get; set; }
    public string Description { get; set; } = string.Empty;
    public List<GenreQueryDto> Genres { get; set; } = [];
}
