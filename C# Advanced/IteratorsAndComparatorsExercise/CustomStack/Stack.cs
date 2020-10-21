
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CustomStack
{
    class Stack<T> : IEnumerable<T>
    {
        private List<T> data;

        public Stack()
        {
            this.data = new List<T>();
        }

        public int Count => this.data.Count;

        public T Pop()
        {
            T element = this.data[^1];
            this.data.RemoveAt(this.data.Count -1);

            return element;
        }

        public void Push(T element)
        {
            this.data.Add(element);
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.data.Count - 1; i >= 0; i--)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
