namespace Git.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Git.ViewModels;

    public interface IRepositoriesService
    {
        List<string> IsInputModelValid(RepositoryInputModel input);

        Task CreateRepositoryAsync(RepositoryInputModel input);

        ICollection<RepositoryViewmodel> GetAll();

        CommitRepoViewModel GetRepository(string id);
    }
}
