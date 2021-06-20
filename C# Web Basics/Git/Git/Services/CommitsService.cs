namespace Git.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Git.Data;
    using Git.Data.Models;
    using Git.Services.Contracts;
    using Git.ViewModels;

    using static Git.Common.GlobalConstants;

    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext dbContext;

        public CommitsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<string> CommitInputModelValidation(CommitInputmodel input)
        {
            var errorList = new List<string>();

            if (string.IsNullOrWhiteSpace(input.Description)
                || input.Description.Length < CommitDescriptionMinLength)
            {
                errorList.Add(InvalidCommitDescription);
            }

            return errorList;
        }

        public async Task CreateCommitAsync(CommitInputmodel input)
        {
            var commit = new Commit
            {
                Description = input.Description,
                CreatorId = input.CreatorId,
                CreatedOn = DateTime.UtcNow,
                RepositoryId = input.Id,
            };

            await this.dbContext.AddAsync(commit);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var commit = this.dbContext.Commits
               .Where(c => c.Id == id)
               .FirstOrDefault();

            this.dbContext.Remove(commit);
            await this.dbContext.SaveChangesAsync();
        }

        public ICollection<CommitViewModel> GetAll(string userId)
        {
            var commits = this.dbContext.Commits
                .Where(c => c.CreatorId == userId)
                .Select(c => new CommitViewModel 
                {
                    Id = c.Id,
                    Description = c.Description,
                    CreatedOn = c.CreatedOn.ToString("d"),
                    RepositoryName = c.Repository.Name,
                })
                .ToList();

            return commits;
        }

        public string GetCreatorId(string id)
        {
            return this.dbContext.Commits
                .Where(c => c.Id == id)
                .First()
                .CreatorId;
        }
    }
}
