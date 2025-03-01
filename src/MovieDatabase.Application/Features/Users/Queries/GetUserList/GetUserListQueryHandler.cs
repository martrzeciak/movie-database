using Mapster;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Abstractions.CQRS;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Users.DTOs;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Users.Queries.GetUserList;

public class GetUserListQueryHandler(AppDbContext context)
    : IQueryHandler<GetUserListQuery, PagedList<UserQueryDto>>
{
    public async Task<Result<PagedList<UserQueryDto>>> Handle(GetUserListQuery request,
        CancellationToken cancellationToken)
    {
        var query = context.Users
            .AsNoTracking()
            .ProjectToType<UserQueryDto>();

        return Result.Success(await PagedList<UserQueryDto>
            .CreateAsync(query, request.Params.PageNumber, request.Params.PageSize));
    }
}
