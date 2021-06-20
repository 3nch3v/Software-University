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

    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext dbContext;

        public RepositoriesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateRepositoryAsync(RepositoryInputModel input)
        {
            var repository = new Repository
            {
                Name = input.Name,
                IsPublic = input.RepositoryType == "Public" ? true : false,
                CreatedOn = DateTime.UtcNow,
                OwnerId = input.OwnerId,             
            };

            await this.dbContext.Repositories.AddAsync(repository);
            await this.dbContext.SaveChangesAsync();
        }

        public ICollection<RepositoryViewmodel> GetAll()
        {
            var repositories = this.dbContext.Repositories
                .Where(r => r.IsPublic == true)
                .Select(r => new RepositoryViewmodel
                {
                    Date = r.CreatedOn.ToString("d"),
                    Id = r.Id,
                    Name = r.Name,
                    Username = r.Owner.Username,
                    CommitsCount = r.Commits.Count,
                })
                .ToList();

            return repositories;
        }

        public CommitRepoViewModel GetRepository(string id)
        {
            var repository = this.dbContext.Repositories
               .Where(r => r.Id == id)
               .Select(r => new CommitRepoViewModel
               {
                   Id = r.Id,
                   Name = r.Name,
               })
               .FirstOrDefault();

            return repository;
        }

        public List<string> IsInputModelValid(RepositoryInputModel input)
        {
            var errorList = new List<string>();

            if (string.IsNullOrWhiteSpace(input.Name) 
                || input.Name.Length > RepositoryNameMaxLength 
                || input.Name.Length < RepositoryNameMinLength)
            {
                errorList.Add(string.Format(InvalidRepositoryName, RepositoryNameMinLength, RepositoryNameMaxLength));
            }

            if (string.IsNullOrWhiteSpace(input.RepositoryType)
                || (input.RepositoryType != PublicType 
                    && input.RepositoryType != PrivateType))
            {
                errorList.Add(InvalidRepositoryType);
            }

            return errorList;
        }
    }
}
