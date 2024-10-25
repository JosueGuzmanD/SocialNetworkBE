using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNetworkBE.Domain.Repositories;
using SocialNetworkBE.Infrastructure.Repositories;

namespace SocialNetworkBE.Infrastructure;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Configura el DbContext con SQL Server
        services.AddDbContext<SocialNetworkDbContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Configura Identity con el ApplicationUser y IdentityRole
        services.AddIdentity<ApplicationUser>(options =>
        {
            // Opciones de seguridad para contraseñas
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
            options.User.RequireUniqueEmail = true;
        })
        .AddRoles<IdentityRole>();

        // Agrega los servicios de repositorio
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IFriendshipRepository, FriendshipRepository>();

        return services;
    }
}