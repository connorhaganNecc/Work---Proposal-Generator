using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ProposalGenerator
{
    static class HelperFunctions
    {
        public static string StripAlphabetic(string inStr)
        {
            return Regex.Replace(inStr, "[^0-9.]", "");
        }
    }
}
