using Mapster;
using MovieDatabase.Application.Features.Actors.DTOs;
using MovieDatabase.Domain.Entities;

namespace MovieDatabase.Application.MappingConfigurations;

public class ActorMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Actor, ActorDto>()
            .Map(dest => dest.Age, src => DateTime.Now.Year - src.DateOfBirth.Year);
    }
}
