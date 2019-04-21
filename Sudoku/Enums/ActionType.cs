using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public enum ActionType
    {
        Select,
        SetGiven,
        SetGuess,
        ToggleNote,
        Delete
    }
}
