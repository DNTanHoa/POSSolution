using System;
using System.Collections.Generic;
using System.Text;

namespace POSSolution.Utilities.Extensions
{
    public static class DateTimeExtension
    {
        public static string ToTableDisplayDate(this DateTime? value)
        {
            return value?.ToString("dd-MMM-yyyy");
        }
    }
}
