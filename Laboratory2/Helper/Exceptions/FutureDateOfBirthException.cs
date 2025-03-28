using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory2.Helper.Exceptions
{
    internal class FutureDateOfBirthException : Exception
    {
        public FutureDateOfBirthException() : base("The person can't be younger than 0 ")
        {
        }
    }
}
