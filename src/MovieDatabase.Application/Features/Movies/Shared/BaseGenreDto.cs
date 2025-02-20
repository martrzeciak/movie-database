namespace MovieDatabase.Application.Features.Movies.Shared;

public class GenreQueryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
