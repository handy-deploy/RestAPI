using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Persistence.Repositories.ProjectRepository;
using Persistence.Repositories.UserRepository;

namespace Persistence.Extensions;

public static class PersistenceServiceCollectionExtension
{
    public static void AddPersistence(this IServiceCollection services)
    {
        services.AddTransient<IProjectRepository, ProjectRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
    }
}