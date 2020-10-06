
namespace VetClinic
{
    public class Pet
    {
        public Pet(string name, int age, string owner)
        {
            this.Name = name;
            this.Age = age;
            this.Owner = owner;
        }
        public string Name { get;  }

        public int Age { get; }

        public string Owner { get;  }

        public override string ToString()
        {
            return $"Name: {this.Name} Age: {this.Age} Owner: {this.Owner}";
        }
    }
}
