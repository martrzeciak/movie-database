using MovieDatabase.Application.Features.Movies.Shared;

namespace MovieDatabase.Application.Features.Movies.DTOs;

public class UpdateMovieDto : BaseMovieDto
{
    public Guid Id { get; set; }
}
