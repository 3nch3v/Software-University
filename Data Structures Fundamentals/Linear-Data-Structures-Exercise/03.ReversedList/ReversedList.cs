namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) 
        { 
        }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
           
            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.items[this.Count - 1 - index];
            }
            set
            {
                this.ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.Grow();
            this.items[this.Count] = item;
            this.Count++;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this.items[i].Equals(item))
                {
                    return this.Count - 1 - i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.Grow();

            this.ShiftRight(this.Count - index);

            this.items[this.Count - index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            this.EnsureListNotEmpty();

            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this.items[i].Equals(item))
                {
                    this.ShiftLeft(i);
                    this.items[this.Count - 1] = default;
                    this.Count--;
                    this.Shrink();

                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            this.EnsureListNotEmpty();
            this.ValidateIndex(index);
            this.ShiftLeft(this.Count - 1 - index);
            this.items[this.Count - 1] = default;
            this.Count--;
            this.Shrink();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void Grow()
        {
            if (this.Count == this.items.Length)
            {
                T[] copy = new T[this.Count * 2];
                Array.Copy(this.items, copy, this.Count);
                this.items = copy;
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void Shrink()
        {
            if (this.items.Length / 4 == this.Count)
            {
                T[] copy = new T[this.items.Length / 2];
                Array.Copy(this.items, copy, this.Count);
                this.items = copy;
            }
        }

        private void EnsureListNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}