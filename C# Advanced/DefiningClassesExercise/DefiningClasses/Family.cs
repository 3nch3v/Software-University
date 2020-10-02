
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> familyMembers;
        public Family()
        {
            familyMembers = new List<Person>();
        }
        public List<Person> FamilyMembers
        {
            get { return this.familyMembers; }
            set { this.familyMembers = value; }
        }
       
        public void AddMember(Person person)
        {
            FamilyMembers.Add(person);
        }

        public Person GetOldestMember()
        {
            return familyMembers.OrderByDescending(p => p.Age).First();
        }


        //private List<Person> familyMembers = new List<Person>();

        //public void AddMember(Person member)
        //{
        //    familyMembers.Add(member);
        //}

        //public Person GetOldestMember()
        //{
        //    int maxage = -1;

        //    Person oldestperson = new Person();

        //    foreach (var member in familyMembers)
        //    {
        //        if (member.Age > maxage)
        //        {
        //            maxage = member.Age;
        //            oldestperson = member;
        //        }
        //    }

        //    return oldestperson;
        //}

    }
}
