
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            data = new List<Rabbit>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count;

        public void Add(Rabbit rabbit)
        {
            if (data.Count < Capacity)
            {
                data.Add(rabbit);
            }
        }
        public bool RemoveRabbit(string name)
        {
            if (data.Any(r => r.Name == name))
            {
                data.RemoveAll(r => r.Name == name);
                return true;
            }

            else
            {
                return false;
            }
        }
        public void RemoveSpecies(string species)   // bool ?
        {
            if (data.Any( r => r.Species == species))
            {
                data.RemoveAll(r => r.Species == species);
            }
        }
        public Rabbit SellRabbit(string name)
        {
            Rabbit rabbit = data.FirstOrDefault(r => r.Name == name);
            foreach (var rabitt in data)
            {
                if (rabitt.Name == name)
                {
                    rabitt.Available = false;
                }
            }
            return rabbit;
        }
        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            Rabbit[] rabbits = data.Where(r => r.Species == species).ToArray();
            data = data.Where(r => r.Species != species).ToList();
            return rabbits;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Rabbits available at {Name}:");

            foreach (var rabbit in data)
            {
                if (rabbit.Available == true)
                {
                    sb.AppendLine(rabbit.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
