
using System.Collections.Generic;

namespace CustomStack
{
    class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public Stack<string> AddRange(IEnumerable<string> newData)
        {
            foreach (var item in newData)
            {
                this.Push(item);
            }

            return this;
        }
    }
}
