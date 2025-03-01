using Mapster;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Abstractions.CQRS;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Common.Errors;
using MovieDatabase.Application.Features.Users.DTOs;
using MovieDatabase.Infrastructure.Data;

namespace MovieDatabase.Application.Features.Users.Queries.GetUserDetails;

public class GetUserDetailsQueryHandler(AppDbContext context)
    : IQueryHandler<GetUserDetailsQuery, UserQueryDto>
{
    public async Task<Result<UserQueryDto>> Handle(GetUserDetailsQuery request, 
        CancellationToken cancellationToken)
    {
        var user = await context.Users
            .SingleOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        if (user is null) 
            return Result.Failure<UserQueryDto>(UserErrors.NotFound(request.Id));

        return Result.Success(user.Adapt<UserQueryDto>());
    }
}
