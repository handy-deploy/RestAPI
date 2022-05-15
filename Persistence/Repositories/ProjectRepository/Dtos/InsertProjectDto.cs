namespace Persistence.Repositories.ProjectRepository.Dtos;

public class InsertProjectDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string VCSUrl { get; set; }
}