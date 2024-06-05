using SocialNetworkBE.Application.DTOs;

namespace SocialNetworkBE.Application.Interfaces
{
    public interface IUserServices
    {
        Task<UserDto> GetByIdAsync(Guid id);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> CreateAsync(CreateUserDto userDto);
        Task UpdateAsync(UpdateUserDto userDto);
        Task DeleteAsync(Guid id);
    }
}
