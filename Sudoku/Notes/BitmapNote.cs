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
        private readonly int _cellPixelSize;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="cellPixelSize">Render needs to know the parent cell size for calculations</param>
        public BitmapNote(int cellPixelSize)
        {
            _cellPixelSize = cellPixelSize;
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
                int top = ((parentCellRow - 1) * _cellPixelSize) + ((_candidate - 1) / 3 * (_cellPixelSize / 3));
                int left = ((parentCellColumn - 1) * _cellPixelSize) + ((_candidate - 1) % 3 * (_cellPixelSize / 3));
                Rectangle rect = new Rectangle(left, top, _cellPixelSize / 3, _cellPixelSize / 3);

                // setup note background and font coloring based on highlight or not
                Color c = Color.Transparent;
                Brush br = Brushes.Black;
                switch (HighlightType)
                {
                    case NoteHighlightType.Info:
                        c = BitmapBoard.Colors.NoteHighlightInfo;
                        br = new SolidBrush(BitmapBoard.Colors.NoteTextOnHighlightInfo);
                        break;
                    case NoteHighlightType.Bad:
                        c = BitmapBoard.Colors.NoteHighlightBad;
                        br = new SolidBrush(BitmapBoard.Colors.NoteTextOnHighlightBad);
                        break;
                    case NoteHighlightType.Strong:
                        c = BitmapBoard.Colors.NoteHighlightStrong;
                        br = new SolidBrush(BitmapBoard.Colors.NoteTextOnHighlightStrong);
                        break;
                    case NoteHighlightType.Weak:
                        c = BitmapBoard.Colors.NoteHighlightWeak;
                        br = new SolidBrush(BitmapBoard.Colors.NoteTextOnHighlightWeak);
                        break;
                }

                BitmapBoard.Graphics.FillRectangle(new SolidBrush(c), rect);

                string candidate = _candidate.ToString();

                // prep for drawing the text onto the image
                Font f = new Font(BitmapBoard.Fonts.Note, _cellPixelSize / 3 / 2);
                SizeF fSize = BitmapBoard.Graphics.MeasureString(candidate, f);
                StringFormat format = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                // draw the string (single digit note)
                BitmapBoard.Graphics.DrawString(candidate, f, br, rect, format);
            }
        }
    }
}
