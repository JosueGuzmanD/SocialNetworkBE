using Microsoft.AspNetCore.Identity;

namespace SocialNetworkBE.Infrastructure;

public class ApplicationUser: IdentityUser
{
    public DateTime BirthDate { get; set; }
    public string Bio {  get; set; }
    public string AvatarUrl { get; set; }

}
