
using System;
using System.Linq;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public void Call(string number)
        {
            if (!number.All(d => char.IsDigit(d)))
            {
                Console.WriteLine("Invalid number!");
            }

            else
            {
                Console.WriteLine($"Dialing... {number}");
            }
        }
    }
}
