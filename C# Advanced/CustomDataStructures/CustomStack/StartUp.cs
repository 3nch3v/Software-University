using System;

namespace CustomStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack stack = new CustomStack();

            stack.Push(55);
            stack.Push(66);
            stack.Push(77);
            stack.Push(88);
            stack.Push(99);

            stack.Peek();

            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();

            stack.Peek();
        }
    }
}
