using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieDatabase.Domain.Entities;

namespace MovieDatabase.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Actor> Actors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .Property(m => m.ContentRating)
            .HasConversion(new EnumToStringConverter<ContentRating>());

        base.OnModelCreating(modelBuilder);
    }
}
