using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();

            ICallable makeCall;

            foreach (var number in numbers)
            {
                if (number.Length == 10)
                {
                    makeCall = new Smartphone();
                    makeCall.Call(number);
                }

                else
                {
                    makeCall = new StationaryPhone();
                    makeCall.Call(number);
                }
            }

            string[] websites = Console.ReadLine().Split();      

            IBrowsable browseSite = new Smartphone();

            foreach (var site in websites)
            {
                browseSite.Browse(site);
            }
        }
    }
}
