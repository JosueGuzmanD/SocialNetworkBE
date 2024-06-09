﻿using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Domain.Repositories;

public interface IUserRepository: IGenericRepository<User>
{ 
    Task<User> GetByEmailAsync(string email);
}
