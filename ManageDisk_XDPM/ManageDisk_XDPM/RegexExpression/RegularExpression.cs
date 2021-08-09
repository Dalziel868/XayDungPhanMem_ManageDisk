using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ManageDisk_XDPM.RegexExpression
{
    public static class RegularExpression
    {
        
        public static bool isNumber(string s)
        {
            Regex regex = new Regex("^[0-9]*$");
            return regex.IsMatch(s);
        }
        public static bool isPhone(string s)
        {
            Regex regex = new Regex("^[0-9]{0,11}$");
            return regex.IsMatch(s);
        }
    }
}
