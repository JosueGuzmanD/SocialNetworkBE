using AutoMapper;
using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Player, UserDto>().ReverseMap();
        CreateMap<Player, CreateUserDto>().ReverseMap()
        .ForMember(dest => dest.Id, opt => opt.Ignore());    
        CreateMap<Player, UpdateUserDto>().ReverseMap();
        CreateMap<FriendshipRequestDto,Friendship>().ReverseMap();
    }
}
