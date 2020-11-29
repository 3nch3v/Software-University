using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Entities;

namespace EasterRaces.Models.Cars.Entities
{
    public class DriverRepository : Repository<IDriver>
    {
        public override IDriver GetByName(string name)
        {
            IDriver driver = this.models.FirstOrDefault(m => m.Name == name);
            return driver;
        }
    }
}
