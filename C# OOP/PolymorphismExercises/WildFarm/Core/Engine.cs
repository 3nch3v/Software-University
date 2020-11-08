using System;
using System.Collections.Generic;

using WildFarm.Core.Contracts;
using WildFarm.IO.Contracts;
using WildFarm.Models;
using WildFarm.Models.Birds;
using WildFarm.Models.Foods;
using WildFarm.Models.Mammels;
using WildFarm.Models.Mammels.Felines;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private ICollection<Animal> animals;

        public Engine(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
            animals = new List<Animal>();
        }

        public void Run()
        {
            int lineCounter = 0;
            Animal animal = null;

            string comand;

            while ((comand = this.reader.Reader()) != "End")
            {
                string[] currTokens = comand.Split(' ');
                string type = currTokens[0];

                if (lineCounter % 2 == 0)
                {
                    string name = currTokens[1];
                    double weight = double.Parse(currTokens[2]);

                    try
                    {
                        switch (type)
                        {
                            case "Owl": 
                                double wingSize = double.Parse(currTokens[3]);
                                animal = new Owl(name, weight, wingSize); 
                                break;
                            case "Hen":
                                double henWingSize = double.Parse(currTokens[3]);
                                animal = new Hen(name, weight, henWingSize); 
                                break;
                            case "Mouse":
                                string livingRegion = currTokens[3];
                                animal = new Mouse(name, weight, livingRegion);
                                break;
                            case "Dog":
                                string dogRegion = currTokens[3];
                                animal = new Dog(name , weight, dogRegion);
                                break;
                            case "Cat":
                                string catRegion = currTokens[3];
                                string breed = currTokens[4];
                                animal = new Cat(name, weight, catRegion, breed);
                                break;
                            case "Tiger":
                                string tigerRegion = currTokens[3];
                                string tigerBreed = currTokens[4];
                                animal = new Tiger(name, weight, tigerRegion, tigerBreed);
                                break;
                        }
                    }
                    catch (ArgumentException e)
                    {
                        this.writer.WriteLine(e.Message);
                    }

                    if (animal != null)
                    {
                        animals.Add(animal);
                    }
                }

                else
                {
                    int qty = int.Parse(currTokens[1]);
                    Food food = null;

                    try
                    {
                        switch (type)
                        {
                            case "Vegetable": food = new Vegetable(qty); break;
                            case "Fruit": food = new Fruit(qty); break;
                            case "Meat": food = new Meat(qty); break;
                            case "Seeds": food = new Seeds(qty); break;
                        }
                    }
                    catch (ArgumentException e)
                    {
                        this.writer.WriteLine(e.Message);
                    }

                    this.writer.WriteLine(animal.ProducingSound());

                    try
                    {
                        animal.FeedAnimal(food);
                    }
                    catch (ArgumentException e)
                    {
                        this.writer.WriteLine(e.Message);
                    }
                }

                lineCounter++;
            }

            foreach (var currAnimal in animals)
            {
                this.writer.WriteLine(currAnimal.ToString());
            }
        }
    }
}
