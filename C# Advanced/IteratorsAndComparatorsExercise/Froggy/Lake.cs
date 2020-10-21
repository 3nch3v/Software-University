using System;
using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    public class Lake<T> : IEnumerable<T>
    {
        private readonly T[] stones;

        public Lake(params T[] elements)
        {
            this.stones = elements;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Length; i +=2)
            {
                yield return this.stones[i];
            }

            for (int i = this.stones.Length - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return this.stones[i];
                }   
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
