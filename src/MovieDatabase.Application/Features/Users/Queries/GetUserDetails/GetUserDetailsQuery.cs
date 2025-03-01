using MovieDatabase.Application.Abstractions.CQRS;
using MovieDatabase.Application.Features.Users.DTOs;

namespace MovieDatabase.Application.Features.Users.Queries.GetUserDetails;

public class GetUserDetailsQuery : IQuery<UserQueryDto>
{
    public required string Id { get; set; }
}
