using MovieDatabase.Domain.Entities;

namespace MovieDatabase.Domain.Interfaces;

public interface IMovieRepository
{
    Task<Movie?> GetByIdAsync(int id);
    Task<IEnumerable<Movie>> GetAllAsync();
    Task AddAsync(Movie movie);
    Task UpdateAsync(Movie movie);
    Task DeleteAsync(Movie movie);
}
