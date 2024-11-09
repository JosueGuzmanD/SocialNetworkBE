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
            new EmailIsValidSpecification(),

        };

        _asyncSpecifications = new List<IAsyncSpecification<CreatePlayerDto>>
        {
            new EmailIsUniqueSpecification(playerRepository)

        };

    }

    public async Task ValidateAsync(CreatePlayerDto player)
    {
        foreach (var spec in _syncSpecifications)
        {
            if (!spec.IsSatisfiedBy(player))
            {
                throw new Exception(spec.ErrorMessage);
            }
        }

        foreach (var asyncSpec in _asyncSpecifications)
        {
            if (!await asyncSpec.IsSatisfiedByAsync(player))
            {
                throw new Exception(asyncSpec.ErrorMessage);
            }
        }
    }
    
}