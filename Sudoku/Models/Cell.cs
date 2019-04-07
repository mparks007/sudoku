using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Cell
    {
        private int _solvedFor;
        private Note[] _notes = new Note[9];

        public int SolvedFor { get { return _solvedFor; } }
        public bool IsHighlighted { get; set; }
        public bool IsSelected { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int Block { get; set; }

        public Cell(int row, int column, int block)
        {
            for (int i = 0; i < 9; i++)
                _notes[i] = new Note();

            Row = row;
            Column = column;
            Block = block;
        }

        // num as 0 will mean clear the solve number
        public void SetSolve(int num)
        {
            if (num < 0 || num > 9)
                throw new ArgumentException(String.Format("Invalid solution number being set: {0}", num));

            _solvedFor = num;
        }

        public void SetNote(int note, bool doSet)
        {
            if (note < 1 || note > 9)
                throw new ArgumentException(String.Format("Invalid note being {0}: {1}", (doSet ? "set" : "unset"), note));

            // if note is going away, clear potential highlight on it first
            if (!doSet)
                HighlightNote(note, NoteHighlightType.None);

            _notes[note - 1].Candidate = note;
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
                throw new ArgumentException(String.Format("Invalid note requesting note highlight: {0}", note));

            // if note is even set
            if (_notes[note - 1].IsNoted)
                _notes[note - 1].HighlightType = highlightType;
        }

        public void Render(Bitmap boardImage)
        {
            using (Graphics gr = Graphics.FromImage(boardImage))
            {
                for (int i = 0; i < 9; i++)
                    _notes[i].Render(Row, Column, boardImage);

                gr.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle rect = new Rectangle(Row*20, Column*20, 50, 90);

                gr.DrawString("cell", new Font("Tahoma", 10), Brushes.Black, rect);
            }

        }
    }
}
