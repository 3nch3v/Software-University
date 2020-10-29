using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> data = new List<IIdentifiable>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] currArgs = input.Split();

                if (currArgs.Length == 3)
                {
                    string name = currArgs[0];
                    int age = int.Parse(currArgs[1]);
                    string id = currArgs[2];
                    Citizen citizen = new Citizen(name, age, id);
                    data.Add(citizen);
                }

                else
                {
                    string model = currArgs[0];
                    string id = currArgs[1];

                    Robot robot = new Robot(model, id);
                    data.Add(robot);
                }
            }

            string fakeId = Console.ReadLine();

            foreach (var item in data)
            {
                if (item.Id.EndsWith(fakeId))
                {
                    Console.WriteLine(item.Id);
                }
            }
        }
    }
}
