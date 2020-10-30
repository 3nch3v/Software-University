
namespace BorderControl
{
    public class Pet : IPersonable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
        public string Name { get; set; }
        public string Birthdate { get; set; }
    }
}
