﻿using System;
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
        public override void Render(int cellSize, int row, int col)
        {
            // if has a note, render it
            if (_candidate != 0)
            {
                // calculate offset of each note to find right rect by note position
                //   top: (row depth) + (inner-cell depth)
                //   left: (col offset) + (inner-cell offset)
                int top = ((row - 1) * cellSize) + ((_candidate - 1) / 3 * (cellSize / 3));
                int left = ((col - 1) * cellSize) + ((_candidate - 1) % 3 * (cellSize / 3));
                Rectangle rect = new Rectangle(left, top, cellSize / 3, cellSize / 3);

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
                        c = Color.DeepSkyBlue;
                        break;
                    case NoteHighlightType.Weak:
                        c = Color.Yellow;
                        break;
                }
                BitmapBoard.Graphics.FillRectangle(new SolidBrush(c), rect);

                string candidate = _candidate.ToString();

                // prep for drawing the text onto the image
                Font f = new Font("Arial", cellSize / 3 / 2);
                SizeF fSize = BitmapBoard.Graphics.MeasureString(candidate, f);
                StringFormat format = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                // draw the string, but use different (lighter) color if on red background  (but this will have to change if I have custom colors)
                BitmapBoard.Graphics.DrawString(candidate, f, (HighlightType == NoteHighlightType.Bad ? Brushes.Silver : Brushes.DarkSlateGray), rect, format);
            }
        }
    }
}
