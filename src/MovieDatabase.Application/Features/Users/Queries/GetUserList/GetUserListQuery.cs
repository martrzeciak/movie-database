using MovieDatabase.Application.Abstractions.CQRS;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Users.DTOs;

namespace MovieDatabase.Application.Features.Users.Queries.GetUserList;

public class GetUserListQuery : IQuery<PagedList<UserQueryDto>>
{
    public required PagingParams Params { get; set; }
}
