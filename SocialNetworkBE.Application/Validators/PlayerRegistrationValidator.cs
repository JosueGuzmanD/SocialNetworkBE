using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Application.Specifications;

namespace SocialNetworkBE.Application.Validators;

public class PlayerRegistrationValidator
{
    private readonly List<ISpecification<CreatePlayerDto>> _specifications;


    public PlayerRegistrationValidator()
    {
        _specifications = new List<ISpecification<CreatePlayerDto>>
        {
            new EmailIsValidSpecification(),
            new EmailIsUniqueSpecification()

        };
    }

    public void Validate(CreatePlayerDto player)
    {
        foreach (var spec in _specifications)
        {
            if (!spec.IsSatisfiedBy(player))
            {
                throw new Exception(spec.ErrorMessage);
            }
        }
    }
    
    
}