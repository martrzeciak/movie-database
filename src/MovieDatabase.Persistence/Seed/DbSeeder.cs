using Microsoft.EntityFrameworkCore;
using MovieDatabase.Domain.Entities;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Infrastructure.Seed;

public class DbSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (!await context.Genres.AnyAsync())
        {
            var genres = new List<Genre>
            {
                new() { Name = "Action" },
                new() { Name = "Adventure" },
                new() { Name = "Drama" },
                new() { Name = "Sci-Fi" },
                new() { Name = "Crime" },
                new() { Name = "Thriller" },
                new() { Name = "Fantasy" },
                new() { Name = "Horror" },
                new() { Name = "Comedy" },
                new() { Name = "Mystery" },
                new() { Name = "Romance" },
                new() { Name = "Western" },
                new() { Name = "Animation" },
                new() { Name = "Family" },
                new() { Name = "Musical" },
                new() { Name = "War" },
                new() { Name = "Documentary" },
                new() { Name = "Biography" },
                new() { Name = "Historical" },
                new() { Name = "Sport" },
                new() { Name = "Superhero" },
                new() { Name = "Psychological" },
                new() { Name = "Cyberpunk" },
                new() { Name = "Noir" },
                new() { Name = "Political" },
                new() { Name = "Action-Adventure" },
                new() { Name = "Crime Thriller" },
                new() { Name = "Psychological Thriller" },
                new() { Name = "Historical Drama" },
                new() { Name = "Experimental" },
                new() { Name = "Dance" },
                new() { Name = "Adventure Fantasy" },
                new() { Name = "Spy Thriller" },
                new() { Name = "Coming-of-Age" },
                new() { Name = "Parody" },
                new() { Name = "Slice of Life" },
                new() { Name = "Gothic" },
                new() { Name = "Post-Apocalyptic" },
                new() { Name = "Steampunk" },
                new() { Name = "Teen" },
                new() { Name = "Martial Arts" },
                new() { Name = "Medical" },
                new() { Name = "Black Comedy" },
                new() { Name = "Zombie" },
                new() { Name = "Cult" },
                new() { Name = "Religious" },
                new() { Name = "Disaster" },
                new() { Name = "Reality TV" },
                new() { Name = "Espionage" },
                new() { Name = "Noir Fiction" },
                new() { Name = "Experimental Horror" },
                new() { Name = "Family Drama" },
                new() { Name = "Political Thriller" }
            };

            await context.Genres.AddRangeAsync(genres);
            await context.SaveChangesAsync();
        }

        if (!await context.Countries.AnyAsync())
        {
            var countries = new List<Country>
            {
                new() { Name = "United States", Code = "US", Continent = "North America" },
                new() { Name = "United Kingdom", Code = "GB", Continent = "Europe" },
                new() { Name = "Canada", Code = "CA", Continent = "North America" },
                new() { Name = "Australia", Code = "AU", Continent = "Australia" },
                new() { Name = "Germany", Code = "DE", Continent = "Europe" },
                new() { Name = "India", Code = "IN", Continent = "Asia" },
                new() { Name = "France", Code = "FR", Continent = "Europe" },
                new() { Name = "Japan", Code = "JP", Continent = "Asia" },
                new() { Name = "South Korea", Code = "KR", Continent = "Asia" },
                new() { Name = "Italy", Code = "IT", Continent = "Europe" },
                new() { Name = "Brazil", Code = "BR", Continent = "South America" },
                new() { Name = "Mexico", Code = "MX", Continent = "North America" },
                new() { Name = "Russia", Code = "RU", Continent = "Europe/Asia" },
                new() { Name = "China", Code = "CN", Continent = "Asia" },
                new() { Name = "Spain", Code = "ES", Continent = "Europe" },
                new() { Name = "South Africa", Code = "ZA", Continent = "Africa" },
                new() { Name = "Brazil", Code = "BR", Continent = "South America" },
                new() { Name = "Argentina", Code = "AR", Continent = "South America" },
                new() { Name = "Sweden", Code = "SE", Continent = "Europe" },
                new() { Name = "Netherlands", Code = "NL", Continent = "Europe" },
                new() { Name = "Turkey", Code = "TR", Continent = "Europe/Asia" },
                new() { Name = "Poland", Code = "PL", Continent = "Europe" },
                new() { Name = "Saudi Arabia", Code = "SA", Continent = "Asia" },
                new() { Name = "Egypt", Code = "EG", Continent = "Africa" },
                new() { Name = "United Arab Emirates", Code = "AE", Continent = "Asia" },
                new() { Name = "Nigeria", Code = "NG", Continent = "Africa" },
                new() { Name = "Israel", Code = "IL", Continent = "Asia" },
                new() { Name = "Switzerland", Code = "CH", Continent = "Europe" },
                new() { Name = "Belgium", Code = "BE", Continent = "Europe" },
                new() { Name = "Singapore", Code = "SG", Continent = "Asia" },
                new() { Name = "Norway", Code = "NO", Continent = "Europe" },
                new() { Name = "Finland", Code = "FI", Continent = "Europe" },
                new() { Name = "Pakistan", Code = "PK", Continent = "Asia" },
                new() { Name = "Thailand", Code = "TH", Continent = "Asia" },
                new() { Name = "Colombia", Code = "CO", Continent = "South America" },
                new() { Name = "Vietnam", Code = "VN", Continent = "Asia" },
                new() { Name = "Indonesia", Code = "ID", Continent = "Asia" },
                new() { Name = "Malaysia", Code = "MY", Continent = "Asia" },
                new() { Name = "Chile", Code = "CL", Continent = "South America" },
                new() { Name = "Romania", Code = "RO", Continent = "Europe" },
                new() { Name = "Czech Republic", Code = "CZ", Continent = "Europe" },
                new() { Name = "Denmark", Code = "DK", Continent = "Europe" },
                new() { Name = "Greece", Code = "GR", Continent = "Europe" },
                new() { Name = "Poland", Code = "PL", Continent = "Europe" },
                new() { Name = "Kuwait", Code = "KW", Continent = "Asia" },
                new() { Name = "Qatar", Code = "QA", Continent = "Asia" },
                new() { Name = "Bangladesh", Code = "BD", Continent = "Asia" },
                new() { Name = "Vietnam", Code = "VN", Continent = "Asia" },
                new() { Name = "Slovakia", Code = "SK", Continent = "Europe" }
            };

            await context.Countries.AddRangeAsync(countries);
            await context.SaveChangesAsync();
        }

        if (!await context.Actors.AnyAsync())
        {
            var actors = new List<Actor>
        {
            new Actor
            {
                Name = "Leonardo DiCaprio",
                DateOfBirth = new DateTime(1974, 11, 11),
                Height = 1.83,
                Biography = "Leonardo DiCaprio is an American actor, producer, and environmental activist."
            },
            new Actor
            {
                Name = "Matthew McConaughey",
                DateOfBirth = new DateTime(1969, 11, 4),
                Height = 1.82,
                Biography = "Matthew McConaughey is an American actor and producer."
            },
            new Actor
            {
                Name = "Al Pacino",
                DateOfBirth = new DateTime(1940, 4, 25),
                Height = 1.73,
                Biography = "Al Pacino is an American actor and filmmaker, known for his roles in crime dramas."
            },
            new Actor
            {
                Name = "Christian Bale",
                DateOfBirth = new DateTime(1974, 1, 30),
                Height = 1.80,
                Biography = "Christian Bale is an English actor known for his versatility in various roles."
            },
            new Actor
            {
                Name = "Bruce Willis",
                DateOfBirth = new DateTime(1955, 3, 19),
                Height = 1.83,
                Biography = "Bruce Willis is an American actor known for his roles in action films, notably the Die Hard series."
            },
            new Actor
            {
                Name = "Joseph Gordon-Levitt",
                DateOfBirth = new DateTime(1981, 2, 17),
                Height = 1.78,
                Biography = "Joseph Gordon-Levitt is an American actor and filmmaker, known for his roles in films like 'Inception' and 'Looper'."
            },
            new Actor
            {
                Name = "Anne Hathaway",
                DateOfBirth = new DateTime(1982, 11, 12),
                Height = 1.73,
                Biography = "Anne Hathaway is an American actress, recognized for her performances in films such as 'The Devil Wears Prada' and 'Les Misérables'."
            },
            new Actor
            {
                Name = "Marlon Brando",
                DateOfBirth = new DateTime(1924, 4, 3),
                Height = 1.75,
                Biography = "Marlon Brando was an American actor and film director, celebrated for his roles in classics like 'A Streetcar Named Desire' and 'The Godfather'."
            },
            new Actor
            {
                Name = "Heath Ledger",
                DateOfBirth = new DateTime(1979, 4, 4),
                Height = 1.85,
                Biography = "Heath Ledger was an Australian actor, renowned for his portrayal of the Joker in 'The Dark Knight'."
            },
            new Actor
            {
                Name = "Uma Thurman",
                DateOfBirth = new DateTime(1970, 4, 29),
                Height = 1.80,
                Biography = "Uma Thurman is an American actress and model, known for her roles in films such as 'Pulp Fiction' and 'Kill Bill'."
            }
        };

            await context.Actors.AddRangeAsync(actors);
            await context.SaveChangesAsync();
        }

        if (!await context.Movies.AnyAsync())
        {
            var genres = await context.Genres.ToListAsync();
            var countries = await context.Countries.ToListAsync();
            var actors = await context.Actors.ToListAsync();

            var movies = new List<Movie>
            {
                new Movie
                {
                    Title = "Inception",
                    Director = "Christopher Nolan",
                    ReleaseDate = new DateTime(2010, 7, 16),
                    DurationInMinutes = 148,
                    ContentRating = ContentRating.PG13,
                    Description = "A thief with the ability to enter people's dreams and steal secrets.",
                    Genres = genres.Where(g => g.Name == "Sci-Fi" || g.Name == "Action").ToList(),
                    OriginCountries = countries.Where(c => c.Name == "United States" || c.Name == "United Kingdom").ToList(),
                    Actors = actors.Where(c => c.Name == "Leonardo DiCaprio" || c.Name == "Joseph Gordon-Levitt").ToList()
                },
                new Movie
                {
                    Title = "Interstellar",
                    Director = "Christopher Nolan",
                    ReleaseDate = new DateTime(2014, 11, 7),
                    DurationInMinutes = 169,
                    ContentRating = ContentRating.PG13,
                    Description = "A group of astronauts travels through a wormhole in search of a new home for humanity.",
                    Genres = genres.Where(g => g.Name == "Sci-Fi" || g.Name == "Drama").ToList(),
                    OriginCountries = countries.Where(c => c.Name == "United States").ToList(),
                    Actors = actors.Where(c => c.Name == "Matthew McConaughey" || c.Name == "Anne Hathaway").ToList()
                },
                new Movie
                {
                    Title = "The Godfather",
                    Director = "Francis Ford Coppola",
                    ReleaseDate = new DateTime(1972, 3, 24),
                    DurationInMinutes = 175,
                    ContentRating = ContentRating.R,
                    Description = "The aging patriarch of an organized crime dynasty transfers control to his reluctant son.",
                    Genres = genres.Where(g => g.Name == "Crime" || g.Name == "Drama").ToList(),
                    OriginCountries = countries.Where(c => c.Name == "United States").ToList(),
                    Actors = actors.Where(c => c.Name == "Al Pacino" || c.Name == "Marlon Brando").ToList()
                },
                new Movie
                {
                    Title = "The Dark Knight",
                    Director = "Christopher Nolan",
                    ReleaseDate = new DateTime(2008, 7, 18),
                    DurationInMinutes = 152,
                    ContentRating = ContentRating.PG13,
                    Description = "Batman faces the Joker, a criminal mastermind who seeks to create chaos in Gotham City.",
                    Genres = genres.Where(g => g.Name == "Action" || g.Name == "Crime" || g.Name == "Thriller").ToList(),
                    OriginCountries = countries.Where(c => c.Name == "United States").ToList(),
                    Actors = actors.Where(c => c.Name == "Christian Bale" || c.Name == "Heath Ledger").ToList()
                },
                new Movie
                {
                    Title = "Pulp Fiction",
                    Director = "Quentin Tarantino",
                    ReleaseDate = new DateTime(1994, 10, 14),
                    DurationInMinutes = 154,
                    ContentRating = ContentRating.R,
                    Description = "The lives of hitmen, a boxer, and a gangster's wife intertwine in a series of stories.",
                    Genres = genres.Where(g => g.Name == "Crime" || g.Name == "Drama" || g.Name == "Thriller").ToList(),
                    OriginCountries = countries.Where(c => c.Name == "United States").ToList(),
                    Actors = actors.Where(c => c.Name == "Bruce Willis" || c.Name == "Uma Thurman").ToList()
                }
            };

            await context.Movies.AddRangeAsync(movies);
            await context.SaveChangesAsync();
        }
    }
}

