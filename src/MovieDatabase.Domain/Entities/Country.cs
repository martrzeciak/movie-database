namespace MovieDatabase.Domain.Entities;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string Continent { get; set; } = default!;

    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
