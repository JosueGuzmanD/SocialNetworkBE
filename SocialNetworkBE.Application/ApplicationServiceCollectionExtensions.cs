using Microsoft.Extensions.DependencyInjection;
using SocialNetworkBE.Application.Interfaces;
using SocialNetworkBE.Application.Services;

namespace SocialNetworkBE.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserServices, UserService>();
        services.AddScoped<IFriendshipService, FriendshipService>();

        return services;
    }
}
