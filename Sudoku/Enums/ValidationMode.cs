using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public enum ValidationMode
    {
        [Description("Numbers")]
        Numbers,
        [Description("Notes")]
        Notes,
        [Description("Off")]
        Off
    }
}
