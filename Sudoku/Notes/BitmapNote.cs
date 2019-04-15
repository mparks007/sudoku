using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class BitmapNote : Note
    {
        private int _cellSize;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="cellSize">Render needs to know the parent cell size for calculations</param>
        public BitmapNote(int cellSize)
        {
            _cellSize = cellSize;
        }

        /// <summary>
        /// Render the note
        /// </summary>
        /// <param name="parentCellRow">Board row of the parent cell (used for render calculations)</param>
        /// <param name="parentCellColumn">Board column of the parent cell (used for render calculations)</param>
        public override void Render(int parentCellRow, int parentCellColumn)
        {
            // if has a note, render it
            if (_candidate != 0)
            {
                // calculate offset of each note to find right rect by note position in the overall board image
                //   top: (row depth) + (inner-cell depth)
                //   left: (col offset) + (inner-cell offset)
                int top = ((parentCellRow - 1) * _cellSize) + ((_candidate - 1) / 3 * (_cellSize / 3));
                int left = ((parentCellColumn - 1) * _cellSize) + ((_candidate - 1) % 3 * (_cellSize / 3));
                Rectangle rect = new Rectangle(left, top, _cellSize / 3, _cellSize / 3);

                // render the note's background
                Color c = Color.Transparent;
                switch (HighlightType)
                {
                    case NoteHighlightType.Info:
                        c = Color.LightSeaGreen;
                        break;
                    case NoteHighlightType.Bad:
                        c = Color.Red;
                        break;
                    case NoteHighlightType.Strong:
                        c = Color.RoyalBlue;
                        break;
                    case NoteHighlightType.Weak:
                        c = Color.Yellow;
                        break;
                }
                BitmapBoard.Graphics.FillRectangle(new SolidBrush(c), rect);

                string candidate = _candidate.ToString();

                // prep for drawing the text onto the image
                Font f = new Font("Arial", _cellSize / 3 / 2);
                SizeF fSize = BitmapBoard.Graphics.MeasureString(candidate, f);
                StringFormat format = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                // draw the string, but use different (lighter) color if on red background  (but this will have to change if I have custom colors)
                BitmapBoard.Graphics.DrawString(candidate, f, ((HighlightType == NoteHighlightType.Bad || HighlightType == NoteHighlightType.Strong) ? Brushes.LightGray : Brushes.DarkSlateGray), rect, format);
            }
        }
    }
}
