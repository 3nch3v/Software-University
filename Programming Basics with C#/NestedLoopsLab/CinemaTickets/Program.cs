using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string filmName = Console.ReadLine();

            int totalStudent = 0;
            int totalStandard = 0;
            int tolalKid = 0;

            while (filmName != "Finish")
            {
                int studentCounter = 0;
                int standardCounter = 0;
                int kidCounter = 0;

                int freePositions = int.Parse(Console.ReadLine());

                for (int currentSeat = 1; currentSeat <= freePositions; currentSeat++)
                {
                    string ticketType = Console.ReadLine();

                    if (ticketType == "student")
                    {
                        studentCounter++;
                    }

                    else if (ticketType == "standard")
                    {
                        standardCounter++;
                    }

                    else if (ticketType == "kid")
                    {
                        kidCounter++;
                    }

                    else if (ticketType == "End")
                    {
                        break;
                    }
                }

                totalStudent += studentCounter;
                totalStandard += standardCounter;
                tolalKid += kidCounter;

                Console.WriteLine($"{filmName} - {(studentCounter + standardCounter + kidCounter) / (double)freePositions * 100:F2}% full.");

                filmName = Console.ReadLine();
            }

            int totalTickets = tolalKid + totalStandard + totalStudent;

            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{totalStudent / (double)totalTickets * 100:f2}% student tickets.");
            Console.WriteLine($"{totalStandard / (double)totalTickets * 100:f2}% standard tickets.");
            Console.WriteLine($"{tolalKid / (double)totalTickets * 100:f2}% kids tickets.");
        }
    }
}
