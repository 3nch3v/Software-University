
using System;
using MilitaryElite.Enumerations;
using MilitaryElite.Exceptions;

namespace MilitaryElite
{
    public class Mission : IMission
    {
        private string state;


        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = TryStateParse(state);
        }


        public string CodeName { get; private set; }

        public State State { get; private set; }



        private State TryStateParse(string state)
        {
            State parsedState;
            bool parsed = Enum.TryParse<State>(state, out parsedState);

            if (!parsed)
            {
                throw new InvalidStateException();
            }

            return parsedState;
        }

        public void CompleteMission()
        {
            State = State.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State.ToString()}";
        }
    }
}
