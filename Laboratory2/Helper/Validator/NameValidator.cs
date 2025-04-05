using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laboratory2.Helper.Validator
{
    internal class NameValidator
    {
        public static bool IsValidName(string name)
        {
            string pattern = @"[a-z, A-Z]";
            return Regex.IsMatch(name, pattern);
        }
    }
}
