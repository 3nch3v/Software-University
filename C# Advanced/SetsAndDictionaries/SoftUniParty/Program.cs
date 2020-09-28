using System;
using System.Collections.Generic;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();

            string reservationNumbers;

            while ((reservationNumbers = Console.ReadLine()) != "PARTY")
            {
                char prefix = reservationNumbers[0];

                if (char.IsDigit(prefix))
                {
                    vipGuests.Add(reservationNumbers);
                }

                else
                {
                    regularGuests.Add(reservationNumbers);
                }
            }

            string cameToTheParty;

            while ((cameToTheParty = Console.ReadLine()) != "END")
            {
                if (vipGuests.Contains(cameToTheParty))
                {
                    vipGuests.Remove(cameToTheParty);
                }

                if (regularGuests.Contains(cameToTheParty))
                {
                    regularGuests.Remove(cameToTheParty);
                }
            }

            int didNotCome = vipGuests.Count + regularGuests.Count;
            Console.WriteLine(didNotCome);

            foreach (var guest in vipGuests)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in regularGuests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
