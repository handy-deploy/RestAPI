using Persistence.Models;
using Persistence.Repositories.ProjectRepository.Dtos;

namespace Persistence.Repositories;

public interface IProjectRepository
{
    Task<Project?> Insert(InsertProjectDto dto);
    Task Delete(Guid projectId);
    Task<IEnumerable<Project>> GetAll();
    Task Update(Guid projectId, UpdateProjectDto dto);
}