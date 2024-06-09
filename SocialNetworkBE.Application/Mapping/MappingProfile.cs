using AutoMapper;
using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, CreateUserDto>().ReverseMap()
        .ForMember(dest => dest.Id, opt => opt.Ignore());    
        CreateMap<User, UpdateUserDto>().ReverseMap();
        CreateMap<FriendshipRequestDto,Friendship>().ReverseMap();
    }
}
