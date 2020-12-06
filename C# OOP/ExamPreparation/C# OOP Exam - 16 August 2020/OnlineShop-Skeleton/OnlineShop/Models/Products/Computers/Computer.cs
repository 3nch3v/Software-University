using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        protected List<IComponent> components;
        protected List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }


        public IReadOnlyCollection<IComponent> Components => components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.AsReadOnly();


        public override decimal Price => base.Price + Peripherals.Sum(p => p.Price) + Components.Sum(c => c.Price);

        public override double OverallPerformance => CalculateOverallPerformance();

        private double CalculateOverallPerformance()
        {
          return  Components.Count == 0
                    ? base.OverallPerformance
                    : base.OverallPerformance + Components.Average(c => c.OverallPerformance);
        }

        public void AddComponent(IComponent component)
        {
            if (Components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent,
                    component.GetType().Name, this.GetType().Name, this.Id));
            }

            components.Add(component);
        }


        public IComponent RemoveComponent(string componentType)
        {
            IComponent component = Components.FirstOrDefault(c => c.GetType().Name == componentType);

            if (component == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            components.Remove(component);

            return component;
        }


        public void AddPeripheral(IPeripheral peripheral)
        {
            if (Peripherals.Any(p => p.GetType() == peripheral.GetType()))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            peripherals.Add(peripheral);
        }


        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peripheral = Peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);

            if (peripheral == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            peripherals.Remove(peripheral);

            return peripheral;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({Components.Count}):");

            foreach (var component in components)
            {
                sb.AppendLine($"  {component}");
            }

            double aop = 0;

            if (peripherals.Count > 0)
            {
                aop =  peripherals.Average(p => p.OverallPerformance);
            }

            sb.AppendLine($" Peripherals ({Peripherals.Count}); Average Overall Performance ({aop:f2}):");

            foreach (var peripheral in peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
