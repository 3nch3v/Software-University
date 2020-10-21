
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator 
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> data;
        private int index;

        public ListyIterator(List<T> elements)
        {
            this.data = new List<T>(elements);
            this.index = 0;
        }

        public int Count => this.data.Count;
  
        public bool Move()
        {
            if (HasNext())
            {
                this.index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (this.index < this.Count - 1)
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.data[this.index]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in this.data)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
