namespace CarShop.Services.Contracts
{
    using System.Threading.Tasks;

    using CarShop.Data.Models;
    using CarShop.ViewModels;

    public interface IIssuesService
    {
        Car CarIssues(string carId);

        Task DeleteIssue(string issueId, string carId);

        Task Fix(string issueId, string carId);

        Task AddCarIssue(IssueInputModel input);

    }
}
