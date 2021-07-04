namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newHead = new Node<T>
            { 
                Value = item,
                Next = this.head,
            };

            if (head == null)
            {
                this.head = newHead;
            }
            else
            {
                newHead.Next = this.head;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            Node<T> newLast = new Node<T>
            {
                Value = item,
            };

            if (this.head == null)
            {
                this.head = newLast;
            }
            else
            {
                Node<T> curr = this.head;

                while (curr.Next != null)
                {
                    curr = curr.Next;
                }

                curr.Next = newLast;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            EnsureNotEmpty();
            return this.head.Value;
        }

        public T GetLast()
        {
            EnsureNotEmpty();

            Node<T> curr = this.head;

            if (this.Count == 1)
            {
                return curr.Value;
            }

            while (curr.Next != null)
            {
                curr = curr.Next;
            }

            return curr.Value;
        }

        public T RemoveFirst()
        {
            EnsureNotEmpty();

            T item = this.head.Value;
            var newHead = this.head.Next;
            this.head = newHead;
            this.Count--;

            return item;
        }

        public T RemoveLast()
        {
            EnsureNotEmpty();

            T item = default;

            if (this.Count == 1)
            {
                item = this.head.Value;
                this.head = null;
            }
            else
            {
                Node<T> curr = this.head;
                Node<T> previus = new Node<T>();

                while (curr.Next != null)
                {
                    previus = curr;
                    curr = curr.Next;
                }

                item = curr.Value;
                previus.Next = null;
            }
            
            this.Count--;

            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var curr = this.head;
            while (curr != null)
            {
                yield return curr.Value;

                curr = curr.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("The list is empty.");
            }
        }
    }
}