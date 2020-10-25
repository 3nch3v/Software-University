
using System.Collections.Generic;

namespace PersonsInfo
{
    public class Team
    {
        private const int YongPlayerConstraint = 40;

        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public IReadOnlyCollection<Person> FirstTeam
        {
            get { return firstTeam.AsReadOnly(); }
        }
        public IReadOnlyCollection<Person> ReserveTeam
        {
            get { return reserveTeam.AsReadOnly(); }
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < YongPlayerConstraint)
            {
                this.firstTeam.Add(person);
            }

            else
            {
                this.reserveTeam.Add(person);
            }
        }
    }
}
