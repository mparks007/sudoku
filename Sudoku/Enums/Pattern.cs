using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public enum Pattern
    {
        [Description("X-Wing")]
        XWing,
        [Description("Skyscraper")]
        Skyscraper,
        [Description("Two-String Kite")]
        TwoStringKite,
        [Description("XY-Wing")]
        XYWing
    }

    public static class EnumerationExtension
    {
        public static string Description(this Pattern value)
        {
            // get attributes  
            var field = value.GetType().GetField(value.ToString());
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            // return description
            return attributes.Any() ? ((DescriptionAttribute)attributes.ElementAt(0)).Description : "Description Not Found";
        }
    }
}
