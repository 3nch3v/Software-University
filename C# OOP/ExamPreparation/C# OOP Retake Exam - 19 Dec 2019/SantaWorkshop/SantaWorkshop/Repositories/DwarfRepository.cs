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
        private readonly ICollection<IDwarf> models;

        public DwarfRepository()
        {
            models = new List<IDwarf>();
        }

        public IReadOnlyCollection<IDwarf> Models => (IReadOnlyCollection<IDwarf>)models;


        public void Add(IDwarf model)
        {
            models.Add(model);
        }

        public bool Remove(IDwarf model)
        {
            return models.Remove(model);
        }

        public IDwarf FindByName(string name)
        {
            IDwarf dwarf = models.FirstOrDefault(d => d.Name == name);

            return dwarf;
        }
    }
}
