namespace MovieDatabase.Domain.Entities;

public class Actor : BaseEntity
{
    public string Name { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }
    public double Height { get; set; }
    public string Biography { get; set; } = default!;
    // public int Age => DateTime.Now.Year - DateOfBirth.Year;

    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
