using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public enum HighlightValueMode
    {
        [Description("Notes Only")]
        NotesOnly,
        [Description("Numbers/Notes")]
        NumbersAndNotes,
        [Description("Off")]
        Off
    }
}
