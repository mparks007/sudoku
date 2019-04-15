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
        protected int _bigNumber;
        protected bool _isHighlighted;
        protected Note[] _notes = new Note[9];

        public bool? IsGiven { get; set; }
        public bool IsSelected { get; set; }
        public bool IsInvalid { get; set; }
        public bool IsHouseSelected { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int Block { get; set; }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="row">Row of the cell in the overall board (used for render calculations)</param>
        /// <param name="column">Column of the cell in the overall board (used for render calculations)</param>
        /// <param name="block">Block of the cell in the overall board (used for render calculations)</param>
        public Cell(int row, int column, int block)
        {
            Row = row;
            Column = column;
            Block = block;
        }

        /// <summary>
        /// Checks if the answer number has been set
        /// </summary>
        public bool HasNumberSet
        {
            get { return _bigNumber != 0; }
        }

        /// <summary>
        /// Places an answer/guess/solve main number in the cell
        /// </summary>
        /// <param name="num">Number to try and set</param>
        public void SetGuess(int num)
        {
            // if is same number as current, don't waste your time
            if (_bigNumber == num)
                return;

            if (num < 0 || num > 9)
                throw new ArgumentException(String.Format("Invalid solution number being set: {0}", num));

            // if is trying to convert a given to a guess, don't waste your time
            if (IsGiven.HasValue && IsGiven.Value)
                return;

            _bigNumber = num;
            _isHighlighted = false;
            IsGiven = false;
        }

        /// <summary>
        /// Places a starter/given main number in the cell
        /// </summary>
        /// <param name="num">Number to try and set</param>
        public void SetGiven(int num)
        {
            // if is same number as current, don't waste your time
            if (_bigNumber == num)
                return;

            if (num < 1 || num > 9)
                throw new ArgumentException(String.Format("Invalid given number being set: {0}", num));

            // if is trying to convert a guess to a given, don't waste your time
            if (IsGiven.HasValue && !IsGiven.Value)
                return;

            _bigNumber = num;
            _isHighlighted = false;
            IsGiven = true;
        }

        /// <summary>
        /// Toggle a note on/off
        /// </summary>
        /// <param name="note">Note number to toggle</param>
        public void ToggleNote(int note)
        {
            if (note < 1 || note > 9)
                throw new ArgumentException(String.Format("Invalid note being set/unset: {0}", note));

            // if already has this note (then remove it)
            if (_notes[note - 1].Candidate == note)
            { 
                // if note is going away, clear potential highlight on it too
                HighlightNote(note, NoteHighlightType.None);
                _notes[note - 1].Candidate = 0;
            }
            else
                _notes[note - 1].Candidate = note;
        }

        /// <summary>
        /// Highlight either an answer number or a note based on the passed in value
        /// </summary>
        /// <param name="value">Number or note to check against and highlight</param>
        public void HighlightHavingNoteOrNumber(int value)
        {
            if (value < 1 || value > 9)
                throw new ArgumentException(String.Format("Invalid value requested for cell highlight by note or number: {0}", value));

            // if answer number is the one to highlight
            if (_bigNumber == value)
                _isHighlighted = true;
            else if (_bigNumber == 0) // or notes are visible
                _isHighlighted = _notes[value - 1].IsNoted; // and the requested note is present
            else
                _isHighlighted = false;
        }

        /// <summary>
        /// Set the specific note to the specified hightlight level
        /// </summary>
        /// <param name="note">Which note to hightlight</param>
        /// <param name="highlightType">How to highlight it</param>
        public void HighlightNote(int note, NoteHighlightType highlightType)
        {
            if (note < 1 || note > 9)
                throw new ArgumentException(String.Format("Invalid note requested for highlight: {0}", note));

            // if note is set
            if (_notes[note - 1].IsNoted)
                _notes[note - 1].HighlightType = highlightType;
        }

        /// <summary>
        /// Render (work done in derived classes)
        /// </summary>
        public abstract void Render();
    }
}
