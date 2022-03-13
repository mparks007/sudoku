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
        protected int _value;           // main number set in the cell
        [JsonProperty]
        protected Note[] _notes;        // array of all the temporary notes possible
        [JsonProperty]
        protected Note _selectedNote;   // which of the 9 possible notes is selected (if any)
        
        public int Value { get { return _value; } }
        public bool HasAnswer { get { return (_value != 0); } }
        public bool? IsGiven { get; set; }      // if the cell is pre-filled with the correct value on board creation and needs no guess
        [JsonIgnore]
        public bool IsSelected { get; set; }    // if the cell is selected by the user (used for rendering options)
        public bool IsInvalid { get; set; }     // if the value set in the cell has been verifed to clash with the rules
        //[JsonIgnore]
        public CellHighlightType HighlightType { get; set; }    // rendering will use this to decide what the cell will look like
        [JsonIgnore]
        public bool IsHouseSelected { get; set; }   // rending will use this to decide if basic house selection coloring should be used
        public int Row { get; set; }                // which row of the board this cell is in (used in all sort of calculations)
        public int Column { get; set; }             // which column of the board this cell is in (used in all sort of calculations)
        public int Block { get; set; }              // which block of the board this cell is in (used in all sort of calculations)
        [JsonIgnore]
        public Note[] Notes { get { return _notes; } }

        /// <summary>
        /// Ctor (the board creation logic will tell each cell how it fits in the overall board structure
        /// </summary>
        /// <param name="row">Row of the cell in the overall board (used for various calculations)</param>
        /// <param name="column">Column of the cell in the overall board (used for various calculations)</param>
        /// <param name="block">Block of the cell in the overall board (used for various calculations)</param>
        public Cell(int row, int column, int block)
        {
            Row = row;
            Column = column;
            Block = block;
        }

        /// <summary>
        /// Places an guess number in the cell
        /// </summary>
        /// <param name="guessedNumber">Number to try and set (0 = clear guess)</param>
        public void SetGuess(int guessedNumber)
        {
            // if is same number as current, don't waste your time
            if (_value == guessedNumber)
                return;

            if ((guessedNumber < 0) || (guessedNumber > 9))
                throw new ArgumentException(String.Format("Invalid solution number being set: {0}", guessedNumber));

            // if is trying to convert a given to a guess (unless the guess is 0 for "delete"), don't
            if (IsGiven.HasValue && IsGiven.Value && (guessedNumber != 0))
                return;

            // finally, actually set the cell's value!
            _value = guessedNumber;

            // if was a Delete, no idea if IsGiven or not, so reset the nullable bool
            if (guessedNumber == 0)
                IsGiven = null;
            else // is an actual guess
                IsGiven = false;
        }

        /// <summary>
        /// Places a starter/given value in the cell
        /// </summary>
        /// <param name="given">Number to try and set</param>
        public void SetGiven(int given)
        {
            // if is same number as current, don't waste your time
            if (_value == given)
                return;

            if ((given < 1) || (given > 9))
                throw new ArgumentException(String.Format("Invalid given number being set: {0}", given));

            // if trying to convert a guess to a given, don't (I forget why I did this)
            if (IsGiven.HasValue && !IsGiven.Value)
                return;

            _value = given;
            IsGiven = true;
        }

        /// <summary>
        /// Toggle a note on/off
        /// </summary>
        /// <param name="noteNum">Note number to toggle</param>
        public void ToggleNote(int noteNum)
        {
            if ((noteNum < 1) || (noteNum > 9))
                throw new ArgumentException(String.Format("Invalid note being set/unset: {0}", noteNum));

            // if already has this note (then remove it, hence, a Toggle)
            if (_notes[noteNum - 1].Candidate == noteNum)
                RemoveNote(noteNum);
            else
                _notes[noteNum - 1].Candidate = noteNum;
        }

        /// <summary>
        /// Clear the note specified
        /// </summary>
        /// <param name="noteNum">Note to clear</param>
        public void RemoveNote(int noteNum)
        {
            if ((noteNum < 1) || (noteNum > 9))
                throw new ArgumentException(String.Format("Invalid note being removed: {0}", noteNum));

            // clear potential highlight on it too
            HighlightNote(noteNum, NoteHighlightType.None);
            _notes[noteNum - 1].Candidate = 0;
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
            if ((value != 0) && (((Board.HighlightValueMode == HighlightValueMode.NumbersAndNotes) && (_value == value)) || HasNoteOf(value)))
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
        /// <param name="noteNum">Which note to hightlight</param>
        /// <param name="highlightType">How to highlight it</param>
        public void HighlightNote(int noteNum, NoteHighlightType highlightType)
        {
            if ((noteNum < 1) || (noteNum > 9))
                throw new ArgumentException(String.Format("Invalid note requested for highlight: {0}", noteNum));

            if (HasNoteOf(noteNum))
                _notes[noteNum - 1].HighlightType = highlightType;
        }

        /// <summary>
        /// Determine if the cell has a particular note
        /// </summary>
        /// <param name="noteNum">Note to check for</param>
        /// <returns></returns>
        public bool HasNoteOf(int noteNum)
        {
            if ((noteNum < 1) || (noteNum > 9))
                throw new ArgumentException(String.Format("Invalid note being checked: {0}", noteNum));

            return (!HasAnswer && _notes[noteNum - 1].IsNoted);
        }

        /// <summary>
        /// Return the current, visible note, if notes are visible and a single note marked
        /// </summary>
        /// <returns>The single note noted, or null otherwise</returns>
        public Note GetOnlyNote()
        {
            if (!HasAnswer)
            {
                IEnumerable<Note> notes = _notes.Where(note => note.IsNoted).ToList<Note>();
                if (notes.Count<Note>() == 1)
                    return notes.First<Note>();
            }

            return null;
        }

        /// <summary>
        /// Get note object from a cell for a requested note number
        /// </summary>
        /// <param name="noteNum">Note to get</param>
        /// <returns>Note object if found cell with the requested note, otherwise null</returns>        
        public Note GetNoteForCandidate(int noteNum)
        {
            if (!HasAnswer)
            {
                if ((noteNum < 1) || (noteNum > 9))
                    throw new ArgumentException(String.Format("Invalid note being requested: {0}", noteNum));

                Note note = _notes[noteNum - 1];
                if (note != null)
                    return note;
            }

            return null;
        }

        /// <summary>
        /// Get notes that have been set with a candidate
        /// </summary>
        /// <returns>Notes list for any Note that has a number set (non zero)</returns>        
        public List<Note> GetNotesWithAnyCandidate()
        {
            if (!HasAnswer)
                return _notes.Where(note => note.Candidate != -0).ToList<Note>();

            return null;
        }

        /// <summary>
        /// Determine if there are multiple notes set
        /// </summary>
        /// <returns>True if multiple notes are set</returns>
        public bool HasMultipleNotes()
        {
            return (!HasAnswer && (_notes.Where(note => note.IsNoted).Count() > 1));
        }

        /// <summary>
        /// Determine if there is a single note set
        /// </summary>
        /// <returns>True if a single note is set</returns>
        public bool HasSingleNote()
        {
            return (!HasAnswer && (_notes.Where(note => note.IsNoted).Count() == 1));
        }

        /// <summary>
        /// Get number of notes that have candidates set (that are noted)
        /// </summary>
        /// <returns>Number of notes</returns>
        public int NumberOfNotes()
        {
            if (!HasAnswer)
                return (_notes.Where(note => note.IsNoted).Count());

            return 0;
        }

        /// <summary>
        /// Clear every note in the cell of highlight
        /// </summary>
        public void ClearNoteHighlights()
        {
            foreach (Note note in _notes)
                note.HighlightType = NoteHighlightType.None;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("[{0},{1}]", Row, Column);
        }

        /// <summary>
        /// Render (work done in derived classes)
        /// </summary>
        public abstract void Render();
    }
}
