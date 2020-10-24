
using System;

namespace Person
{
    public class Person
    {
        //private string name;
        //private int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        //public string Name
        //{
        //    get
        //    {
        //        return name;
        //    }
        //    set
        //    {
        //        name = value;
        //    }

        //}

        //public int Age
        //{
        //    get
        //    {
        //        return age;
        //    }
        //    set
        //    {
        //        if (value < 0)
        //        {
        //            throw new ArgumentException("Age can not be negative number");
        //        }

        //        age = value;
        //    }

        //}

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }

    }
}
