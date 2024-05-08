using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDB.Entities;
using SocialNetwork.Application.BCryptServices;
using SocialNetwork.Application.BCryptServices;
using SocialNetwork.Domain.BCryptService;
using SocialNetwork.Infrastructure.HashService;

namespace SocialNetwork.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        Task.Run(async () =>
            {
                await DB.InitAsync("SocialNetwork", MongoClientSettings.FromConnectionString("your-mongodb-connection-string"));
            })
            .GetAwaiter()
            .GetResult();
        
        services.AddSingleton<IPasswordHashService, BcryptPasswordHashService>();
        services.AddSingleton<IPasswordVerificationService, BCryptPasswordVerificationService>();
        
        return services;
    }
}