using System;

namespace ReadText
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            for (int i = 0; i < int.MaxValue; i++)
            {
                text = Console.ReadLine();

                if (text == "Stop")
                {
                    break;
                }
            }
        }
    }
}
