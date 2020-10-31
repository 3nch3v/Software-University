
using System;

namespace MilitaryElite.Exeptions
{
    public class InvalidCorpsException : Exception
    {
        private const string DEF_EXC_MSG = "Invalide corps!";

        public InvalidCorpsException()
            :base(DEF_EXC_MSG)
        {


        }

        public InvalidCorpsException(string message) 
            : base(message)
        {


        }
        
    }
}
