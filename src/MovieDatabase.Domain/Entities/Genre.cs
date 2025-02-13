namespace MovieDatabase.Domain.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; } = default!;

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
