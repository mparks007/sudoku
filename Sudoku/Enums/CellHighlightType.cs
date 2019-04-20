using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public enum CellHighlightType
    {
        [Description("X")]
        None,
        [Description("Value")]
        Value,
        [Description("Special")]
        Special,
        [Description("Pivot")]
        Pivot,
        [Description("Pincer")]
        Pincer
    }
}
