using System;

namespace PersonsInfo
{
    public class Person
    {
        private const decimal IncreaseSalaryAgeConstraint = 30;
        private const decimal MinSalary = 460;
        private const int MinLengthName = 3;

        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string name, string lastName, int age, decimal salary)
        {
            this.FirstName = name;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (value.Length < MinLengthName)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (value.Length < MinLengthName)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }

                this.lastName = value;
            }
        }

        public int Age
        {
            get  { return this.age;} 
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }

                this.age = value;
            }
        }

        public decimal Salary
        {
            get { return this.salary; }
            private set
            {
                if (value < MinSalary)
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva!");
                }

                this.salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age < IncreaseSalaryAgeConstraint)
            {
                this.Salary += this.Salary * (percentage / 200);
            }

            else
            {
                this.Salary += this.Salary * (percentage / 100);
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }
    }
}
