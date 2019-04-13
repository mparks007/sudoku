using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    // flags attribute lets this enum be treated as bit flags
    [Flags]
    public enum ModifierKey
    {
        None = 0,
        Shift = 1,
        Alt = 2,
        Control = 4
    }
}
