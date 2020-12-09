using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Repositories.Contracts;

namespace SantaWorkshop.Repositories
{
    public class DwarfRepository : IRepository<IDwarf>
    {
        private ICollection<IDwarf> dwarves;

        public DwarfRepository()
        {
            dwarves = new List<IDwarf>();
        }

        public IReadOnlyCollection<IDwarf> Models => (IReadOnlyCollection<IDwarf>)dwarves;


        public void Add(IDwarf model)
        {
           dwarves.Add(model);
        }

        public bool Remove(IDwarf model)
        {
            return dwarves.Remove(model);
        }

        public IDwarf FindByName(string name)
        {
            return dwarves.FirstOrDefault(d => d.Name == name);
        }
    }
}
