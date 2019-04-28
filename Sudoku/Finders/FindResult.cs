using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class FindResult
    {
        public List<KeyValuePair<Cell, CellHighlightType>> CellsFound = new List<KeyValuePair<Cell, CellHighlightType>>();

        /// <summary>
        /// Create a decent string representation of the results
        /// </summary>
        /// <returns>Formattes string</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder(CellsFound.Count * 15);

            foreach (KeyValuePair<Cell, CellHighlightType> cellFound in CellsFound)
                str.AppendFormat("[{0},{1},{2}]", cellFound.Key.Row, cellFound.Key.Column, cellFound.Value.Description());

            return str.ToString();
        }
    }
}
