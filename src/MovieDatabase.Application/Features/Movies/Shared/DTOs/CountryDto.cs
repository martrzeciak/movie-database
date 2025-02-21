namespace MovieDatabase.Application.Features.Movies.Shared.DTOs;

public class CountryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Continent { get; set; } = string.Empty;
}
