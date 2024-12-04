using FluentValidation;
using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Domain.Interfaces.Repositories;

namespace SocialNetworkBE.Application.Specifications;

public class EmailIsValidSpecification : ISpecification<CreatePlayerDto>
{
    public Result<CreatePlayerDto> IsSatisfiedBy(CreatePlayerDto entity)
    {
        var validator = new InlineValidator<string>();
        validator.RuleFor(e => e).EmailAddress();
        var result = validator.Validate(entity.Email);

        if (!result.IsValid) return Result<CreatePlayerDto>.Failure("Invalid email format.");

        return Result<CreatePlayerDto>.Success(entity);
    }
}

public class EmailIsUniqueSpecification : IAsyncSpecification<CreatePlayerDto>
{
    private readonly IPlayerRepository _playerRepository;

    public EmailIsUniqueSpecification(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<Result<CreatePlayerDto>> IsSatisfiedByAsync(CreatePlayerDto entity)
    {
        var existingPlayer = await _playerRepository.GetPlayerByEmailAsync(entity.Email);

        if (existingPlayer != null) return Result<CreatePlayerDto>.Failure("The email is already in use.");

        return Result<CreatePlayerDto>.Success(entity);
    }
}

public class UsernameFormatSpecification : ISpecification<CreatePlayerDto>
{
    public Result<CreatePlayerDto> IsSatisfiedBy(CreatePlayerDto player)
    {
        var validator = new InlineValidator<string>();
        validator.RuleFor(u => u)
            .Matches("^[a-zA-Z0-9]+$")
            .WithMessage("Username must be alphanumeric without spaces or special characters.");

        var validationResult = validator.Validate(player.Name);

        if (!validationResult.IsValid)
            return Result<CreatePlayerDto>.Failure(validationResult.Errors.First().ErrorMessage);

        return Result<CreatePlayerDto>.Success(player);
    }
}