using System;
using System.Linq;

namespace DateModifier
{
    public class DateModifier
    {
        private string firstDate;
        private string secondDate;
        public DateModifier(string firstDate, string secondDate)
        {
            this.FirstDate = firstDate;
            this.SecondDate = secondDate;
        }
        public string FirstDate
        {
            get
            {
                return this.firstDate;
            }
            set
            {
                this.firstDate = value;
            }
        }

        public string SecondDate
        {
            get
            {
                return this.secondDate;
            }
            set
            {
                this.secondDate = value;
            }
        }

        public int CalculateDifference()
        {
            int[] firstDateArgs = FirstDate
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] secondDate = SecondDate
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int firstYear = firstDateArgs[0];
            int firstMonth = firstDateArgs[1];
            int firstDays = firstDateArgs[2];

            int secondYear = secondDate[0];
            int secondMonth = secondDate[1];
            int secondDays = secondDate[2];

            DateTime firstDateTime = new DateTime(firstYear, firstMonth, firstDays);
            DateTime secondDateTime = new DateTime(secondYear, secondMonth, secondDays);

            TimeSpan diff = firstDateTime - secondDateTime;

            return Math.Abs(diff.Days);
        }
    }
}
