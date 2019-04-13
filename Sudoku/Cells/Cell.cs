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
        protected int _number;
        protected bool _isHighlighted;
        protected Note[] _notes = new Note[9];

        // can some of these go to protected?
        public bool IsGiven { get; set; }
        public bool IsSelected { get; set; }
        public bool IsInvalid { get; set; }
        public bool IsHouseSelected { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int Block { get; set; }

        public Cell(int row, int column, int block)
        {
            Row = row;
            Column = column;
            Block = block;
        }

        public bool HasNumberSet
        {
            get { return _number != 0; }
        }

        // num as 0 will mean clear the solve number
        public void SetNumber(int num, bool isGiven)
        {
            if (num < 0 || num > 9)
                throw new ArgumentException(String.Format("Invalid solution number being set: {0}", num));

            _number = num;
            IsGiven = isGiven;

            if (_number == 0)
                _isHighlighted = false;
        }

        public void SetNote(int note)
        {
            if (note < 1 || note > 9)
                throw new ArgumentException(String.Format("Invalid note being set/unset: {0}", note));

            if (_notes[note - 1].Candidate == note)
            { 
                // if note is going away, clear potential highlight on it too
                HighlightNote(note, NoteHighlightType.None);
                _notes[note - 1].Candidate = 0;
            }
            else
                _notes[note - 1].Candidate = note;
        }

        public void HighlightHavingNoteOrNumber(int value)
        {
            if (value < 1 || value > 9)
                throw new ArgumentException(String.Format("Invalid value requested for cell highlight by note or number: {0}", value));

            // if set number is the one to highlight
            if (_number == value)
                _isHighlighted = true;
            else if (_number == 0) // or notes are visible
                _isHighlighted = _notes[value - 1].IsNoted; // and the requested note is present
            else
                _isHighlighted = false;
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
