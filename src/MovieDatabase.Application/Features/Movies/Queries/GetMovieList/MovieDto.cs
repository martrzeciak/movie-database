namespace MovieDatabase.Application.Features.Movies.Queries.GetMovieList;

public class MovieDto
{
    public string Title { get; set; } = default!;
    public string Director { get; set; } = default!;
    public DateTime ReleaseDate { get; set; }
    public int DurationInMinutes { get; set; }
    public string ContentRating { get; set; } = default!;
    public string Description { get; set; } = default!;
}
