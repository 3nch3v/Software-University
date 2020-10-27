using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Person> persons = new List<Person>();
                var clientsData = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (var client in clientsData)
                {
                    Person newPerson = CreatPerson(client);
                    persons.Add(newPerson);
                }

                List<Product> products = new List<Product>();
                var productsInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (var product in productsInfo)
                {
                    Product newProduct = CreatProduct(product);
                    products.Add(newProduct);
                }

                string comand;

                while ((comand = Console.ReadLine()) != "END")
                {
                    BuyProduct(comand, persons, products);
                }

                PrintResult(persons);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        static Person CreatPerson(string client)
        {
            var currClientArgs = client.Split('=', StringSplitOptions.RemoveEmptyEntries);
            string name = currClientArgs[0];
            decimal money = decimal.Parse(currClientArgs[1]);

            Person newPerson = new Person(name, money);
            return newPerson;
        }

        static Product CreatProduct(string product)
        {
            var currProductInfo = product.Split('=', StringSplitOptions.RemoveEmptyEntries);
            string name = currProductInfo[0];
            decimal money = decimal.Parse(currProductInfo[1]);

            Product newProduct = new Product(name, money);
            return newProduct;
        }

        static void BuyProduct(string comand, List<Person> persons, List<Product> products)
        {
            var currPerson = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = currPerson[0];
            string product = currPerson[1];

            Person currClient = persons.FirstOrDefault(c => c.Name == name);
            Product currProduct = products.FirstOrDefault(p => p.Name == product);
            currClient.BuyProduct(currProduct);
        }

        static void PrintResult(List<Person> persons)
        {
            foreach (var person in persons)
            {
                if (person.Bag.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Bag)}");
                }

                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }
}
