using System;

namespace TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());

            if (sales >= 0 && sales <= 500)
            {
                switch (city)
                {
                    case "Sofia": Console.WriteLine($"{sales * 0.05:f2}"); break;
                    case "Varna": Console.WriteLine($"{sales * 0.045:f2}"); break;
                    case "Plovdiv": Console.WriteLine($"{sales * 0.055:f2}"); break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }

            else if (sales > 500 && sales <= 1000)
            {
                switch (city)
                {
                    case "Sofia": Console.WriteLine($"{sales * 0.07:f2}"); break;
                    case "Varna": Console.WriteLine($"{sales * 0.075:f2}"); break;
                    case "Plovdiv": Console.WriteLine($"{sales * 0.08:f2}"); break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }

            else if (sales > 1000 && sales <= 10000)
            {
                switch (city)
                {
                    case "Sofia": Console.WriteLine($"{sales * 0.08:f2}"); break;
                    case "Varna": Console.WriteLine($"{sales * 0.10:f2}"); break;
                    case "Plovdiv": Console.WriteLine($"{sales * 0.12:f2}"); break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }

            else if (sales > 10000)
            {
                switch (city)
                {
                    case "Sofia": Console.WriteLine($"{sales * 0.12:f2}"); break;
                    case "Varna": Console.WriteLine($"{sales * 0.13:f2}"); break;
                    case "Plovdiv": Console.WriteLine($"{sales * 0.145:f2}"); break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }

            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
