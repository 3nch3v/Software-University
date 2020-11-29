using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Entities;

namespace EasterRaces.Models.Cars.Entities
{
    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
        {
            IRace race = this.models.FirstOrDefault(m => m.Name == name);
            return race;
        }
    }
}
