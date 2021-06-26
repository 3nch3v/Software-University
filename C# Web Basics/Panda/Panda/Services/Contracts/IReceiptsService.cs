using Panda.ViewModels.Receipts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Panda.Services.Contracts
{
    public interface IReceiptsService
    {
        ICollection<ReceiptViewModel> GetAll();

        Task CreateReceiptAsync(string id);
    }
}
