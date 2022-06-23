using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder.Helpers;
internal static class StringExtensions
{
    public static string FirstCharToLowerCase(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }

        return value.Length > 1
            ? value[0].ToString().ToLower() + value[1..]
            : value.ToLower();
    }
}
