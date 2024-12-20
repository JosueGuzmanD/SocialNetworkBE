using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNetworkBE.Application.Interfaces;
using SocialNetworkBE.Application.Services;
using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Interfaces.Repositories;
using SocialNetworkBE.Infrastructure.Repositories;
using SocialNetworkBE.Infrastructure.Roles;

namespace SocialNetworkBE.Infrastructure;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<SocialNetworkDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<SocialNetworkDbContext>()
            .AddTokenProvider<EmailTokenProvider<ApplicationUser>>("email")
            .AddTokenProvider<PhoneNumberTokenProvider<ApplicationUser>>("phone");


        services.AddScoped<IPlayerRepository, PlayerRepository>();
        services.AddScoped<IPlayerService, PlayerService>();
        services.AddHostedService<RoleInitializer>();
        
        return services;
    }
}