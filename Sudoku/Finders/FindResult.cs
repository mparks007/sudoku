using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class FindResult
    {
        private List<KeyValuePair<Cell, CellHighlightType>> _candidateCells;    // list of cells that have the candidates that matched the particular technique/pattern in the search
        private List<Note> _candidateNotes;                                     // list of notes within the candidate cells that caused the match

        private List<Cell> _eliminationCells;  // list of cells that have one or more notes to be eliminated due to the particular technique/pattern in the search
        private List<Note> _eliminationNotes;  // list of notes within the elimination cells that can be eliminated

        public List<KeyValuePair<Cell, CellHighlightType>> CandidateCells { get { return _candidateCells; } }
        public List<Note> CandidateNotes { get { return _candidateNotes; } }

        public List<Cell> EliminationCells { get { return _eliminationCells; } }
        public List<Note> EliminationNotes { get { return _eliminationNotes; } }

        public FindResult()
        {
            _candidateCells = new List<KeyValuePair<Cell, CellHighlightType>>();
            _candidateNotes = new List<Note>();

            _eliminationCells = new List<Cell>();
            _eliminationNotes = new List<Note>();
        }

        /// <summary>
        /// Create a decent string representation of the results
        /// </summary>
        /// <returns>Formatted string</returns>
        public override string ToString()
        {
            // setup to max string length, which is approximately max lenth if end up like (number of cells * lenth of "[r,c,Special] ")
            StringBuilder str = new StringBuilder(CandidateCells.Count * 15);

            foreach (KeyValuePair<Cell, CellHighlightType> cellFound in CandidateCells)
            {
                string extraInfo = "";

                // if want to provide a bit of highlight for very specific types of candidate cells (ie. Pivot, Pincer), setup that extra info for the ToString text
                if (cellFound.Value != CellHighlightType.Special)
                    extraInfo = cellFound.Value.Description();

                str.AppendFormat("[{0},{1}{2}{3}] ", cellFound.Key.Row, cellFound.Key.Column, (extraInfo.Length > 0 ? ",": ""), extraInfo);
            }

            // go ahead and also show the candidate that was involved in the results
            foreach (Note note in CandidateNotes)
                str.AppendFormat("({0})", note.ToString());
            
            return str.ToString();
        }
    }
}
