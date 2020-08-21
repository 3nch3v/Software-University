using System;

namespace Ski
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string feedback = Console.ReadLine();

            int residence = days - 1;

            if (residence < 10)
            {
                if (feedback == "positive")
                {
                    switch (room)
                    {
                        case "room for one person": Console.WriteLine($"{(18.00 * residence) * 1.25:f2}"); break;
                        case "apartment": Console.WriteLine($"{((25.00 * residence) * 0.7) * 1.25:f2}"); break;
                        case "president apartment": Console.WriteLine($"{((35.00 * residence) * 0.9) * 1.25:f2}"); break;
                        default:
                            break;
                    }
                }

                else if (feedback == "negative")
                {
                    switch (room)
                    {
                        case "room for one person": Console.WriteLine($"{(18.00 * residence) * 0.9:f2}"); break;
                        case "apartment": Console.WriteLine($"{((25.00 * residence) * 0.7) * 0.9:f2}"); break;
                        case "president apartment": Console.WriteLine($"{((35.00 * residence) * 0.9) * 0.9:f2}"); break;
                        default:
                            break;
                    }
                }
            }

            else if (residence >= 10 && residence <= 15)
            {
                if (feedback == "positive")
                {
                    switch (room)
                    {
                        case "room for one person": Console.WriteLine($"{(18.00 * residence) * 1.25:f2}"); break;
                        case "apartment": Console.WriteLine($"{((25.00 * residence) * 0.65) * 1.25:f2}"); break;
                        case "president apartment": Console.WriteLine($"{((35.00 * residence) * 0.85) * 1.25:f2}"); break;
                        default:
                            break;
                    }
                }

                else if (feedback == "negative")
                {
                    switch (room)
                    {
                        case "room for one person": Console.WriteLine($"{(18.00 * residence) * 0.9:f2}"); break;
                        case "apartment": Console.WriteLine($"{((25.00 * residence) * 0.65) * 0.9:f2}"); break;
                        case "president apartment": Console.WriteLine($"{((35.00 * residence) * 0.85) * 0.9:f2}"); break;
                        default:
                            break;
                    }
                }
            }

            else if (residence > 15)
            {
                if (feedback == "positive")
                {
                    switch (room)
                    {
                        case "room for one person": Console.WriteLine($"{(18.00 * residence) * 1.25:f2}"); break;
                        case "apartment": Console.WriteLine($"{((25.00 * residence) * 0.5) * 1.25:f2}"); break;
                        case "president apartment": Console.WriteLine($"{((35.00 * residence) * 0.8) * 1.25:f2}"); break;
                        default:
                            break;
                    }
                }

                else if (feedback == "negative")
                {
                    switch (room)
                    {
                        case "room for one person": Console.WriteLine($"{(18.00 * residence) * 0.9:f2}"); break;
                        case "apartment": Console.WriteLine($"{((25.00 * residence) * 0.5) * 0.9:f2}"); break;
                        case "president apartment": Console.WriteLine($"{((35.00 * residence) * 0.8) * 0.9:f2}"); break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
