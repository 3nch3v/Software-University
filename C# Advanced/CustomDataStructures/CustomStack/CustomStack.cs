
using System;

namespace CustomStack
{
    class CustomStack
    {
        private const int initialCapacity = 4;
        private int[] items;
        private int count;

        public CustomStack()
        {
            this.items = new int[initialCapacity];
            this.count = 0;
        }

        public int Count => this.count;


        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        public void Push(int element)
        {
            if (this.count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.count] = element;
            count++;
        }

        public int Pop()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            int lastElement = this.items[this.count - 1];

            this.items[this.count - 1] = default(int);

            if (this.items.Length <= this.items.Length / 4)
            {
                this.Shrink();
            }

            count--;
            return lastElement;
        }

        public int Peek()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            int last = this.count - 1;

            return this.items[last];
        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this.items.Length; i++)
            {
                action(this.items[i]);
            }
        }









    }
}
