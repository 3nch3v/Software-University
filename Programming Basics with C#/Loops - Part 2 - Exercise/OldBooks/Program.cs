using System;

namespace OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookName = Console.ReadLine();
            int bookCount = int.Parse(Console.ReadLine());

            string currentBook = Console.ReadLine();
            int counter = 0;

            while (currentBook != bookName)
            {
                counter++;

                if (bookCount == counter)
                {
                    break;
                }

                currentBook = Console.ReadLine();
            }

            if (bookName == currentBook)
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }

            else
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");
            }
        }
    }
}
