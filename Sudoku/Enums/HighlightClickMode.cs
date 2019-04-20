using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public enum HighlightClickMode
    {
        [Description("Cell Select")]
        Cell,
        [Description("Note Select")]
        Note,
        [Description("Manual")]
        Manual
    }
}
