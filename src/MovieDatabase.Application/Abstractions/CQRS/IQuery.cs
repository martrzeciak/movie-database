using MediatR;
using MovieDatabase.Application.Common;

namespace MovieDatabase.Application.Abstractions.CQRS;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}