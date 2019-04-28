using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    interface IFinder
    {
        List<FindResult> Find(Board board, Pattern pattern);
    }
}
