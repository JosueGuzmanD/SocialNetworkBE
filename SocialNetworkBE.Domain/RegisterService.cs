using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Repositories;

namespace SocialNetworkBE.Domain;
public class RegisterService
{
    private readonly IUserRepository _userRepository;
    private readonly PasswordHashingService _passwordHashingService;
    private readonly PasswordValidatorService _passwordValidatorService;

    public RegisterService(IUserRepository userRepository, PasswordValidatorService passwordValidatorService, PasswordHashingService passwordHashingService)
    {
        _userRepository = userRepository;
        _passwordValidatorService = passwordValidatorService;
        _passwordHashingService = passwordHashingService;
    }
    public async Task RegisterUserAsync(Player user)
    {
       await ValidateEmailAsync(user.Email);
        _passwordValidatorService.ValidatePassword(user.Password);
        var passwordHash = _passwordHashingService.HashPassword(user.Password);
        var newUser = CreateUser(user, passwordHash);
        await SaveUserAsync(newUser);

    }

    private async Task ValidateEmailAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        if (user != null)
        {

            throw new Exception("Email is already registered.");
        }
    }

    private Player CreateUser(Player user, string passwordHash)
    {
        return new Player
        {
            Id = Guid.NewGuid(),
            Name = user.Name,
            Email = user.Email,
            PasswordHash = passwordHash,
            Birthdate = user.Birthdate,
            Bio = user.Bio,
            AvatarUrl = user.AvatarUrl,
            creationDate = DateTime.Now
        };
    }

    private async Task SaveUserAsync(Player user)
    {
        await _userRepository.AddAsync(user);
    }

 

}
