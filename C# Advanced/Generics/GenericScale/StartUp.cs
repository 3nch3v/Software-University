using System;

namespace GenericScale
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var scale = new EqualityScale<int>(6, 6);

            Console.WriteLine(scale.AreEqual());
        }
    }
}
