using Microsoft.EntityFrameworkCore;
using MovieDatabase.Domain.Entities;

namespace MovieDatabase.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }
}
