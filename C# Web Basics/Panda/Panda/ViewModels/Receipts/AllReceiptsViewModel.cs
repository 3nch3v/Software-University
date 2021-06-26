namespace Panda.ViewModels.Receipts
{
    using System.Collections.Generic;

    public class AllReceiptsViewModel
    {
        public ICollection<ReceiptViewModel> Receipts { get; set; }
    }
}
