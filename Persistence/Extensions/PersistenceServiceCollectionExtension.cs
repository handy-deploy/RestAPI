using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Persistence.Repositories.ProjectRepository;

namespace Persistence.Extensions;

public static class PersistenceServiceCollectionExtension
{
    public static void AddPersistence(this IServiceCollection services)
    {
        services.AddTransient<IProjectRepository, ProjectRepository>();
    }
}