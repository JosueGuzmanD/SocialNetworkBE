using Microsoft.AspNetCore.Identity;

namespace SocialNetworkBE.Domain.Entities;

public class ApplicationUser: IdentityUser
{
    public Guid PlayerId { get; set; }
    public Player Player { get; set; }
}