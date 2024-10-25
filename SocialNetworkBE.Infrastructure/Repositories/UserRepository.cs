using SocialNetworkBE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SocialNetworkBE.Domain.Repositories;

namespace SocialNetworkBE.Infrastructure.Repositories;

public class UserRepository : GenericRepository<Player>, IUserRepository
{
    public UserRepository(SocialNetworkDbContext context):base(context)
    {
        
    }

    public async Task<Player> GetByEmailAsync(string email)
    {
    return  await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
    }
}
