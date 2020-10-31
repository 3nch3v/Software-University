
using System;

namespace MilitaryElite.Exceptions
{
    public class InvalidStateException : Exception
    {
        private const string DEF_EXP_MSG = "Invalide state!";
        public InvalidStateException()
            :base(DEF_EXP_MSG)
        {

        }

        public InvalidStateException(string message)
            : base(message)
        {

        }

    }
}
