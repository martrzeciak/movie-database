﻿using MediatR;
using MovieDatabase.Application.Common;
using MovieDatabase.Application.Features.Actors.DTOs;

namespace MovieDatabase.Application.Features.Actors.Queries.GetActorDetails;

public class GetActorDetailsQuery : IRequest<Result<ActorDto>>
{
    public required Guid Id { get; set; }
}
