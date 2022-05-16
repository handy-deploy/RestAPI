namespace Domain.Services;

public interface IGitService
{
    Task<Guid> CloneRepository(Guid projectId, string mainBranch, string repositoryUrl,  CancellationToken cancellationToken);
}