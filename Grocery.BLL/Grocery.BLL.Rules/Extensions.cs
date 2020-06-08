using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Grocery.BLL.Rules
{
    public static class Extensions
    {
        //Есть ли среди данных буквы?
        public static bool IsString(this string value)
        {
            bool isValid = Regex.IsMatch(value, @"^[a-zA-Z]+$");
            return isValid;
        }

        //Есть ли среди данных буквы и числа?
        public static bool IsStringWithNumbers(this string value)
        {
            bool isValid = Regex.IsMatch(value, @"^[a-zA-Z0-9]+$");
            return isValid;
        }

        //Есть ли среди данных числа?
        public static bool IsNumbers(this string value)
        {
            bool isValid = Regex.IsMatch(value, @"^[0-9]+$");
            return isValid;
        }

        //Есть ли среди данных буквы и числа и другие символы?
        public static bool IsStringWithAdditionalSymbols(this string value, string addition)
        {
            string pattern = string.Format(@"^[a-zA-Z{0}]+$", addition);
            bool isValid = Regex.IsMatch(value, pattern);
            return isValid;
        }

        public static bool IsFractNumbers(this string value)
        {
            bool isValid = Regex.IsMatch(value, @"^[0-9]*[,]?[0-9]{0,2}\Z");
            return isValid;
        }
    }
}
