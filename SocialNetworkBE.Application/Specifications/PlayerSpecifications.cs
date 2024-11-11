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

public class EmailIsUniqueSpecification: IAsyncSpecification<CreatePlayerDto>
{
    private readonly IPlayerRepository _playerRepository;

    public EmailIsUniqueSpecification(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }


    public async Task<bool> IsSatisfiedByAsync(CreatePlayerDto entity)
    {
        var existingMail= await _playerRepository.GetPlayerByEmailAsync(entity.Email);
        return existingMail == null;
    }
    public string ErrorMessage => "The email format is already registered.";
}

public class UsernameFormatSpecification : ISpecification<CreatePlayerDto>
{
    public string ErrorMessage => "Username must be alphanumeric without spaces or special characters.";

    public bool IsSatisfiedBy(CreatePlayerDto player)
    {
        var validator = new InlineValidator<string>();
        validator.RuleFor(u => u).Matches("^[a-zA-Z0-9]+$").WithMessage(ErrorMessage);
        var result = validator.Validate(player.Name);
        return result.IsValid;
    }
}




