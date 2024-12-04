using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Application.Specifications;
using SocialNetworkBE.Domain.Interfaces.Repositories;

namespace SocialNetworkBE.Application.Validators;

public class PlayerRegistrationValidator
{
    private readonly List<ISpecification<CreatePlayerDto>> _syncSpecifications;
    private readonly List<IAsyncSpecification<CreatePlayerDto>> _asyncSpecifications;

    public PlayerRegistrationValidator(IPlayerRepository playerRepository)
    {
        _syncSpecifications = new List<ISpecification<CreatePlayerDto>>
        {
            new EmailIsValidSpecification()
        };

        _asyncSpecifications = new List<IAsyncSpecification<CreatePlayerDto>>
        {
            new EmailIsUniqueSpecification(playerRepository)
        };
    }

    public async Task<Result<CreatePlayerDto>> ValidateAsync(CreatePlayerDto player)
    {
        foreach (var spec in _syncSpecifications)
        {
            var result = spec.IsSatisfiedBy(player);
            if (!result.IsSuccess) return result;
        }

        foreach (var asyncSpec in _asyncSpecifications)
        {
            var result = await asyncSpec.IsSatisfiedByAsync(player);
            if (!result.IsSuccess) return result;
        }

        return Result<CreatePlayerDto>.Success(player);
    }
}