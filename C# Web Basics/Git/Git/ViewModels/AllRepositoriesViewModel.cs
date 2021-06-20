namespace Git.ViewModels
{
    using System.Collections.Generic;

    public class AllRepositoriesViewModel
    {
        public ICollection<RepositoryViewmodel> Repositories { get; set; }
    }
}
