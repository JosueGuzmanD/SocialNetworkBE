using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Domain.Repositories;

public interface IUserRepository: IGenericRepository<Player>
{ 
    Task<Player> GetByEmailAsync(string email);
}
