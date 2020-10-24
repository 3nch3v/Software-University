
using System;

namespace Person
{
    public class Child : Person
    {
        //private int age;
        public Child(string name, int age) 
            : base(name, age)
        {
            //Age = age;
        }

        //public int Age
        //{
        //    get
        //    {
        //        return age;
        //    }
        //    set
        //    {
        //        if (value > 15)
        //        {
        //            throw new ArgumentException("The age is over 15");
        //        }

        //        age = value;
        //    }
        //}
    }
}
