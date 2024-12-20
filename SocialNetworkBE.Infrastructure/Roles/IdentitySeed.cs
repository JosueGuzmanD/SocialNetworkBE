using Microsoft.AspNetCore.Identity;

namespace SocialNetworkBE.Infrastructure.Roles;

public static class IdentitySeed
{
    public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        var roles= new[] {"Admin", "User"};

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
            
        }
        
        
    }
}