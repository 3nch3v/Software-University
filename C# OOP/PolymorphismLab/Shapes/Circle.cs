
using System;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double r)
        {
            this.radius = r;
        }

        public override double CalculatePerimeter()
        {
            return Math.PI * (2 * this.radius);
        }

        public override double CalculateArea()
        {

            return Math.PI * Math.Pow(this.radius, 2);
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
