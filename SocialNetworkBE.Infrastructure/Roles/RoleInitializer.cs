using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SocialNetworkBE.Infrastructure.Roles;

public class RoleInitializer : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public RoleInitializer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var scope = _serviceProvider.CreateScope();
        
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        
        await IdentitySeed.SeedRolesAsync(roleManager);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}