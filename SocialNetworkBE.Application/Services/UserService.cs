using AutoMapper;
using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Application.Interfaces;
using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Repositories;

namespace SocialNetworkBE.Application.Services;

public class UserService : IUserServices
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> GetByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<UserDto> CreateAsync(CreateUserDto userDto)
    {
        var user = _mapper.Map<Player>(userDto);
        user.Id = Guid.NewGuid();
        user.UserGuid = Guid.NewGuid();
        user.creationDate = DateTime.UtcNow;
        user.updatedDate = DateTime.UtcNow;

        await _userRepository.AddAsync(user);
        return _mapper.Map<UserDto>(user);
    }

    public async Task UpdateAsync(UpdateUserDto userDto)
    {
        var user = await _userRepository.GetByIdAsync(userDto.Id);
        if (user == null)
        {
            throw new KeyNotFoundException($"User with Id {userDto.Id} not found");
        }
        _mapper.Map(userDto, user);
        user.updatedDate = DateTime.UtcNow;
        await _userRepository.UpdateAsync(user);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity= await _userRepository.GetByIdAsync(id);
        await _userRepository.RemoveAsync(entity);
    }
}
