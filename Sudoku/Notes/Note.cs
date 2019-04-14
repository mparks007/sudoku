using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public abstract class Note
    {
        protected int _candidate;
        protected bool _isHighlighted;

        public int Candidate
        {
            get { return _candidate; }

            set
            {
                if (value < 0 || value > 9)
                    throw new ArgumentException(String.Format("Invalid note value being set: {0}", value));

                _candidate = value;
            }
        }

        public bool IsNoted { get { return _candidate != 0; } }
        public NoteHighlightType HighlightType { get; set; }

        public abstract void Render(int row, int col);
    }
}
