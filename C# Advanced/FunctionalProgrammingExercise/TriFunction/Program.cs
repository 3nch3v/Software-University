using System;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> isValidName = (name, n) => name.ToCharArray().Select(ch => (int)ch).Sum() >= n;

            Func<string[], int, Func<string, int, bool>, string> firstValidName = (names, n, func) => names.FirstOrDefault(name => func(name, n));

            string result = firstValidName(names, n, isValidName);
            Console.WriteLine(result);
        }
    }
}
