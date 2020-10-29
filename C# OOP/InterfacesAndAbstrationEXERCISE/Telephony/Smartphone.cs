
using System;
using System.Linq;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public void Browse(string url)
        {
            if (url.Any(ch => char.IsDigit(ch)))
            {
                Console.WriteLine("Invalid URL!");
            }

            else
            {
                Console.WriteLine($"Browsing: {url}!");
            }
        }

        public void Call(string number)
        {
            if (!number.All(d => char.IsDigit(d)))
            {
                Console.WriteLine("Invalid number!");
            }

            else
            {
                Console.WriteLine($"Calling... {number}");
            }
        }
    }
}
