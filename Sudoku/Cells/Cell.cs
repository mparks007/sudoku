using Newtonsoft.Json;
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
        [JsonProperty]
        protected int _answer;
        [JsonProperty]
        protected Note[] _notes;
        [JsonProperty]
        protected Note _selectedNote;
        
        public int Answer { get { return _answer; } }
        public bool HasAnswer { get { return (_answer != 0); } }
        public bool? IsGiven { get; set; }
        [JsonIgnore]
        public bool IsSelected { get; set; }
        public bool IsInvalid { get; set; }
        public CellHighlightType HighlightType { get; set; }
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
        /// Places an guess number in the cell
        /// </summary>
        /// <param name="guess">Number to try and set (0 = clear guess)</param>
        public void SetGuess(int guess)
        {
            // if is same number as current, don't waste your time
            if (_answer == guess)
                return;

            if ((guess < 0) || (guess > 9))
                throw new ArgumentException(String.Format("Invalid solution number being set: {0}", guess));

            // if is trying to convert a given to a guess (unless the guess is 0 for "delete"), don't
            if (IsGiven.HasValue && IsGiven.Value && (guess != 0))
                return;

            _answer = guess;

            // if was a Delete, no idea if IsGiven or not, so reset the nullable bool
            if (guess == 0)
                IsGiven = null;
            else // is an actual guess
                IsGiven = false;
        }

        /// <summary>
        /// Places a starter/given answer number in the cell
        /// </summary>
        /// <param name="given">Number to try and set</param>
        public void SetGiven(int given)
        {
            // if is same number as current, don't waste your time
            if (_answer == given)
                return;

            if ((given < 1) || (given > 9))
                throw new ArgumentException(String.Format("Invalid given number being set: {0}", given));

            // if is trying to convert a guess to a given, don't
            if (IsGiven.HasValue && !IsGiven.Value)
                return;

            _answer = given;
            IsGiven = true;
        }

        /// <summary>
        /// Toggle a note on/off
        /// </summary>
        /// <param name="note">Note number to toggle</param>
        public void ToggleNote(int note)
        {
            if ((note < 1) || (note > 9))
                throw new ArgumentException(String.Format("Invalid note being set/unset: {0}", note));

            // if already has this note (then remove it)
            if (_notes[note - 1].Candidate == note)
                RemoveNote(note);
            else
                _notes[note - 1].Candidate = note;
        }

        /// <summary>
        /// Clear the note specified
        /// </summary>
        /// <param name="note">Note to clear</param>
        public void RemoveNote(int note)
        {
            // clear potential highlight on it too
            HighlightNote(note, NoteHighlightType.None);
            _notes[note - 1].Candidate = 0;
        }

        /// <summary>
        /// Highlight either an answer number or a note based on the passed in value
        /// </summary>
        /// <param name="value">Number or note to check against and highlight</param>
        public void HighlightHavingNoteOrNumber(int value)
        {
            // convert the forced value override to the 'clear highlight' value
            if (value == -1)
                value = 0;

            if ((value < 0) || (value > 9))
                throw new ArgumentException(String.Format("Invalid value requested for cell highlight by note or number: {0}", value));

            // if not a forced unhighlight...AND answer number is the one to highlight OR notes are visible and the requested note is present
            if ((value != 0) && ((_answer == value) || (!HasAnswer && HasNote(value))))
                HighlightType = CellHighlightType.Value;
            else
                HighlightType = CellHighlightType.None;
        }

        /// <summary>
        /// Set the selected note (if one) to the specified hightlight level
        /// </summary>
        /// <param name="highlightType">How to highlight it</param>
        public void HighlightSelectedNote(NoteHighlightType highlightType)
        {
            if (_selectedNote != null)
                _selectedNote.HighlightType = highlightType;
        }

        /// <summary>
        /// Set the specific note to the specified hightlight level
        /// </summary>
        /// <param name="note">Which note to hightlight</param>
        /// <param name="highlightType">How to highlight it</param>
        public void HighlightNote(int note, NoteHighlightType highlightType)
        {
            if ((note < 1) || (note > 9))
                throw new ArgumentException(String.Format("Invalid note requested for highlight: {0}", note));

            if (HasNote(note))
                _notes[note - 1].HighlightType = highlightType;
        }

        /// <summary>
        /// Determine if the cell has a particular note
        /// </summary>
        /// <param name="note">Note to check for</param>
        /// <returns></returns>
        public bool HasNote(int note)
        {
            return _notes[note - 1].IsNoted;
        }

        /// <summary>
        /// Clear every note in the cell of highlight
        /// </summary>
        public void ClearNoteHighlights()
        {
            for (int i = 0; i < 9; i++)
                if (_notes[i].HighlightType != NoteHighlightType.None)
                    _notes[i].HighlightType = NoteHighlightType.None;
        }

        /// <summary>
        /// Render (work done in derived classes)
        /// </summary>
        public abstract void Render();
    }
}
