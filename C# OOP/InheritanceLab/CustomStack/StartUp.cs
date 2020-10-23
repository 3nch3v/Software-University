using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings st = new StackOfStrings();
            Console.WriteLine(st.IsEmpty());
            st.AddRange(new string[] {"something", "text", "word"});
            st.Pop();
            Console.WriteLine(st.IsEmpty());
        }
    }
}
