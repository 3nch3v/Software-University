namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;

        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newHead = new Node<T>
            {
                Item = item,
            };

            if (this.Count == 0)
            {
                this.head = this.tail = newHead;
            }
            else
            {
                newHead.Next = this.head;
                this.head.Previous = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            var newTail = new Node<T>
            {
                Item = item,
            };

            if (this.Count == 0)
            {
                this.head = this.tail = newTail;
            }
            else
            {
                newTail.Previous = this.tail;
                this.tail.Next = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            EnsureEmptyList();
            return this.head.Item;
        }

        public T GetLast()
        {
            EnsureEmptyList();
            return this.tail.Item;
        }

        public T RemoveFirst()
        {
            EnsureEmptyList();

            var item = this.head;
            this.head.Previous = null;
            this.head = this.head.Next;

            this.Count--;

            if (this.Count == 0)
            {
                this.head = this.tail = null;
            }

            return item.Item;
        }

        public T RemoveLast()
        {
            EnsureEmptyList();
            var item = this.tail;
            this.tail.Next = null;
            this.tail = this.tail.Previous;

            this.Count--;

            if (this.Count == 0)
            {
                this.head = this.tail = null;
            }

            return item.Item;
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

        private void EnsureEmptyList()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}