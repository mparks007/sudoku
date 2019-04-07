using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Note
    {
        private int _candidate;

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

        public bool IsNoted
        {
            get { return _candidate != 0; }
        }

        public bool IsHighlighted { get; set; }
        public NoteHighlightType HighlightType { get; set; }
        public bool IsSelected { get; set; }

        public void Render(int row, int col, Bitmap boardImage)
        {
            using (Graphics gr = Graphics.FromImage(boardImage))
            {
                Rectangle rect = new Rectangle(row*25, col*25, 50, 90);

                gr.DrawString("note", new Font("Tahoma", 10), Brushes.Black, rect);
            }
        }
    }
}
