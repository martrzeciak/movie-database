using Microsoft.EntityFrameworkCore;
using MovieDatabase.Domain.Entities;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Infrastructure.Seed;

public class DbSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (!await context.Movies.AnyAsync())
        {
            var movies = new List<Movie>
            {
                new()
                {
                    Title = "Inception",
                    Director = "Christopher Nolan",
                    ReleaseDate = new DateTime(2010, 7, 16),
                    DurationInMinutes = 148,
                    ContentRating = "PG-13",
                    Description = "A thief with the ability to enter people's dreams and steal secrets."
                },
                new()
                {
                    Title = "Interstellar",
                    Director = "Christopher Nolan",
                    ReleaseDate = new DateTime(2014, 11, 7),
                    DurationInMinutes = 169,
                    ContentRating = "PG-13",
                    Description = "A group of astronauts travels through a wormhole in search of a new home for humanity."
                },
                new()
                {
                    Title = "The Godfather",
                    Director = "Francis Ford Coppola",
                    ReleaseDate = new DateTime(1972, 3, 24),
                    DurationInMinutes = 175,
                    ContentRating = "R",
                    Description = "The aging patriarch of an organized crime dynasty transfers control to his reluctant son."
                },
                new()
                {
                    Title = "The Dark Knight",
                    Director = "Christopher Nolan",
                    ReleaseDate = new DateTime(2008, 7, 18),
                    DurationInMinutes = 152,
                    ContentRating = "PG-13",
                    Description = "Batman faces the Joker, a criminal mastermind who seeks to create chaos in Gotham City."
                },
                new()
                {
                    Title = "Pulp Fiction",
                    Director = "Quentin Tarantino",
                    ReleaseDate = new DateTime(1994, 10, 14),
                    DurationInMinutes = 154,
                    ContentRating = "R",
                    Description = "The lives of hitmen, a boxer, and a gangster's wife intertwine in a series of stories."
                }
            };

            await context.Movies.AddRangeAsync(movies);
            await context.SaveChangesAsync();
        }
    }
}

