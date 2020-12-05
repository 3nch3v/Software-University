using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int INITIAL_SIZE = 5;

        public SaltwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
        }

        public override int Size { get; protected set; } = INITIAL_SIZE;

        public override void Eat()
        {
            base.Eat();
            Size++;
        }
    }
}
