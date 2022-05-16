using Domain.Services;
using Domain.Services.GitService;
using Domain.Services.UserService;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Extensions;

public static class DomainServiceCollectionExtension
{
    public static void AddDomain(this IServiceCollection services)
    {
        services.AddTransient<IGitService, GitService>();
        services.AddTransient<IUserService, UserService>();
    }
}