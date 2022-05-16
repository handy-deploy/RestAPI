using System.Runtime.InteropServices.ComTypes;
using LibGit2Sharp;

namespace Domain.Services.GitService;

public class GitService : IGitService
{
    public async Task<Guid> CloneRepository(Guid projectId, string mainBranch, string repositoryUrl, CancellationToken cancellationToken)
    {
        var id = Guid.NewGuid();

        await Task.Factory.StartNew(() =>
        {
            try
            {
                Repository.Clone(repositoryUrl, $"projects/", new CloneOptions
                {
                    Checkout = true,
                    BranchName = mainBranch,
                    OnProgress = _ => !cancellationToken.IsCancellationRequested,
                    OnTransferProgress = _ =>
                    {
                        if (cancellationToken.IsCancellationRequested)
                            return false;

                        return true;
                    },
                    OnUpdateTips = (_, _, _) => !cancellationToken.IsCancellationRequested
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }, cancellationToken, TaskCreationOptions.LongRunning, TaskScheduler.Current).ConfigureAwait(false);

        return id;
    }
}