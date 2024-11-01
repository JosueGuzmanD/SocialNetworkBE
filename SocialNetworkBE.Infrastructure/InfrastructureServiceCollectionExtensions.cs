using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace SocialNetworkBE.Infrastructure;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SocialNetworkDbContext>(options=> options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        return services;
        
    }
}