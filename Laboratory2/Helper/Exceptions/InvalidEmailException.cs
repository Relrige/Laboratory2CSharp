using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory2.Helper.Exceptions
{
    internal class InvalidEmailException : Exception
    {
        public InvalidEmailException() : base("You entered invalid email address. Try again.")
        {
        }
    }
}
