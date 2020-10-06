
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            this.data = new List<Pet>();
            this.Capacity = capacity;
        }
        public int Capacity { get; }

        public int Count => data.Count;
        public void Add(Pet pet)
        {
            if (data.Count < this.Capacity)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            bool isValidName = false;

            if (data.Any(a => a.Name == name))
            {
                data.RemoveAll(a => a.Name == name);
                isValidName = true;
            }

            return isValidName;
        }

        public Pet GetPet(string name, string owner)
        {
            return data.FirstOrDefault(a => a.Name == name && a.Owner == owner);
        }

        public Pet GetOldestPet()
        {
            Pet theOldest = data.OrderByDescending(a => a.Age).First();
            return theOldest;
        }

        public string GetStatistics()
        {
            StringBuilder statistic = new StringBuilder();

            statistic.AppendLine("The clinic has the following patients:");

            foreach (var pet in data)
            {
                statistic.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return statistic.ToString().Trim();
        }
    }
}
