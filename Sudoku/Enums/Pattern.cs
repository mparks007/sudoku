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
}
