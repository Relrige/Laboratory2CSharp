using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory2.Helper.Exceptions
{
    internal class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException() : base("You entered invalid name. Try again.")
        {
        }
    }
}
