using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory2.Helper.Exceptions
{
    internal class TooOldDateOfBirthException : Exception
    {
        public TooOldDateOfBirthException() : base("You can't be that old. Try again.")
        {
        }
    }
}
