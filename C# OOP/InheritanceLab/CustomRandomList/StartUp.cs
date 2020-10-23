using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {

           RandomList randomList = new RandomList(new string[] {"da", "ne", "may be", "yes", "no", "sorry"});

           Console.WriteLine(randomList.RandomString());
           Console.WriteLine(randomList.RandomString());
           Console.WriteLine(randomList.RandomString());
           Console.WriteLine(randomList.RandomString());
        }
    }
}
