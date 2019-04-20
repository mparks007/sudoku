using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public enum NoteHighlightType
    {
        [Description("X")]
        None,
        [Description("Info")]
        Info,
        [Description("Strong")]
        Strong,
        [Description("Weak")]
        Weak,
        [Description("Bad")]
        Bad
    }
}
