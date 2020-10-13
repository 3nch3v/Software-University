
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            this.data = new List<Car>();
            this.Type = type;
            this.Capacity = capacity;
        }
        public string Type { get; set; }
        public int Capacity { get; set; }

        public int Count => data.Count;

        public void Add(Car car)
        {
            if (this.data.Count < Capacity)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            bool exist = false;

            if (data.Any(c => c.Manufacturer == manufacturer && c.Model == model))
            {
                exist = true;
                data.RemoveAll(c => c.Manufacturer == manufacturer && c.Model == model);
            }

            return exist;
        }

        public Car GetLatestCar()
        {
            Car latestCar = null;

            if (data.Count > 0)
            {
                latestCar = data.OrderByDescending(c => c.Year).First();
            }

            return latestCar;
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car car = null;

            if (data.Any(c=> c.Manufacturer == manufacturer && c.Model == model))
            {
                car = data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            }

            return car;
        }

        public string GetStatistics()
        {
            StringBuilder statistic = new StringBuilder();

            statistic.AppendLine($"The cars are parked in {this.Type}:");

            foreach (var car in data)
            {
                statistic.AppendLine(car.ToString());
            }

            return statistic.ToString();
        }
    }
}
