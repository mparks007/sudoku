using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    //public 
    public class Cell
    {
        private bool isHighlighted;
        private bool isSelected;
        private int solvedFor;
        private bool[] notes = new bool[9];
        private NoteHighlightType[] noteHighlights = new NoteHighlightType[9];

        // num as 0 will mean clear the solve number
        public void SetSolve(int num)
        {
            if (num < 0 || num > 9)
                throw new ArgumentException(String.Format("Invalid solution number being set: {0}", num));

            solvedFor = num;
        }

        public void ToggleNote(int note, bool doSet)
        {
            if (note < 1 || note > 9)
                throw new ArgumentException(String.Format("Invalid note being set: {0}", note));

            // if note is going away, clear potential highlight on it
            if (!doSet)
                HighlightNote(note, NoteHighlightType.None);

            notes[note - 1] = doSet;
        }

        public void ToggleSelect(bool doSelect)
        {
            isSelected = doSelect;
        }

        public void HighlightHavingNote(int note)
        {
            if (note < 1 || note > 9)
                throw new ArgumentException(String.Format("Invalid note requesting cell highlight: {0}", note));

            // if the cell has the note being asked for highlight
            if (notes[note - 1])
                ToggleHighlight(true);
        }

        public void ToggleHighlight(bool doHighlight)
        {
            isHighlighted = doHighlight;
        }

        public void HighlightNote(int note, NoteHighlightType highlightType)
        {
            if (note < 1 || note > 9)
                throw new ArgumentException(String.Format("Invalid note requesting note highlight: {0}", note));

            // if note is even set
            if (notes[note - 1])
                noteHighlights[note - 1] = highlightType;
        }
    }
}
