﻿using FluentValidation;
using SocialNetworkBE.Application.DTOs;
using SocialNetworkBE.Domain.Interfaces.Repositories;

namespace SocialNetworkBE.Application.Specifications;

public class EmailIsValidSpecification : ISpecification<CreatePlayerDto>
{
    public bool IsSatisfiedBy(CreatePlayerDto player)
    {
        var validator= new InlineValidator<string>();
        validator.RuleFor(e=>e).EmailAddress();
        var result = validator.Validate(player.Email);
        
       return result.IsValid;
        
    }
    public string ErrorMessage => "The email format is invalid.";
}

public class EmailIsUniqueSpecification:ISpecification<CreatePlayerDto>
{
    private readonly IPlayerRepository _playerRepository;

    public EmailIsUniqueSpecification(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }


    public bool IsSatisfiedBy(CreatePlayerDto entity)
    {
        var existingMail= _playerRepository.GetPlayerByEmailAsync(entity.Email);
        return existingMail == null;
    }

    public string ErrorMessage => "The email format is already registered.";
}



