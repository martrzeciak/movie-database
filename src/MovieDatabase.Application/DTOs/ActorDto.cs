namespace MovieDatabase.Application.DTOs;

public class ActorDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }
    public double Height { get; set; }
    public string Biography { get; set; } = default!;
    public int Age { get; set; }
}
