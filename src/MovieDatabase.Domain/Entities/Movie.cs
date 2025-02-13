namespace MovieDatabase.Domain.Entities;

public class Movie : BaseEntity
{
    public string Title { get; set; } = default!;
    public string Director { get; set; } = default!;
    public DateTime ReleaseDate { get; set; }
    public int DurationInMinutes { get; set; }
    public ContentRating ContentRating { get; set; }
    public string Description { get; set; } = default!;

    public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    public ICollection<Country> OriginCountries { get; set; } = new List<Country>();
    public ICollection<Actor> Actors { get; set; } = new List<Actor>();
}
