
using System;
using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> data;
        public Box()
        {
            this.data = new List<T>();
        }
        public int Count => data.Count;

        public void Add(T element)
        {
            this.data.Add(element);             
        }

        public T Remove()
        {
            if (this.Count == 0)
            {
                throw new NullReferenceException("No data");
            }

            var element = this.data[this.Count - 1];
            this.data.RemoveAt(this.Count - 1);

            return element;
        }
    }
}
