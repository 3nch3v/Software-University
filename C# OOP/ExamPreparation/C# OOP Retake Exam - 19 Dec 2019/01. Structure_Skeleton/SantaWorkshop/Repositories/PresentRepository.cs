using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories.Contracts;

namespace SantaWorkshop.Repositories
{
    public class PresentRepository : IRepository<IPresent>
    {
        private ICollection<IPresent> presents;

        public PresentRepository()
        {
            presents = new List<IPresent>();
        }

        public IReadOnlyCollection<IPresent> Models => (IReadOnlyCollection<IPresent>)presents;


        public void Add(IPresent model)
        {
            presents.Add(model);
        }

        public bool Remove(IPresent model)
        {
            return presents.Remove(model);
        }

        public IPresent FindByName(string name)
        {
            return presents.FirstOrDefault(d => d.Name == name);
        }
    }
}
