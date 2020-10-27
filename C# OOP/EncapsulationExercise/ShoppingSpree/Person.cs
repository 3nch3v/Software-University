
using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<string> bag;

        public Person(string name, decimal money)
        {
            this.bag = new List<string>();
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                     throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public IReadOnlyCollection<string> Bag => this.bag.AsReadOnly();

        public void BuyProduct(Product product)
        {
            if (this.Money - product.Cost >= 0)
            {
                bag.Add(product.Name);
                this.Money -= product.Cost;

                Console.WriteLine($"{this.Name} bought {product.Name}");
            }

            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }

    }
}
