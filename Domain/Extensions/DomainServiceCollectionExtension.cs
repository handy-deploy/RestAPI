using Domain.Services;
using Domain.Services.GitService;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Extensions;

public static class DomainServiceCollectionExtension
{
    public static void AddDomain(this IServiceCollection services)
    {
        services.AddTransient<IGitService, GitService>();
    }
}