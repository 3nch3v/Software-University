namespace Git.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Git.ViewModels;

    public interface ICommitsService
    {
        List<string> CommitInputModelValidation(CommitInputmodel input);

        Task CreateCommitAsync(CommitInputmodel input);

        ICollection<CommitViewModel> GetAll(string userId);

        string GetCreatorId(string id);

        Task DeleteAsync(string id);
    }
}