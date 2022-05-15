using Microsoft.EntityFrameworkCore;
using Persistence.Models;
using Persistence.Repositories.ProjectRepository.Dtos;

namespace Persistence.Repositories.ProjectRepository;

public class ProjectRepository : IProjectRepository
{
    private readonly IDbContextFactory<HDContext> _factory;

    public ProjectRepository(IDbContextFactory<HDContext> factory)
    {
        _factory = factory;
    }

    public async Task<Project?> Insert(InsertProjectDto dto)
    {
        await using var context = await _factory.CreateDbContextAsync();
        
        var id = Guid.NewGuid();

        var entity = new Project
        {
            Id = id,
            Description = dto.Description,
            Name = dto.Name,
            VCSUrl = dto.VCSUrl
        };

        await context.Projects.AddAsync(entity);
        await context.SaveChangesAsync();

        var result = await context.Projects.FindAsync(id);

        return result;
    }

    public async Task Delete(Guid projectId)
    {
        await using var context = await _factory.CreateDbContextAsync();

        var entity = await context.Projects.FindAsync(projectId);

        if (entity != null)
        {
            context.Projects.Remove(entity);
            await context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Project>> GetAll()
    {
        await using var context = await _factory.CreateDbContextAsync();

        return await context.Projects.ToListAsync();
    }

    public async Task Update(Guid projectId, UpdateProjectDto dto)
    {
        await using var context = await _factory.CreateDbContextAsync();

        var entity = await context.Projects.FindAsync(projectId);

        if (entity != null)
        {
            entity.Name = dto.Name;
            entity.Description = dto.Description;

            context.Projects.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}