using System;

namespace GenericArrayCreator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var firsdtArrr = ArrayCreator.Create(5, 100);
            var secondArr = ArrayCreator.Create(5, "dasdad");
        }
    }
}
