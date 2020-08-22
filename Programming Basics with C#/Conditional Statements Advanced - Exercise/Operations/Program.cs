using System;

namespace Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            string symbol = Console.ReadLine();

            string type = "";
            double result = 0.00;
            double rest = 0.00;

            if (symbol == "+" || symbol == "-" || symbol == "*")
            {
                switch (symbol)
                {
                    case "+": result = n1 + n2; break;
                    case "-": result = n1 - n2; break;
                    case "*": result = n1 * n2; break;
                }

                if (result % 2 == 0)
                {
                    type = "even";
                    Console.WriteLine($"{n1} {symbol} {n2} = {result} - {type}");
                }

                else
                {
                    type = "odd";
                    Console.WriteLine($"{n1} {symbol} {n2} = {result} - {type}");
                }

            }

            else if (symbol == "/" && n2 != 0)
            {
                result = n1 * 1.0 / n2;
                Console.WriteLine($"{n1} {symbol} {n2} = {result:f2}");
            }

            else if (symbol == "%" && n2 != 0)
            {
                rest = n1 % n2;
                Console.WriteLine($"{n1} {symbol} {n2} = {rest}");
            }

            else if (n2 == 0)
            {
                Console.WriteLine($"Cannot divide {n1} by zero");
            }
        }
    }
}
