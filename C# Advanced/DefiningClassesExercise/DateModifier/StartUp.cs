using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateModifier date = new DateModifier(firstDate, secondDate);

            Console.WriteLine(date.CalculateDifference());
        }
    }
}
