namespace Git.ViewModels
{
    using System.Collections.Generic;

    public class AllCommitsViewModel
    {
        public ICollection<CommitViewModel> Commits { get; set; }
    }
}
