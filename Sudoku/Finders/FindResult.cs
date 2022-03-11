using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class FindResult
    {
        public List<KeyValuePair<Cell, CellHighlightType>> CellsFound = new List<KeyValuePair<Cell, CellHighlightType>>();
        public int Note;

        /// <summary>
        /// Create a decent string representation of the results
        /// </summary>
        /// <returns>Formatted string</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder(CellsFound.Count * 15);

            foreach (KeyValuePair<Cell, CellHighlightType> cellFound in CellsFound)
            {
                string extraInfo = "";

                // if not Special, ensure the found cell details can add a little extra info to the type of cell, like Pincer, Pivot, etc.
                if (cellFound.Value != CellHighlightType.Special)
                    extraInfo = cellFound.Value.Description();

                str.AppendFormat("[{0},{1}{2}{3}] ", cellFound.Key.Row, cellFound.Key.Column, (extraInfo.Length > 0 ? ",": ""), extraInfo);
            }

            return str.ToString();
        }
    }
}
