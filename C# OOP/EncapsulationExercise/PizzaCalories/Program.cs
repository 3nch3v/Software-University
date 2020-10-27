using System;
using System.Threading;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Pizza pizza = null;

                string input;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] currArgs = input.Split(" ");
                    string comand = currArgs[0];

                    if (comand == "Pizza")
                    {
                        pizza = new Pizza(currArgs[1]);
                    }

                    else if (comand == "Dough")
                    {
                        Dough dough = new Dough(currArgs[1], currArgs[2], double.Parse(currArgs[3]));
                        pizza.Dough = dough;
                    }

                    else if (comand == "Topping")
                    {
                        Topping topping = new Topping(currArgs[1], double.Parse(currArgs[2]));
                        pizza.AddTopping(topping);
                    }
                }

                Console.WriteLine(pizza.ToString());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
    }
}
