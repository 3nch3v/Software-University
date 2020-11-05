
using CollectionHierarchy2.Contracts;
using System.Collections;
using System.Collections.Generic;

namespace CollectionHierarchy2.Models
{
    public class AddCollection<T> : IAddble<T>
    {

        public AddCollection()
        {
            Data = new List<T>();
        }

        public List<T> Data { get; private set; }

        public virtual int Add(T element)
        {
            Data.Add(element);
            return Data.Count - 1;
        }
    }
}
