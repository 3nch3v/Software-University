using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {

        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get { return name;}
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }
        public Dough Dough
        {
            get { return dough;}
            set { dough = value; }
        }

        public int ToppingsCount => toppings.Count;
        public double TotalCalories => CalculateCalories();


        public void AddTopping(Topping topping)
        {
            if (toppings.Count >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);
        }

        private double CalculateCalories()
        {
            double total = dough.TotalCalories;

            foreach (var topping in toppings)
            {
                total += topping.TotalCalories;
            }

            return total;
        }

        public override string ToString()
        {
            return $"{Name} - {TotalCalories:f2} Calories.";
        }
    }
}
