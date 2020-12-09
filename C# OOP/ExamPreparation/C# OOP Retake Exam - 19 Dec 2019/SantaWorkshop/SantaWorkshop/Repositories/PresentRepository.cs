
using System.Collections.Generic;
using System.Linq;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories.Contracts;

namespace SantaWorkshop.Repositories
{
    public class PresentRepository : IRepository<IPresent>
    {
        private readonly ICollection<IPresent> models;

        public PresentRepository()
        {
            models = new List<IPresent>();
        }

        public IReadOnlyCollection<IPresent> Models => (IReadOnlyCollection<IPresent>)models;


        public void Add(IPresent model)
        {
            models.Add(model);
        }

        public bool Remove(IPresent model)
        {
            return models.Remove(model);
        }

        public IPresent FindByName(string name)
        {
            IPresent present = models.FirstOrDefault(d => d.Name == name);

            return present;
        }
    }
}
