namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> head;

        private Node<T> tail;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currNode = this.head;

            while (currNode != null)
            {
                if (currNode.Item.Equals(item))
                {
                    return true;
                }

                currNode = currNode.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            EnsureEmptyQueue();

            var item = this.head.Item;
            this.head = this.head.Next;
            this.Count--;

            return item;
        }

        public void Enqueue(T item)
        {
            var newNode = new Node<T>
            {
                Item = item,
            };

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                this.tail.Next = newNode;
                this.tail = newNode;
            }

            this.Count++;
        }

        public T Peek()
        {
            EnsureEmptyQueue();
            return this.head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currNode = this.head;

            while (currNode != null)
            {
                yield return currNode.Item;
                currNode = currNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void EnsureEmptyQueue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}