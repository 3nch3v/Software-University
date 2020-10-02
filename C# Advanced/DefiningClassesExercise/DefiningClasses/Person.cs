namespace DefiningClasses
{
    public class Person
    {
        private const string NoName = "No name";
        private const int NoAge = 1;

        private string name;
        private int age;

        public Person()
        {
            this.Name = NoName;
            this.Age = NoAge;
        }
        public Person(int age)
            :this()
        {
            this.Name = NoName;
            this.Age = age;
        }
        public Person(string name, int age)
            :this(age)
        {
            this.Name = name;
            this.Age = age;
        }


        public string Name 
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

    }
}
