
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> data;

        public Bag(string color, int capacity)
        {
            Color = color;
            Capacity = capacity;
            data = new List<Present>();
        }

        public string Color { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count;


        public void Add(Present present)
        {
            if (data.Count < Capacity)
            {
                data.Add(present);
            } 
        }

        public bool Remove(string name)
        {
            bool isExisting = false;

            if (data.Any(p => p.Name == name))
            {
                data.RemoveAll(p => p.Name == name);

                isExisting =  true;
            }

            return isExisting;
        }

        public Present GetHeaviestPresent()
        {
            Present present = data.OrderByDescending(p => p.Weight).First();

            return present;
        }

        public Present GetPresent(string name)
        {
            Present present = data.FirstOrDefault(p => p.Name == name);

            return present;
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine($"{Color} bag contains:");

            foreach (var present in data)
            {
                report.AppendLine(present.ToString());
            }

            return report.ToString().Trim();
        }  
    }
}
