using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected List<T> models;

        protected Repository()
        {
            models = new List<T>();
        }


        public void Add(T model)
        {
            models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll() => models.AsReadOnly();

        public abstract T GetByName(string name);
        
        public bool Remove(T model)
        {
          return  models.Remove(model);
        }
    }
}
