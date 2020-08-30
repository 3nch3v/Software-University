using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int w = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            string comand = Console.ReadLine();

            int area = w * l;
            int pieces = 0;

            while (comand != "STOP")
            {
                int piecesNeeded = int.Parse(comand);

                pieces += piecesNeeded;

                if (pieces > area)
                {
                    break;
                }

                comand = Console.ReadLine();
            }


            if (comand == "STOP")
            {
                Console.WriteLine($"{area - pieces} pieces are left.");
            }

            if (pieces > area)
            {
                Console.WriteLine($"No more cake left! You need {pieces - area} pieces more.");
            }
        }
    }
}
