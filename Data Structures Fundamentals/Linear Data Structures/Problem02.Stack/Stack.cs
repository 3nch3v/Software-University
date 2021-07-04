namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> top;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            Node<T> currItem = this.top;

            while (currItem != null)
            {
                if (currItem.Value.Equals(item))
                {
                    return true;
                }

                currItem = currItem.Next;
            }

            return false;
        }

        public T Peek()
        {
            this.EnsureNotEmpty();

            return this.top.Value;
        }

        public T Pop()
        {
            this.EnsureNotEmpty();

            T item = this.top.Value;
            Node<T> newTop = this.top.Next;
            this.top.Next = null;
            this.top = newTop;
            this.Count--;

            return item;
        }

        public void Push(T item)
        {
            Node<T> newNode = new Node<T>
            {
                Value = item,
                Next = this.top
            };

            this.top = newNode; 
            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> item = this.top;

            while (item != null)
            {
                yield return item.Value;
                item = item.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (top == null)
            {
                throw new InvalidOperationException("The stack is empty.");
            }
        }
    }
}