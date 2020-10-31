using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private ICollection<ISoldier> privateUnderCommand;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            privateUnderCommand = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> PrivateUnderCommand => (IReadOnlyCollection<ISoldier>)privateUnderCommand;


        public void AddPrivate(ISoldier soldier)
        {
            privateUnderCommand.Add(soldier);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine(base.ToString())
                .AppendLine("Privates:");

            foreach (var @private in privateUnderCommand)
            {
                sb.AppendLine($"  {@private}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
