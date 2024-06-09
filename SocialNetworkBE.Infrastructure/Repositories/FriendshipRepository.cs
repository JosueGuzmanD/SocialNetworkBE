using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Repositories;

namespace SocialNetworkBE.Infrastructure.Repositories;

public class FriendshipRepository : GenericRepository<Friendship>, IFriendshipRepository
{

    public FriendshipRepository(SocialNetworkDbContext context) : base(context)
    {

    }


}
