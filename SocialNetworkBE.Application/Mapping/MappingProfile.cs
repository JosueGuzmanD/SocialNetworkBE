using AutoMapper;
using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UpdatePlayerDto, Player>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}