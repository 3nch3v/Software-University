namespace CarShop.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.Services.Contracts;
    using CarShop.ViewModels;

    public class IssuesService : IIssuesService
    {
        private readonly ApplicationDbContext dbContext;

        public IssuesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddCarIssue(IssueInputModel input)
        {
            var issue = new Issue
            {
                Description = input.Description,
                CarId = input.CarId,
                IsFixed = false,
            };

            await this.dbContext.Issues.AddAsync(issue);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteIssue(string issueId, string carId)
        {
            var issue = this.dbContext.Issues.FirstOrDefault(i => i.Id == issueId && i.CarId == carId);
            this.dbContext.Issues.Remove(issue);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task Fix(string issueId, string carId)
        {
            var issue = this.dbContext.Issues.FirstOrDefault(i => i.Id == issueId && i.CarId == carId);
            issue.IsFixed = true;
            await this.dbContext.SaveChangesAsync();
        }
        public Car CarIssues(string carId)
        {
            var car = this.dbContext.Cars
                .Include(x => x.Issues)
                .FirstOrDefault(c => c.Id == carId);
            return car;
        }
    }
}
