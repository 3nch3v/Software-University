namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> head;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            Node<T> currNode = this.head;

            while (currNode != null)
            {
                if (currNode.Value.Equals(item))
                {
                    return true;
                }

                currNode = currNode.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            this.EnsureNotEmpty();

            T item = this.head.Value;
            this.head = this.head.Next;
            this.Count--;

            return item;
        }

        public void Enqueue(T item)
        {
            var newHead = new Node<T>
            {
                Value = item,
            };

            if (this.Count == 0)
            {
                this.head = newHead;
            }
            else
            {
                var current = this.head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newHead;
            }

            this.Count++;
        }

        public T Peek()
        {
            this.EnsureNotEmpty();
            return head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currNode = this.head;

            while (currNode != null)
            {
                yield return currNode.Value;
                currNode = currNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("The queue is empty.");
            }
        }
    }
}