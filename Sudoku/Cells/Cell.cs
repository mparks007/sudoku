using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public abstract class Cell
    {
        protected int _solvedFor;
        protected Note[] _notes = new Note[9];

        public int SolvedFor { get { return _solvedFor; } }
        public bool IsGiven { get; set; }
        public bool IsHighlighted { get; set; }
        public bool IsSelected { get; set; }
        public bool IsHouseSelected { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int Block { get; set; }

        public Cell(int row, int column, int block)
        {
            // not sure how to instantiate the right Note type if doing this in base clase (moved to derived Cells) :/
            //for (int i = 0; i < 9; i++)
            //    _notes[i] = new Note();

            Row = row;
            Column = column;
            Block = block;
        }

        // num as 0 will mean clear the solve number
        public void SetSolve(int num, bool isGiven)
        {
            if (num < 0 || num > 9)
                throw new ArgumentException(String.Format("Invalid solution number being set: {0}", num));

            _solvedFor = num;
            IsGiven = isGiven;
        }

        public void SetNote(int note, bool doSet)
        {
            if (note < 1 || note > 9)
                throw new ArgumentException(String.Format("Invalid note being {0}: {1}", (doSet ? "set" : "unset"), note));

            if (doSet)
                _notes[note - 1].Candidate = note;
            else
            {
                // if note is going away, clear potential highlight on it first
                HighlightNote(note, NoteHighlightType.None);
                _notes[note - 1].Candidate = 0;
            }
        }

        public void HighlightHavingNote(int note)
        {
            if (note < 1 || note > 9)
                throw new ArgumentException(String.Format("Invalid note requested for cell highlight: {0}", note));

            // if the cell has the note being asked for highlight
            if (_notes[note - 1].IsNoted)
                IsHighlighted = true;
            else
                IsHighlighted = false;
        }


        public void HighlightNote(int note, NoteHighlightType highlightType)
        {
            if (note < 1 || note > 9)
                throw new ArgumentException(String.Format("Invalid note requested for highlight: {0}", note));

            // if note is set
            if (_notes[note - 1].IsNoted)
                _notes[note - 1].HighlightType = highlightType;
        }

        public abstract void Render(int cellSize);
    }
}
